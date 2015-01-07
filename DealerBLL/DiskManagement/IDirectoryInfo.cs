using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.DiskManagement
{
    public interface IDirectoryInfo
    {
        IEnumerable<string> GetSubfolderFullPaths();

        IEnumerable<string> GetFiles();

        IEnumerable<string> GetSubfolderNames();
    }
}
