using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bp_sys_wpf.ViewModel
{
    public class ComboBoxItemViewModel
    {
        GetFilePath GetFilePath = new GetFilePath();

        private List<string> _hun;

        public List<string> hun
        {
            get
            {
                if (_hun == null)
                {
                    _hun = new List<string>();
                    _hun = LoadCharacters("hun");
                }
                return _hun;
            }
            set { _hun = value; }
        }

        private List<string> _sur;

        public List<string> sur
        {
            get
            {
                if (_sur == null)
                {
                    _sur = new List<string>();
                    _sur = LoadCharacters("sur");
                }
                return _sur;
            }
            set { _sur = value; }
        }


        public List<string> LoadCharacters(string type)
        {
            string filePath = GetFilePath.GetAbsoluteFilePath("CharactersList.txt"); // 角色数据文件的路径  
            if (!File.Exists(filePath))
            {
                MessageBox.Show("未找到角色列表文件CharactersList.txt", "错误");
                Environment.Exit(0);
            }

            // 读取文件的所有行  
            string[] lines = File.ReadAllLines(filePath);

            // 创建一个字典用于存储角色列表  
            Dictionary<string, List<string>> characterLists = new Dictionary<string, List<string>>();

            // 遍历文件的每一行  
            foreach (string line in lines)
            {
                // 使用冒号分割键和值  
                string[] parts = line.Trim().Split(':');
                if (parts.Length == 2)
                {
                    // 获取键，并去除两边的空白字符  
                    string key = parts[0].Trim();

                    // 获取值，并去除两边的空白字符，以及开头和结尾的大括号  
                    string valueStr = parts[1].Trim();
                    valueStr = valueStr.TrimStart('{').TrimEnd('}');

                    // 使用逗号分割字符串得到角色列表  
                    string[] characters = valueStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // 将字符串数组转换为List，并对列表中的项目进行排序  
                    List<string> sortedCharacters = characters.ToList().OrderBy(c => c).ToList();

                    // 将排序后的角色列表添加到字典中  
                    characterLists[key] = sortedCharacters;
                }
            }
            //返回字典
            return characterLists[type];
        }
    }
}
