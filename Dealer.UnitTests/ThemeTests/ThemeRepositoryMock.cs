using DealerBLL.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.UnitTests.ThemeTests
{
    class ThemeRepositoryMock: IThemeRepository
    {


        public IEnumerable<ThemeBO> InstalledThemes
        {
            get 
            {
                List<ThemeBO> themes = new List<ThemeBO>();
                themes.Add(new ThemeBO() { Author = "Nate", Description = "First", Name = "First", TargetWebsiteVersion = 1 });
                themes.Add(new ThemeBO() { Author = "Bob", Description = "Second", Name = "Second", TargetWebsiteVersion = 2 });
                themes.Add(new ThemeBO() { Author = "Sara", Description = "Third", Name = "Third", TargetWebsiteVersion = 3 });
                return themes as IEnumerable<ThemeBO>;
            
            }
        }
    }
}
