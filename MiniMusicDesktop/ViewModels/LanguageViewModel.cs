
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class LanguageViewModel : ViewModelBase
    {
        private string _languageSettings;
        public string LanguagesSettings
        {
            get => _languageSettings;
            set => this.RaiseAndSetIfChanged(ref _languageSettings, value);
        }
        public LanguageViewModel()
        {

            string[] cultures = { "en-US", "fr-FR", "ru-RU", "zh-Hans" , "ja-JP" };
            //string[] cultures = { "fr-FR", "ru-RU" };
            Random rnd = new Random();
            int cultureNdx = rnd.Next(0, cultures.Length);
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;
                Assembly asm = Assembly.GetExecutingAssembly();
                ResourceManager rm = new ResourceManager("MiniMusicDesktop.Languages",
                                                         typeof(LanguageViewModel).Assembly);
                string greeting = String.Format("The current culture is {0}.\n {1}",
                                                Thread.CurrentThread.CurrentUICulture.Name,
                                                rm.GetString("LanguagesSettings"));
                LanguagesSettings = greeting;

               var s= MiniMusicDesktop.Properties.Resources.String1;
              

                Console.WriteLine(greeting);
            }
            catch (CultureNotFoundException e)
            {
                Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }
    }
}
