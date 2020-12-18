using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.CardLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCardList
    {
        public static readonly BindableProperty ArticlesListProperty = BindableProperty.Create(nameof(ArticlesList), typeof(ObservableCollection<object>), typeof(ArticleCardList));
        public static readonly BindableProperty IsCondensedProperty = BindableProperty.Create(nameof(IsCondensed), typeof(bool), typeof(ArticleCardList), false);
        public static readonly BindableProperty IsSwipeableProperty = BindableProperty.Create(nameof(IsSwipeable), typeof(bool), typeof(ArticleCardList));
        public static readonly BindableProperty SwipedCommandProperty = BindableProperty.Create(nameof(SwipedCommand), typeof(ICommand), typeof(ArticleCardList));

        public ObservableCollection<object> ArticlesList
        {
            get => (ObservableCollection<object>) GetValue(ArticlesListProperty);
            set => SetValue(ArticlesListProperty, value);
        }

        public ArticleCardList()
        {
            InitializeComponent();
            ArticleListElement.PropertyChanged += ArticleListChanged;
        }

        public bool IsCondensed
        {
            get => (bool) GetValue(IsCondensedProperty);
            set => SetValue(IsCondensedProperty, value);
        }

        public bool IsSwipeable
        {
            get => (bool)GetValue(IsSwipeableProperty);
            set => SetValue(IsSwipeableProperty, value);
        }

        public ICommand SwipedCommand
        {
            get => (ICommand)GetValue(SwipedCommandProperty);
            set => SetValue(SwipedCommandProperty, value);
        }

        private void ArticleListChanged(object sender, PropertyChangedEventArgs e)
        {
            var enumerator = ArticleListElement.Children.Cast<StackLayout>().GetEnumerator();
            if (enumerator.MoveNext())
                enumerator.Current.Children.First().IsVisible = false;
            while (enumerator.MoveNext())
                enumerator.Current.Children.First().IsVisible = true;
        }
    }
}