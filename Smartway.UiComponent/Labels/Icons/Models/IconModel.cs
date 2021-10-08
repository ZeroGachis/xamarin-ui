namespace Smartway.UiComponent.Labels.Icons.Models
{
    public abstract class IconModel
    {
        protected IconModel(Icon.IconNames name, string code, string fontFamily)
        {
            Name = name;
            Code = code;
            FontFamily = fontFamily;
        }

        public Icon.IconNames Name { get; }

        public string Code { get; }

        public string FontFamily { get; }
    }
}
