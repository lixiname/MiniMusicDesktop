
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private CultureEnum _selectedIndex;
        public CultureEnum SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedIndex, value);
                _changeCurrentCulture();

            }
        }

        private void _changeCurrentCulture()
        {
            string culture;
            if(SelectedIndex== CultureEnum.zh_Hans)
            {
                culture = CultureConstant.zh_Hans;
                Assets.Resources.Culture = new CultureInfo("zh-cn");
                
                Console.WriteLine("change china");
            }
            else if (SelectedIndex == CultureEnum.zh_HK)
            {
                Assets.Resources.Culture = new CultureInfo("zh-cn");
                Console.WriteLine("change china");
                culture = CultureConstant.zh_HK;
            }
            else if (SelectedIndex == CultureEnum.en_US)
            {
                culture = CultureConstant.en_US;
            }
            else if (SelectedIndex == CultureEnum.fr_FR)
            {
                culture = CultureConstant.fr_FR;
            }
            else  
            {
                culture = CultureConstant.ru_RU;
            }
            var ls = Assets.Resources.Culture;
            CultureInfo newCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            Assembly asm = Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("MiniMusicDesktop.Languages",
                                                     typeof(LanguageViewModel).Assembly);
            LanguagesSettings = String.Format("{0}", rm.GetString("LanguagesSettings"));
        }

        

        public LanguageViewModel()
        {
            _selectedIndex = 0;
            string[] cultures = { "en-US", "fr-FR", "ru-RU", "zh-Hans" , "ja-JP" };
            //string[] cultures = { "fr-FR", "ru-RU" };
            Random rnd = new Random();
            int cultureNdx = rnd.Next(0, cultures.Length);
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                
                //CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);
                //Thread.CurrentThread.CurrentCulture = newCulture;
                //Thread.CurrentThread.CurrentUICulture = newCulture;
                //Assembly asm = Assembly.GetExecutingAssembly();
                //ResourceManager rm = new ResourceManager("MiniMusicDesktop.Languages",
                //                                         typeof(LanguageViewModel).Assembly);
                //string greeting = String.Format("The current culture is {0}.\n {1}",
                //                                Thread.CurrentThread.CurrentUICulture.Name,
                //                                rm.GetString("LanguagesSettings"));
                //LanguagesSettings = String.Format("{0}", rm.GetString("LanguagesSettings"));
                //Console.WriteLine(greeting);
            }
            catch (CultureNotFoundException e)
            {
                Debug.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
            }
            finally
            {
                //Thread.CurrentThread.CurrentCulture = originalCulture;
                //Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }
    }
}
