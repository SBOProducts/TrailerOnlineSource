using DealerBLL.DiskManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.Themes
{
    public class ThemeRepository: IThemeRepository
    {
        IDirectoryInfo _directory;

        public ThemeRepository(IDirectoryInfo Directory)
        {
            _directory = Directory;
        }


        public int ThemeCount { get { return InstalledThemes.Count(); } }


        public IEnumerable<ThemeMetadata> InstalledThemes
        {
            get 
            {
                List<ThemeMetadata> themes = new List<ThemeMetadata>();

                foreach (string folder in _directory.GetSubfolderFullPaths())
                {
                    ThemeMetadata meta = new ThemeMetadata() { FolderPath = folder };
                    themes.Add(meta);
                }

                return themes;
            }
        }

    }
}
