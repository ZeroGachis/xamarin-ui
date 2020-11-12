using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.CardLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCardList
    {
        public static readonly BindableProperty ArticlesListProperty = BindableProperty.Create(nameof(ArticlesList), typeof(ObservableCollection<object>), typeof(ArticleCardList));
        public static readonly BindableProperty IsCondensedProperty = BindableProperty.Create(nameof(IsCondensed), typeof(bool), typeof(ArticleCardList), false);

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

        private void ArticleListChanged(object sender, PropertyChangedEventArgs e)
        {
            var element = ArticleListElement.Children.Cast<StackLayout>().FirstOrDefault(_ => _.IsVisible);
            if (element != null)
            {
                element.Children.First().IsVisible = false;
            }
        }
    }
}