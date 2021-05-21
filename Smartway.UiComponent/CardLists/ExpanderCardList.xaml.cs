using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.CardLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpanderCardList : ContentView
    {
        private readonly Queue<object> _articleToAdd = new Queue<object>();

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

        public ExpandState ExpanderState { get; set; }

        
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public bool LoadAsync
        {
            get => (bool)GetValue(LoadAsyncProperty);
            set => SetValue(LoadAsyncProperty, value);
        }

        public ICommand ExpandCommand
        {
            get => (ICommand)GetValue(ExpandCommandProperty);
            set => SetValue(ExpandCommandProperty, value);
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
                AddArticleToLoadAsync(SourceList);
            }

            SourceList.CollectionChanged += OnSourceListChanged;
            OnPropertyChanged(nameof(Counter));
        }

        private void AddArticleToLoadAsync(IEnumerable<object> articles)
        {
            foreach (var article in articles)
            {
                _articleToAdd.Enqueue(article);
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
                await ApplyChanges(e);

            OnPropertyChanged(nameof(Counter));
            await DisplayData();
        }

        private async Task ApplyChanges(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddArticleToLoadAsync(e.NewItems.Cast<object>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    await RemoveArticleFromDisplayedList(e.OldItems.Cast<object>().First());
                    break;
                default:
                    return;
            }
        }

        private async Task RemoveArticleFromDisplayedList(object item)
        {
            ItemsLoadedList.Remove(item);
            await ForceExpanderResize();
        }

        private async Task AddArticleToDisplayedList(object item)
        {
            ItemsLoadedList.Add(item);
            await ForceExpanderResize();
        }

        private async Task OnExpanderClick()
        {
            ExpandCommand?.Execute(null);
            if (ExpanderState != ExpandState.Expanding)
                return;

            await DisplayData();
        }


        private async Task DisplayData()
        {
            while (_articleToAdd.Count>0)
            {
                if (!IsExpanded)
                    return;

                var article = _articleToAdd.Dequeue();
                await AddArticleToDisplayedList(article);
            }
            
            await ForceExpanderResize();
        }
    }
}