using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample
{
    public class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public ICommand CloseCommand { get; set; }

        public ICommand OpenCommand { get; set; }
        
        public ViewModel()
        {
            OpenCommand = new Command(OnOpen);
            CloseCommand = new Command(OnClose);
        }

        protected virtual void OnOpen()
        {
        }

        protected virtual void OnClose()
        {
        }

        protected async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected async Task NavigateTo(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        protected void Set<T>(string propertyName, ref T field, T value)
        {
            if (Equals(field, value)) return;
            field = value;

            NotifyPropertyChanged(propertyName);
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                RaisedPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] != null)
                return;

            var msg = $"Invalid property name. propertyName:{propertyName}.";
#if DEBUG
            throw new Exception(msg);
#else
            Debug.Fail(msg);
#endif
        }

        public void Dispose()
        {

        }
    }
}