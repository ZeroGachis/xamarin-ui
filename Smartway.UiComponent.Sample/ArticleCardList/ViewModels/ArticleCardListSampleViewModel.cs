using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.ArticleCardList.ViewModels
{
    class ArticleCardListSampleViewModel
    {
        public ObservableCollection<object> Articles { get; set; }

        public ArticleCardListSampleViewModel()
        {
            Articles = new ObservableCollection<object>();
            Articles.Add(new DummyArticle
            {
                Label = "Article 1",
                IsMultilocation = true,
                IsOnShortage = true,
                Price = "0,3€",
                Gencode = "12345678912341",
                NavigationParameter = "Article 1"
            });
            Articles.Add(new DummyArticle
            {
                Label = "Article 2",
                IsMultilocation = false,
                IsOnShortage = false,
                Price = "12.39€",
                Gencode = "12345678912342",
                NavigationParameter = "Article 2",
                Status = "Monitored"
            });
            Articles.Add(new DummyArticle
            {
                Label = "Article 3",
                IsMultilocation = false,
                IsOnShortage = true,
                Price = "0,3€",
                Gencode = "12345678912343",
                NavigationParameter = "Article 3"
            });
            Articles.Add(new DummyArticle
            {
                Label = "Article 4",
                IsMultilocation = true,
                IsOnShortage = false,
                Price = "0,3€",
                Gencode = "12345678912344",
                NavigationParameter = "Article 4",
                Status = "Unmonitored"
            });
            Articles.Add(new DummyArticle
            {
                Label = "Article 5",
                IsMultilocation = true,
                IsOnShortage = false,
                Price = "0,3€",
                Gencode = "12345678912345",
                NavigationParameter = "Article 5"
            });
        }

        public ICommand DeleteArticle => new Command(async gencode =>
        {
            foreach (var article in Articles.ToArray())
                if (((DummyArticle)article).Gencode == gencode)
                    Articles.Remove(article);
        });
    }
}
