using NFluent;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms.Mocks;
using Xunit;

namespace Smartway.UiComponent.UnitTests.Inputs
{
    public class NumericInputTest
    {
        public NumericInputTest()
        {
            MockForms.Init();
            NumericInput = new NumericInput();
        }

        public NumericInput NumericInput { get; set; }

        [Fact]
        public void ValidNumericInputFilled()
        {
            NumericInput.Entry.Text = "2";
            NumericInput.Entry.Text = "23";
            Check.That(NumericInput.Entry.Text).Equals("23");
        }

        [Fact]
        public void InvalidNumericInputWithCommaFilled()
        {
            NumericInput.Entry.Text = "23";
            NumericInput.Entry.Text = "23,";
            Check.That(NumericInput.Entry.Text).Equals("23");
        }

        [Fact]
        public void InvalidNumericInputWithDotFilled()
        {
            NumericInput.Entry.Text = "23";
            NumericInput.Entry.Text = "23.";
            Check.That(NumericInput.Entry.Text).Equals("23");
        }

        [Fact]
        public void InvalidNumericInputWithSpaceFilled()
        {
            NumericInput.Entry.Text = "23";
            NumericInput.Entry.Text = "23 ";
            Check.That(NumericInput.Entry.Text).Equals("23");
        }

        [Fact]
        public void InvalidNumericInputWithHyphenFilled()
        {
            NumericInput.Entry.Text = "23";
            NumericInput.Entry.Text = "23-";
            Check.That(NumericInput.Entry.Text).Equals("23");
        }

        [Fact]
        public void NoInputFilled()
        {
            NumericInput.Entry.Text = "2";
            NumericInput.Entry.Text = "";
            Check.That(NumericInput.Entry.Text).Equals("");
        }

        [Fact]
        public void NullInputFilled()
        {
            NumericInput.Entry.Text = "2";
            NumericInput.Input = null;
            Check.That(NumericInput.Entry.Text).IsNull();
        }
    }
}
