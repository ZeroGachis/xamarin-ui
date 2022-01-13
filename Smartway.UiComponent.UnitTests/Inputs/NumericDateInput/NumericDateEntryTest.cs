using System;
using Xunit;
using System.Windows.Input;
using Moq;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms.Mocks;


namespace Smartway.UiComponent.UnitTests.Inputs.NumericDateEntryTest
{
    public class NumericDateEntryTest
    {
        protected NumericDateEntry _numericDateEntry { get; set; }

        public NumericDateEntryTest()
        {
            MockForms.Init();
        }

        public void SetDateToDatepicker(string day, string month, string year)
        {
            _numericDateEntry.DayEntry.Text = day;
            _numericDateEntry.MonthEntry.Text = month;
            _numericDateEntry.YearEntry.Text = year;
        }
    }

    public class GetFilledDateTest: NumericDateEntryTest
    {
        private Mock<ICommand> _errorCommandMock { get; set; }
        public GetFilledDateTest()
        {
            _errorCommandMock = new Mock<ICommand>();
            _numericDateEntry = new NumericDateEntry
            {
                ErrorCommand = _errorCommandMock.Object,
            };
        }

        [Fact]
        public void FilledCorrect()
        {
            SetDateToDatepicker("10", "01", "22");
            _errorCommandMock.Verify(mock => mock.Execute(It.IsAny<string>()), Times.Never());
        }

        [Theory]
        [InlineData("10", "90", "22")]
        [InlineData("31", "02", "22")]
        [InlineData("10", "02", "-1")]
        public void FilledUncorrectDate(string day, string month, string year)
        {
            SetDateToDatepicker(day, month, year);
            _errorCommandMock.Verify(mock => mock.Execute(It.IsAny<Exception>()), Times.Once());
        }
    }
}
