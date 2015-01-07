using DealerBLL.Themes;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.UnitTests.ThemeTests
{
    public class ThemeModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IThemeManager>().To<ThemeManager>();
            
        }
    }
}
