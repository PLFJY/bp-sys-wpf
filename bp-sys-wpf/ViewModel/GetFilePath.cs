using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf.ViewModel
{
    public class GetFilePath
    {
        public string GetAbsoluteFilePath(string path)
        {
            // 获取应用程序的运行目录  
            string appDir = Environment.CurrentDirectory; // 在WPF中可以使用Environment.CurrentDirectory获取当前目录  
                                                          // 拼接路径获取绝对路径  
            string absoluteFilePath = Path.Combine(appDir, path);
            return absoluteFilePath;
        }

        public string GetComboBoxItemContent(string selectedValue)
        {
            int spaceIndex = selectedValue.IndexOf(' ');
            selectedValue = selectedValue.Substring(spaceIndex + 1);
            if(selectedValue == "")
            {
                return null;
            }
            else
            {
                return selectedValue;
            }
        }
        public BitmapImage GetImage(string type, string selectedValue)
        {
            if(selectedValue != "" && selectedValue != null)
            {
                return new BitmapImage(new Uri(GetAbsoluteFilePath("pic/" + type + "/" + selectedValue + ".png")));
            }
            else
            {
                return null;
            }
        }
    }
}
