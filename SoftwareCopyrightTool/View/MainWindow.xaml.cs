using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareCopyrightTool.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Link;
                e.Handled = true;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void UIElement_OnPreviewDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Any())
            {
                var txt = string.Empty;
                var f = files.First();
                if (File.Exists(f))
                {
                    txt = Path.GetDirectoryName(f);
                }
                else if (Directory.Exists(f))
                {
                    txt = f;
                }

                if (!string.IsNullOrWhiteSpace(txt))
                {
                    ((TextBox)sender).Text = txt;
                }
            }
        }
    }
}
