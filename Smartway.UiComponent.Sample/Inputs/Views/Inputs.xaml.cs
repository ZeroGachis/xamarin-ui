using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Sample.Inputs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inputs
    {
        public Inputs()
        {
            InitializeComponent();
        }

        private void NumericDateEntry_OnCleared(object sender, EventArgs e)
        {
            Console.WriteLine("Date cleared");
        }
    }
}