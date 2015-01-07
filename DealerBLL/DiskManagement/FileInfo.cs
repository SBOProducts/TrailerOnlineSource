using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.DiskManagement
{
    public class FileInfo: IFileInfo
    {

        System.IO.FileInfo _fileInfo;

        public FileInfo(string FilePath)
        {
            _fileInfo = new System.IO.FileInfo(FilePath);
        }

        public string ReadAllText()
        {
            return System.IO.File.ReadAllText(_fileInfo.FullName);
        }
    }
}
