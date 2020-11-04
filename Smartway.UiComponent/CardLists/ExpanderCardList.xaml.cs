using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Smartway.UiComponent.Cards;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.CardLists
{
    internal class ObservableCollectionAction<T>
    {
        public ObservableCollectionAction(NotifyCollectionChangedAction action, T item)
        {
            Action = action;
            Item = item;
        }

        public NotifyCollectionChangedAction Action { get; }

        public T Item { get; }

        public void ApplyAction(ObservableCollection<T> collection)
        {
            switch (Action)
            {
                case NotifyCollectionChangedAction.Add:
                    collection.Add(Item);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    collection.Remove(Item);
                    break;
            }
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpanderCardList : ContentView
    {
        private readonly Queue<ObservableCollectionAction<object>> _actionToExecute = new Queue<ObservableCollectionAction<object>>();

        public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(ExpanderCardList));
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ExpanderCardList));
        public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(ExpanderCardList), defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty ExpandCommandProperty = BindableProperty.Create(nameof(ExpandCommand), typeof(ICommand), typeof(ExpanderCardList));
        public static readonly BindableProperty SourceListProperty = BindableProperty.Create(nameof(SourceList), typeof(ObservableCollection<object>), typeof(ExpanderCardList), propertyChanged: OnArticleListChanged);
        public static readonly BindableProperty LoadAsyncProperty = BindableProperty.Create(nameof(LoadAsync), typeof(bool), typeof(ExpanderCardList));

        public ExpanderCardList()
        {
            InitializeComponent();
        }
        public string Status
        {
            get => (string)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Counter => (SourceList?.Count ?? 0).ToString();

        public ExpanderState ExpanderState { get; set; }

        public bool IsExpanded { get; set; }

        public bool LoadAsync
        {
            get => (bool)GetValue(LoadAsyncProperty);
            set => SetValue(LoadAsyncProperty, value);
        }

        public ICommand ForceUpdateSizeCommand { get; set; }

        public ICommand ExpanderClickCommand => new Command(async () => await OnExpanderClick());

        public ObservableCollection<object> SourceList
        {
            get => (ObservableCollection<object>)GetValue(SourceListProperty);
            set => SetValue(SourceListProperty, value);
        }

        public ObservableCollection<object> ItemsLoadedList { get; set; }

        static void OnArticleListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var expanderList = (ExpanderCardList)bindable;
            var oldArticleList = (ObservableCollection<object>)oldValue;
            var newArticleList = (ObservableCollection<object>)newValue;
            expanderList.OnNewSourceListValueSet(oldArticleList, newArticleList);
        }

        public void OnNewSourceListValueSet(ObservableCollection<object> oldValue, ObservableCollection<object> newValue)
        {
            if (oldValue != null)
                oldValue.CollectionChanged -= OnSourceListChanged;
            if (newValue == null)
                return;

            if (!LoadAsync)
                ItemsLoadedList = SourceList;
            else
            {
                ItemsLoadedList = new ObservableCollection<object>();
                AddActions(NotifyCollectionChangedAction.Add, SourceList);
            }

            SourceList.CollectionChanged += OnSourceListChanged;
            OnPropertyChanged(nameof(Counter));
        }

        private void AddActions(NotifyCollectionChangedAction action, IEnumerable<object> articles)
        {
            foreach (var article in articles)
            {
                _actionToExecute.Enqueue(new ObservableCollectionAction<object>(action, article));
            }
        }

        public async Task ForceExpanderResize()
        {
            await Task.Delay(50);
            ForceUpdateSizeCommand?.Execute(null);
        }

        private async void OnSourceListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (LoadAsync)
                SaveAction(e);

            OnPropertyChanged(nameof(Counter));
            await DisplayData();
        }

        private void SaveAction(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems?.Count > 0)
                AddActions(e.Action, e.NewItems.Cast<object>());
            if (e.OldItems?.Count > 0)
                AddActions(e.Action, e.OldItems.Cast<object>());
        }

        private async Task OnExpanderClick()
        {
            if (ExpanderState != ExpanderState.Expanding)
                return;

            await DisplayData();
        }


        private async Task DisplayData()
        {
            while (_actionToExecute.Count>0)
            {
                if (!IsExpanded)
                    return;

                var action = _actionToExecute.Dequeue();
                action.ApplyAction(ItemsLoadedList);
                await ForceExpanderResize();
            }
            
            await ForceExpanderResize();
        }
    }
}