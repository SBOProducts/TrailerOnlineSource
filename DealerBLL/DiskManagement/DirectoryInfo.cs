using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.DiskManagement
{
    public class DirectoryInfo: IDirectoryInfo
    {
        System.IO.DirectoryInfo _directoryInfo;

        public DirectoryInfo(string DirectoryPath)
        {
            _directoryInfo = new System.IO.DirectoryInfo(DirectoryPath);
        }

        public IEnumerable<string> GetSubfolderFullPaths()
        {
            return _directoryInfo.GetDirectories().Select(d => d.FullName);
        }

        public IEnumerable<string> GetSubfolderNames()
        {
            return _directoryInfo.GetDirectories().Select(d => d.Name);
        }

        public IEnumerable<string> GetFiles()
        {
            return _directoryInfo.GetFiles().Select(f => f.FullName);
        }

        
    }
}
