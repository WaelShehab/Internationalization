using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
namespace Internationalization
{
    public class InteropSettings
    {
        public Action OnCultureChange { get; set; }
        public int Counter { get; set; }
        public void SetCultureLanguage(string language, IJSRuntime js)
        {
            //CultureInfo currentCulture = CultureInfo.GetCultureInfo(language);

            //CultureInfo.CurrentCulture = currentCulture;
            //CultureInfo.CurrentUICulture = currentCulture;

            //CultureInfo.DefaultThreadCurrentCulture = currentCulture;
            //CultureInfo.DefaultThreadCurrentUICulture = currentCulture;

            //System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = currentCulture;

            Counter++;

            var jSInProcessRuntime = (IJSInProcessRuntime)js;
            jSInProcessRuntime.InvokeVoid("setInLocalStorage", "culture", language);
            //navigationManager.NavigateTo(navigationManager.Uri, false);

            CultureInfo currentCulture = CultureInfo.GetCultureInfo(language);

            CultureInfo.DefaultThreadCurrentCulture = currentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = currentCulture;

            NotifyCultureChanged();
        }
        private void NotifyCultureChanged() => OnCultureChange?.Invoke();
    }
}
