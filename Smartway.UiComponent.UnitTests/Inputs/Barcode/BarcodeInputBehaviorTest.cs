using System.Windows.Input;
using Moq;
using NFluent;
using Smartway.UiComponent.Inputs.Barcode;
using Xamarin.Forms;
using NUnit;
using NUnit.Framework;

namespace Smartway.UiComponent.UnitTests.Inputs.Barcode
{
    public class BarcodeInputBehaviorTest
    {
        [SetUp]
        public void SetUp()
        {
            Command = new Mock<ICommand>();
            Command.Setup(_ => _.CanExecute(It.IsAny<object>())).Returns(true);
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
        [Test]
        public void ValidGencodeFilled()
        {
            Entry.Text = "2970812075764";
            
            Check.That(Entry.Text).IsEqualTo("2970812075764");
            Command.Verify(_ => _.Execute("2970812075764"), Times.Once);
        }

        [Test]
        public void UnvalidGencodeFilled()
        {
            Entry.Text = "297081207576";
            Entry.Text = "2970812075765";
            
            Check.That(Entry.Text).IsEqualTo("297081207576");
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void GencodeNotTotallyFilled()
        {
            Entry.Text = "297081207";

            Check.That(Entry.Text).IsEqualTo("297081207");
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void GencodeFilledWithNotDigitChar()
        {
            Entry.Text = "x";

            Check.That(Entry.Text).IsEqualTo(null);
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void GencodeFilledBigLength()
        {
            Entry.Text = "29708120757644";

            Check.That(Entry.Text).IsEqualTo(null);
            Command.Verify(_ => _.Execute(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CanExecuteIsFalse()
        {
            Command.Setup(_ => _.CanExecute(It.IsAny<object>())).Returns(false);

            Entry.Text = "2970812075764";

            Check.That(Entry.Text).IsEqualTo("2970812075764");
            Command.Verify(_ => _.Execute(It.IsAny<object>()), Times.Never);
        }
    }
}
