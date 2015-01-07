using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.Themes
{
    public interface IThemeRepository
    {

        int ThemeCount { get; }

        IEnumerable<ThemeMetadata> InstalledThemes { get; }

    }
}
