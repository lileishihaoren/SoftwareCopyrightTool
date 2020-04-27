using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Panuon.UI.Silver;
using SoftwareCopyrightTool.Model;

namespace SoftwareCopyrightTool.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private MainModel _main=new MainModel();

        public MainModel Main
        {
            get => _main;
            set => Set(ref _main, value);
        }

        public MainViewModel()
        {
        }

        public ICommand CmdGen
        {
            get { return new RelayCommand(new Action(() =>
            {
                var di=new DirectoryInfo(Main.DirPath);
                var fileInfos = di.GetFiles("*.cs", SearchOption.AllDirectories);
                var lines=new List<string>();
                foreach (var fileInfo in fileInfos)
                {
                    lines.AddRange(ProcessOneFile(fileInfo));
                }

                var fullText = string.Join("\r\n", lines);
                Main.FullText = fullText;
                Clipboard.SetText(fullText);
                MessageBoxX.Show("Copy to clipboard");

            })); }
        }

        private List<string> ProcessOneFile(FileInfo fileInfo)
        {
            List<string> retList = new List<string>();
            string[] content = File.ReadAllLines(fileInfo.FullName);

            bool continueRemark = false;
            foreach (var line in content)
            {
                var newline = Regex.Replace(line, "//.*|/\\*.*\\*/", "");
                //×¢ÊÍ¡¢¿ÕÐÐ¡¢Á¬Ðø×¢ÊÍ
                if (newline.Contains("/*"))
                {
                    continueRemark = true;
                    continue;
                }
                if (continueRemark && newline.Contains("*/"))
                {
                    continueRemark = false;
                    continue;
                }
                if (continueRemark)
                {
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(newline))
                {
                    retList.Add(newline);
                }
            }
            return retList;
        }
    }
}