namespace Smartway.UiComponent.Services
{
    public interface IPlatormInfoProvider
    {
        /// <summary>
        /// Return current os sdk version
        /// </summary>
        int OsSdkVersion { get; }
    }
}