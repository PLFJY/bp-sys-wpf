using System.IO;
using System.Windows;

namespace bp_sys_wpf.ViewModel
{
    public class ComboBoxItemViewModel
    {
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

        private List<string> _MapPick;

        public List<string> MapPick
        {
            get
            {
                if (_MapPick == null)
                {
                    _MapPick = new List<string>();
                    _MapPick.Add("红教堂");
                    _MapPick.Add("湖景村");
                    _MapPick.Add("军工厂");
                    _MapPick.Add("里奥的回忆");
                    _MapPick.Add("圣心医院");
                    _MapPick.Add("唐人街");
                    _MapPick.Add("永眠镇");
                    _MapPick.Add("月亮河公园");
                }
                return _MapPick;
            }
            set { _MapPick = value; }
        }

        private List<string> _MapBan;

        public List<string> MapBan
        {
            get
            {
                if (_MapBan == null)
                {
                    _MapBan = new List<string>();
                    _MapBan.Add("无Ban");
                    _MapBan.Add("红教堂");
                    _MapBan.Add("湖景村");
                    _MapBan.Add("军工厂");
                    _MapBan.Add("里奥的回忆");
                    _MapBan.Add("圣心医院");
                    _MapBan.Add("唐人街");
                    _MapBan.Add("永眠镇");
                    _MapBan.Add("月亮河公园");
                }
                return _MapBan;
            }
            set { _MapBan = value; }
        }

        private List<string> _Trait;

        public List<string> Trait
        {
            get
            {
                if (_Trait == null)
                {
                    _Trait = new List<string>();
                    _Trait.Add("聆听");
                    _Trait.Add("失常");
                    _Trait.Add("兴奋");
                    _Trait.Add("巡视者");
                    _Trait.Add("传送");
                    _Trait.Add("窥视者");
                    _Trait.Add("闪现");
                    _Trait.Add("移形");
                }
                return _Trait;
            }
            set { _Trait = value; }
        }


        public List<string> LoadCharacters(string type)
        {
            GetFilePath getFilePath = new GetFilePath();
            string filePath = getFilePath.GetAbsoluteFilePath("CharactersList.txt"); // 角色数据文件的路径  
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
