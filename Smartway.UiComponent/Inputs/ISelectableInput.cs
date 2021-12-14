using System;

namespace Smartway.UiComponent.Inputs
{
    public interface ISelectableInput
    {
        bool IsSelected { get; set; }

        event EventHandler OnSelected;
    }
}
