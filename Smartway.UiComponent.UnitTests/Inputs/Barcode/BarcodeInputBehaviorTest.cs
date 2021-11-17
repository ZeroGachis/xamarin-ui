using System.Windows.Input;
using Moq;
using NFluent;
using Smartway.UiComponent.Inputs.Barcode;
using Xamarin.Forms;
using Xunit;

namespace Smartway.UiComponent.UnitTests.Inputs.Barcode
{
    public class BarcodeInputBehaviorTest
    {
        public BarcodeInputBehaviorTest()
        {
            Command = new Mock<ICommand>();
            Behavior = new BarcodeInputBehavior();
            Behavior.Command = Command.Object;
            Entry = new Entry();
            Entry.Behaviors.Add(Behavior);
        }

        public Mock<ICommand> Command { get; set; }

        public Entry Entry { get; set; }

        public BarcodeInputBehavior Behavior { get; set; }
    }

    public class OnTextChanged : BarcodeInputBehaviorTest
    {
        [Fact]
        public void ValidGencodeFilled()
        {
            Entry.Text = "2970812075764";
            
            Check.That(Entry.Text).IsEqualTo("2970812075764");
            Command.Verify(_ => _.Execute("2970812075764"), Times.Once);
        }

        [Fact]
        public void UnvalidGencodeFilled()
        {
            Entry.Text = "297081207576";
            Entry.Text = "2970812075765";
            
            Check.That(Entry.Text).IsEqualTo("297081207576");
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GencodeNotTotallyFilled()
        {
            Entry.Text = "297081207";

            Check.That(Entry.Text).IsEqualTo("297081207");
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GencodeFilledWithNotDigitChar()
        {
            Entry.Text = "x";

            Check.That(Entry.Text).IsEqualTo(null);
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GencodeFilledBigLength()
        {
            Entry.Text = "29708120757644";

            Check.That(Entry.Text).IsEqualTo(null);
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }
    }
}
