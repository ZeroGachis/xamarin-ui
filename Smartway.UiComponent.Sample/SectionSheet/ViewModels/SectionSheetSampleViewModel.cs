using System.Collections.ObjectModel;

namespace Smartway.UiComponent.Sample.SectionSheet.ViewModels
{
    class SectionSheetSampleViewModel: ViewModel
    {
        public ObservableCollection<object> Articles => new ObservableCollection<object>
        {
            new DummyArticle
            {
                Label = "Article 1",
                IsMultilocation = true,
                IsOnShortage = true,
                Price = "0,3€",
                Gencode = "1234567891234",
                NavigationParameter = "Article 1"
            }, new DummyArticle
            {
                Label = "Article 2",
                IsMultilocation = false,
                IsOnShortage = false,
                Price = "12.39€",
                Gencode = "1234567891234",
                NavigationParameter = "Article 2",
                Status = "Monitored"
            }, new DummyArticle
            {
                Label = "Article 3",
                IsMultilocation = false,
                IsOnShortage = true,
                Price = "0,3€",
                Gencode = "1234567891234",
                NavigationParameter = "Article 3"
            }, new DummyArticle
            {
                Label = "Article 4",
                IsMultilocation = true,
                IsOnShortage = false,
                Price = "0,3€",
                Gencode = "1234567891234",
                NavigationParameter = "Article 4",
                Status = "Unmonitored"
            }, new DummyArticle
            {
                Label = "Article 5",
                IsMultilocation = true,
                IsOnShortage = false,
                Price = "0,3€",
                Gencode = "1234567891234",
                NavigationParameter = "Article 5"
            },
        };
    }
}
