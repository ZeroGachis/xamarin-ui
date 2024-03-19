using System;
using Xunit;
using System.Windows.Input;
using Moq;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms.Mocks;
using System.Globalization;
using System.Threading;
using NFluent;
using Smartway.UiComponent.UnitTests.Inputs.NumericDateInput;
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
        [InlineData("en-US", "DD", "MM", "YY")]
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
        [InlineData("en-US", "10", "06")]
        [InlineData("en-EN", "10", "06")]
        public void MonthDayOrderCulture(string culture, string expectedFirst, string expectedSecond)
        {
            SetCulture(culture);

            var entry = CreateNumericDateEntry("06", "10", "2022");

            CheckNumericDateEntry(entry, expectedFirst, expectedSecond, "2022");
        }

        [Theory]
        [InlineData("fr-FR", "th-TH", 2024, "67")]
        [InlineData("th-TH", "fr-FR", 2024, "81")]
        [InlineData("fr-FR", "fr-FR", 2024, "24")]
        [InlineData("th-TH", "th-TH", 2024, "24")]
        public void CustomCulturePlaceholder(string deviceCulture, string customCulture, int year, string expectedYear)
        {
            SetCulture(deviceCulture);

            var entry = new NumericDateEntry();
            entry.Culture = new CultureInfo(customCulture);
            entry.DatePlaceholder = new DateTime(year, 10, 6, Thread.CurrentThread.CurrentCulture.Calendar);

            Check.That(entry.DayEntry.Placeholder).IsEqualTo("06");
            Check.That(entry.MonthEntry.Placeholder).IsEqualTo("10");
            Check.That(entry.YearEntry.Placeholder).IsEqualTo(expectedYear);
        }

        [Theory]
        [InlineData("fr-FR", "th-TH", 2024, 2024)]
        [InlineData("th-TH", "fr-FR", 2024, 2024)]
        [InlineData("fr-FR", "fr-FR", 2024, 2024)]
        [InlineData("th-TH", "th-TH", 2024, 2024)]
        public void CustomCultureFilledDate(string deviceCulture, string customCulture, int year, int expectedYear)
        {
            SetCulture(deviceCulture);

            var entry = CreateNumericDateEntry("06", "10", year.ToString());
            entry.Culture = new CultureInfo(customCulture);

            var filledDate = entry.GetFilledDate();
            Check.That(filledDate.Day).IsEqualTo(6);
            Check.That(filledDate.Month).IsEqualTo(10);
            Check.That(filledDate.Year).IsEqualTo(expectedYear);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private TestableNumericDateEntry CreateNumericDateEntry(string day, string month, string year)
        {
            var numericDateEntry = new TestableNumericDateEntry
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
