using System;
using System.Collections.Generic;
using System.Text;
using Smartway.UiComponent.Inputs;

namespace Smartway.UiComponent.UnitTests.Inputs.NumericDateInput
{
    class TestableNumericDateEntry: NumericDateEntry
    {
        public new DateTime GetFilledDate() => base.GetFilledDate();
    }
}
