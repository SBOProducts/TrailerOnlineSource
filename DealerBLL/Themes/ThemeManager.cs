using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.Themes
{
    public class ThemeManager: IThemeManager
    {

        IThemeRepository _themeRepository;

        public ThemeManager(IThemeRepository ThemeRepository)
        {
            _themeRepository = ThemeRepository;
        }

        public int InstalledThemeCount()
        {
            return _themeRepository.ThemeCount;
        }

        public IEnumerable<ThemeMetadata> GetAllInstalledThemes()
        {
            return _themeRepository.InstalledThemes;
        }
    }
}
