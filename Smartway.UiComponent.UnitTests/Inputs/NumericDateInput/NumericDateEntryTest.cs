using System;
using Xunit;
using System.Windows.Input;
using Moq;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms.Mocks;
using System.Globalization;
using System.Threading;
using NFluent;
using Xamarin.Forms;


namespace Smartway.UiComponent.UnitTests.Inputs.NumericDateEntryTest
{
    public class NumericDateEntryTest
    {
        private Mock<ICommand> _errorCommandMock { get; set; }

        public NumericDateEntryTest()
        {
            MockForms.Init();
            _errorCommandMock = new Mock<ICommand>();
        }

        [Fact]
        public void FilledCorrect()
        {
            CreateNumericDateEntry("10", "01", "22");
            _errorCommandMock.Verify(mock => mock.Execute(It.IsAny<string>()), Times.Never());
        }

        [Theory]
        [InlineData("10", "90", "22")]
        [InlineData("31", "02", "22")]
        [InlineData("10", "02", "-1")]
        public void FilledUncorrectDate(string day, string month, string year)
        {
            CreateNumericDateEntry(day, month, year);
            _errorCommandMock.Verify(mock => mock.Execute(It.IsAny<Exception>()), Times.Once());
        }

        [Theory]
        [InlineData("fr-FR", "JJ", "MM", "AA")]
        [InlineData("es-ES", "JJ", "MM", "AA")]
        [InlineData("it-IT", "JJ", "MM", "AA")]
        [InlineData("ru-RU", "JJ", "MM", "AA")]
        [InlineData("ro-RO", "JJ", "MM", "AA")]
        [InlineData("us-US", "DD", "MM", "YY")]
        [InlineData("en-EN", "DD", "MM", "YY")]
        public void DefaultPlaceholder(string culture, string day, string month, string year)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            var numericDateEntry = new NumericDateEntry();

            Check.That(numericDateEntry.DayEntry.Placeholder).IsEqualTo(day);
            Check.That(numericDateEntry.MonthEntry.Placeholder).IsEqualTo(month);
            Check.That(numericDateEntry.YearEntry.Placeholder).IsEqualTo(year);
        }

        [Theory]
        [InlineData("fr-FR", "06", "10")]
        [InlineData("es-ES", "06", "10")]
        [InlineData("it-IT", "06", "10")]
        [InlineData("ro-RO", "06", "10")]
        [InlineData("ru-RU", "06", "10")]
        [InlineData("us-US", "10", "06")]
        [InlineData("en-EN", "10", "06")]
        public void MonthDayOrderCulture(string culture, string expectedFirst, string expectedSecond)
        {
            SetCulture(culture);

            var entry = CreateNumericDateEntry("06", "10", "2022");

            CheckNumericDateEntry(entry, expectedFirst, expectedSecond, "2022");
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private NumericDateEntry CreateNumericDateEntry(string day, string month, string year)
        {
            var numericDateEntry = new NumericDateEntry
            {
                ErrorCommand = _errorCommandMock.Object
            };

            numericDateEntry.DayEntry.Text = day;
            numericDateEntry.MonthEntry.Text = month;
            numericDateEntry.YearEntry.Text = year;

            return numericDateEntry;
        }

        private void CheckNumericDateEntry(NumericDateEntry entry, string expectedFirst, string expectedSecond, string expectedThird)
        {
            CheckEntry(entry, "FirstEntry", expectedFirst);
            CheckEntry(entry, "SecondEntry", expectedSecond);
            CheckEntry(entry, "ThirdEntry", expectedThird);
        }

        private void CheckEntry(NumericDateEntry entry, string name, string expectedValue)
        {
            var value = (Entry)entry.FindByName(name);
            Check.That(value.Text).IsEqualTo(expectedValue);
        }
    }
}
