using System;
using System.Windows.Input;
using Moq;
using NUnit.Framework;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms.Mocks;

namespace Smartway.UiComponent.UnitTests.Inputs.NumericDateInput
{
    public class NumericDateEntryTest
    {
        protected NumericDateEntry NumericDateEntry { get; set; }

        public NumericDateEntryTest()
        {
            MockForms.Init();
        }

        public void SetDateToDatepicker(string day, string month, string year)
        {
            NumericDateEntry.DayEntry.Text = day;
            NumericDateEntry.MonthEntry.Text = month;
            NumericDateEntry.YearEntry.Text = year;
        }
    }

    public class GetFilledDateTest : NumericDateEntryTest
    {
        private Mock<ICommand> ErrorCommandMock { get; set; }

        [SetUp]
        public void SetUp()
        {
            ErrorCommandMock = new Mock<ICommand>();
            NumericDateEntry = new NumericDateEntry
            {
                ErrorCommand = ErrorCommandMock.Object,
            };
        }

        [Test]
        public void FilledCorrect()
        {
            SetDateToDatepicker("10", "01", "22");
            ErrorCommandMock.Verify(mock => mock.Execute(It.IsAny<string>()), Times.Never());
        }

        [Theory]
        [TestCase("10", "90", "22")]
        [TestCase("31", "02", "22")]
        [TestCase("10", "02", "-1")]
        public void FilledUncorrectDate(string day, string month, string year)
        {
            SetDateToDatepicker(day, month, year);
            ErrorCommandMock.Verify(mock => mock.Execute(It.IsAny<Exception>()), Times.Once());
        }
    }
}
