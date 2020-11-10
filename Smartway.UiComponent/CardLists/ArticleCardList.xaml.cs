using System;
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
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ArticleCardList));

        public ObservableCollection<object> ArticlesList
        {
            get => (ObservableCollection<object>) GetValue(ArticlesListProperty);
            set => SetValue(ArticlesListProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public ArticleCardList()
        {
            InitializeComponent();
            ArticleListElements.PropertyChanged += ArticleListChanged;
        }

        private void ArticleListChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "ItemsSource" && e.PropertyName != "ItemTemplate")
            {
                try
                {
                    var element = ArticleListElements.Children.Cast<Layout<View>>().FirstOrDefault(_ => _.IsVisible);
                    if (element != null)
                    {
                        element.Children.First().IsVisible = false;
                    }
                }
                catch (InvalidCastException ex) { }
            }
        }
    }
}