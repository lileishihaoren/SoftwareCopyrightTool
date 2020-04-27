using System.IO;
using GalaSoft.MvvmLight;

namespace SoftwareCopyrightTool.Model
{
    public class MainModel: ObservableObject
    {
        private string _dirPath;
        private bool _isEnable;
        private string _fullText;

        public string DirPath
        {
            get => _dirPath;
            set
            {
                Set(ref _dirPath, value);
                IsEnable = Directory.Exists(value);
            }
        }

        public string FullText
        {
            get => _fullText;
            set => Set(ref _fullText, value);
        }

        public bool IsEnable
        {
            get => _isEnable;
            set => Set(ref _isEnable, value);
        }
    }
}
