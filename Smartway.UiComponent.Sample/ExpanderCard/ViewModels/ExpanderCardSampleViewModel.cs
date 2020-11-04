using System.Collections.ObjectModel;
using Smartway.UiComponent.Cards;

namespace Smartway.UiComponent.Sample.ExpanderCard.ViewModels
{
    class ExpanderCardSampleViewModel : ViewModel
    {
        public ExpanderCardSampleViewModel()
        {
            Articles = new ObservableCollection<object>();
            for (var i = 0; i < 50; i++)
            {
                Articles.Add(new DummyArticle
                {
                    Label = "Article "+i,
                    IsMultilocation = true,
                    IsOnShortage = true,
                    Price = "0,3€",
                    Gencode = "1234567891234",
                    NavigationParameter = "Article 5"
                });
            }                  
        }

        public ObservableCollection<object> Articles { get; set; }
    }
}
