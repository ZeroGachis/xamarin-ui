using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.CardLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCardList
    {
        public static readonly BindableProperty ArticlesListProperty = BindableProperty.Create(nameof(ArticlesList), typeof(List<object>), typeof(ArticleCardList));

        public List<object> ArticlesList
        {
            get => (List<object>) GetValue(ArticlesListProperty);
            set => SetValue(ArticlesListProperty, value);
        }

        public ArticleCardList()
        {
            InitializeComponent();
            ArticleListElement.PropertyChanged += ArticleListChanged;
        }

        private void ArticleListChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ArticlesList));
            var element = ArticleListElement.Children.Cast<StackLayout>().FirstOrDefault(_ => _.IsVisible);
            if (element != null)
            {
                element.Children.First().IsVisible = false;
            }
        }
    }
}