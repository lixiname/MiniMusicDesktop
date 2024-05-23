using Avalonia.Media.Imaging;
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class DownLoadMusicItemViewModel : ViewModelBase
    {
        
        public DownLoadMusicItemViewModel(string fileName, string fileSizeInBytes)
        {
            _fileName = fileName;
            _fileSizeInBytes = fileSizeInBytes;
        }
        string _fileName;

        string _fileSizeInBytes;
       
        public string FileName=>_fileName;

        public string FileSizeInBytes=> _fileSizeInBytes;

        public string Size => readSize();


        private string readSize()
        {
            return 3.ToString();
        }
    }
}
