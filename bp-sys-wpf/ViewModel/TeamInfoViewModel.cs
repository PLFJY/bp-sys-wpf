using bp_sys_wpf.Model;
using bp_sys_wpf.Views.Windows;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf.ViewModel
{
    public class TeamInfoViewModel : INotifyPropertyChanged
    {
        private int NowMainPlayerAccount = 0, NowAwayPlayerAccount = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private NowModel _NowModel = new NowModel();

        public NowModel NowModel
        {
            get { return _NowModel; }
            set
            {
                _NowModel = value;
                if (TeamInfoModel.MainTeamInfo.State == "监管者")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        NowModel.NowSurPlayerId[i] = $"{TeamInfoModel.AwayTeamInfo.Name}__{NowModel.NowPlayer[i]}";
                    }
                    NowModel.NowHunPlayerId = $"{TeamInfoModel.MainTeamInfo.Name}__{NowModel.NowPlayer[4]}";
                }
                if (TeamInfoModel.AwayTeamInfo.State == "监管者")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        NowModel.NowSurPlayerId[i] = $"{TeamInfoModel.MainTeamInfo.Name}__{NowModel.NowPlayer[i]}";
                    }
                    NowModel.NowHunPlayerId = $"{TeamInfoModel.AwayTeamInfo.Name}__{NowModel.NowPlayer[4]}";
                }
                RaisePropertyChanged("NowModel");
            }
        }

        private TeamInfoModel _TeamInfoModel;

        public TeamInfoModel TeamInfoModel//连接TeamInfoModel创建实例
        {
            get
            {
                if (_TeamInfoModel == null)//初始化
                {
                    _TeamInfoModel = new TeamInfoModel();
                    for (int i = 0; i < 9; i++)//选手列表阵营初始化
                    {
                        if (i < 6)
                        {
                            _TeamInfoModel.MainTeamPlayer.Add(new Player
                            {
                                State = "求生者"
                            });
                            _TeamInfoModel.AwayTeamPlayer.Add(new Player
                            {
                                State = "求生者"
                            });
                        }
                        else
                        {
                            _TeamInfoModel.MainTeamPlayer.Add(new Player
                            {
                                State = "监管者"
                            });
                            _TeamInfoModel.AwayTeamPlayer.Add(new Player
                            {
                                State = "监管者"
                            });
                        }
                    }
                    _TeamInfoModel.MainTeamInfo.State = "求生者";//队伍阵营初始化
                    _TeamInfoModel.AwayTeamInfo.State = "监管者";
                }
                if (_TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    NowModel.NowSurTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    NowModel.NowHunTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                    NowModel.NowSurTeam.LOGO = _TeamInfoModel.MainTeamInfo.LOGO;
                    NowModel.NowHunTeam.LOGO = _TeamInfoModel.AwayTeamInfo.LOGO;
                    NowModel.NowSurTeam.Score = _TeamInfoModel.MainTeamInfo.Score;
                    NowModel.NowHunTeam.Score = _TeamInfoModel.AwayTeamInfo.Score;
                }
                else
                {
                    NowModel.NowHunTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    NowModel.NowSurTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                    NowModel.NowSurTeam.LOGO = _TeamInfoModel.AwayTeamInfo.LOGO;
                    NowModel.NowHunTeam.LOGO = _TeamInfoModel.MainTeamInfo.LOGO;
                    NowModel.NowHunTeam.Score = _TeamInfoModel.MainTeamInfo.Score;
                    NowModel.NowSurTeam.Score = _TeamInfoModel.AwayTeamInfo.Score;
                }
                return _TeamInfoModel;
            }
            set
            {
                _TeamInfoModel = value;
                if (_TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    NowModel.NowSurTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    NowModel.NowHunTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                    NowModel.NowSurTeam.LOGO = _TeamInfoModel.MainTeamInfo.LOGO;
                    NowModel.NowHunTeam.LOGO = _TeamInfoModel.AwayTeamInfo.LOGO;
                    NowModel.NowSurTeam.Score = _TeamInfoModel.MainTeamInfo.Score;
                    NowModel.NowHunTeam.Score = _TeamInfoModel.AwayTeamInfo.Score;
                }
                else
                {
                    NowModel.NowHunTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    NowModel.NowSurTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                    NowModel.NowSurTeam.LOGO = _TeamInfoModel.AwayTeamInfo.LOGO;
                    NowModel.NowHunTeam.LOGO = _TeamInfoModel.MainTeamInfo.LOGO;
                    NowModel.NowHunTeam.Score = _TeamInfoModel.MainTeamInfo.Score;
                    NowModel.NowSurTeam.Score = _TeamInfoModel.AwayTeamInfo.Score;
                }
                RaisePropertyChanged("TeamInfoModel");
            }
        }

        private TeamInfoPageButtonModel _ButtonState;

        public TeamInfoPageButtonModel ButtonState
        {
            get
            {
                if (_ButtonState == null)
                {
                    _ButtonState = new TeamInfoPageButtonModel();
                    for (int i = 0; i < 9; i++)
                    {
                        _ButtonState.MainButtonState.Add(new TeamInfoPageButton());
                        _ButtonState.AwayButtonState.Add(new TeamInfoPageButton());
                    }
                }
                return _ButtonState;
            }
            set
            {
                _ButtonState = value;
                RaisePropertyChanged("ButtonState");
            }
        }
        public string OpenImageFileDialog()//打开通用对话框选取图片
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件|*.png;*.jpg"; // 设置过滤器只显示 PNG 和 JPG 文件  
            openFileDialog.Multiselect = false; // 设置只能选择一个文件  

            if (openFileDialog.ShowDialog() == true)
            {
                string FilePath = openFileDialog.FileName; // 获取选定的文件路径
                Debug.WriteLine(FilePath);
                return FilePath;
            }
            return "0";
        }
        public void SetTeamLOGO(string type)
        {
            string logo = OpenImageFileDialog();
            if (logo != "0")
            {
                if (type == "main")
                {
                    TeamInfoModel.MainTeamInfo.LOGO = new BitmapImage(new Uri(logo));
                }
                if (type == "away")
                {
                    TeamInfoModel.AwayTeamInfo.LOGO = new BitmapImage(new Uri(logo));
                }
                TeamInfoModel = TeamInfoModel;
            }
        }
        public void PlayersTakeTheField(int number, string team, string type)//选手上场
        {
            if (type == "求生者")//传入的上场选手为求生
            {
                if (team == "Main")
                {
                    //切换上场状态
                    TeamInfoModel.MainTeamPlayer[number].IsPlayerTakeTheField = true;
                    //按钮样式更改
                    ButtonState.MainButtonState[number].Content = "下场";
                    ButtonState.MainButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowDownload24 };
                    ButtonState.MainButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFF0000"));
                    //增加上场选手计数器
                    NowMainPlayerAccount++;
                    //同步到当前上场列表
                    for (int i = 0; i < 5; i++)
                    {
                        if (TeamInfoModel.MainTeamInfo.State == "求生者" && NowModel.NowPlayer[i] == "")
                        {
                            NowModel.NowPlayer[i] = TeamInfoModel.MainTeamPlayer[number].Name;
                            break;
                        }
                    }

                }
                if (team == "Away")
                {
                    //切换上场状态
                    TeamInfoModel.AwayTeamPlayer[number].IsPlayerTakeTheField = true;
                    //按钮样式更改
                    ButtonState.AwayButtonState[number].Content = "下场";
                    ButtonState.AwayButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowDownload24 };
                    ButtonState.AwayButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFF0000"));
                    //增加上场选手计数器
                    NowAwayPlayerAccount++;
                    for (int i = 0; i < 5; i++)
                    {
                        //同步到当前上场列表
                        if (TeamInfoModel.AwayTeamInfo.State == "求生者" && NowModel.NowPlayer[i] == "")
                        {
                            NowModel.NowPlayer[i] = TeamInfoModel.AwayTeamPlayer[number].Name;
                            break;
                        }
                    }
                }
                //判断满员，禁用上场按钮
                if (NowMainPlayerAccount >= 4)//主队满员
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ButtonState.MainButtonState[j].Content == "上场")
                        {
                            ButtonState.MainButtonState[j].IsEnabled = false;//禁用按钮
                        }
                    }
                }
                if (NowAwayPlayerAccount >= 4)//客队满员
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ButtonState.AwayButtonState[j].Content == "上场")
                        {
                            ButtonState.AwayButtonState[j].IsEnabled = false;//禁用按钮
                        }
                    }
                }
            }
            else//传入的上场选手为监管
            {
                if (team == "Main")
                {
                    //切换上场状态
                    TeamInfoModel.MainTeamPlayer[number].IsPlayerTakeTheField = true;
                    //按钮样式更改
                    ButtonState.MainButtonState[number].Content = "下场";
                    ButtonState.MainButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowDownload24 };
                    ButtonState.MainButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFF0000"));
                    //同步到当前上场列表
                    if (TeamInfoModel.MainTeamInfo.State == "监管者" && NowModel.NowPlayer[4] == "")
                        NowModel.NowPlayer[4] = TeamInfoModel.MainTeamPlayer[number].Name;
                    //满员禁用上场按钮
                    for (int j = 6; j < 9; j++)
                    {
                        if (ButtonState.MainButtonState[j].Content == "上场")
                            ButtonState.MainButtonState[j].IsEnabled = false;
                    }
                }
                if (team == "Away")
                {
                    //切换上场状态
                    TeamInfoModel.AwayTeamPlayer[number].IsPlayerTakeTheField = true;
                    //按钮样式更改
                    ButtonState.AwayButtonState[number].Content = "下场";
                    ButtonState.AwayButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowDownload24 };
                    ButtonState.AwayButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFF0000"));
                    //同步到当前上场列表
                    if (TeamInfoModel.AwayTeamInfo.State == "监管者")
                        NowModel.NowPlayer[4] = TeamInfoModel.AwayTeamPlayer[number].Name;
                    //满员禁用上场按钮
                    for (int j = 6; j < 9; j++)
                    {
                        if (ButtonState.AwayButtonState[j].Content == "上场")
                            ButtonState.AwayButtonState[j].IsEnabled = false;
                    }
                }
            }
            TeamInfoModel = TeamInfoModel;
            ButtonState = ButtonState;
            NowModel = NowModel;
        }
        public void PlayerOff(int number, string team, string type)//选手下场
        {

            if (type == "求生者")//传入的上场选手为求生
            {

                if (team == "Main")
                {
                    //切换上场状态
                    TeamInfoModel.MainTeamPlayer[number].IsPlayerTakeTheField = false;
                    //按钮样式更改
                    ButtonState.MainButtonState[number].Content = "上场";
                    ButtonState.MainButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowExportUp24 };
                    ButtonState.MainButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00FF00"));
                    //减少上场选手计数器
                    NowMainPlayerAccount--;
                    for (int i = 0; i < 5; i++)
                    {
                        //同步到当前上场列表
                        if (TeamInfoModel.MainTeamInfo.State == "求生者" && NowModel.NowPlayer[i] == TeamInfoModel.MainTeamPlayer[number].Name)
                        {
                            NowModel.NowPlayer[i] = "";
                            break;
                        }
                    }
                    for (int j = 0; j < 6; j++)//主队解除上场限制
                    {
                        ButtonState.MainButtonState[j].IsEnabled = true;
                    }
                }
                if (team == "Away")
                {
                    //切换上场状态
                    TeamInfoModel.AwayTeamPlayer[number].IsPlayerTakeTheField = false;
                    //按钮样式更改
                    ButtonState.AwayButtonState[number].Content = "上场";
                    ButtonState.AwayButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowExportUp24 };
                    ButtonState.AwayButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00FF00"));
                    //减少上场选手计数器
                    NowAwayPlayerAccount--;
                    for (int i = 0; i < 5; i++)
                    {
                        //同步到当前上场列表
                        if (TeamInfoModel.AwayTeamInfo.State == "求生者" && NowModel.NowPlayer[i] == TeamInfoModel.AwayTeamPlayer[number].Name)
                        {
                            NowModel.NowPlayer[i] = "";
                            break;
                        }
                    }
                    for (int j = 0; j < 6; j++)//客队解除上场限制
                    {
                        ButtonState.AwayButtonState[j].IsEnabled = true;
                    }

                }
            }
            else//传入的上场选手为监管
            {
                if (team == "Main")
                {
                    //切换上场状态
                    TeamInfoModel.MainTeamPlayer[number].IsPlayerTakeTheField = false;
                    //按钮样式更改
                    ButtonState.MainButtonState[number].Content = "上场";
                    ButtonState.MainButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowExportUp24 };
                    ButtonState.MainButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00FF00"));
                    //同步到当前上场列表
                    if (NowModel.NowPlayer[4] == TeamInfoModel.MainTeamPlayer[number].Name && TeamInfoModel.MainTeamInfo.State == "监管者")
                        NowModel.NowPlayer[4] = "";
                    //启用上场按钮
                    for (int j = 6; j < 9; j++)
                    {
                        ButtonState.MainButtonState[j].IsEnabled = true;
                    }
                }
                if (team == "Away")
                {
                    //切换上场状态
                    TeamInfoModel.AwayTeamPlayer[number].IsPlayerTakeTheField = false;
                    //按钮样式更改
                    ButtonState.AwayButtonState[number].Content = "上场";
                    ButtonState.AwayButtonState[number].Icon = new Wpf.Ui.Controls.SymbolIcon { Symbol = Wpf.Ui.Controls.SymbolRegular.ArrowExportUp24 };
                    ButtonState.AwayButtonState[number].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00FF00"));
                    //同步到当前上场列表
                    if (NowModel.NowPlayer[4] == TeamInfoModel.AwayTeamPlayer[number].Name && TeamInfoModel.AwayTeamInfo.State == "监管者")
                        NowModel.NowPlayer[4] = "";
                    //启用上场按钮
                    for (int j = 6; j < 9; j++)
                    {
                        ButtonState.AwayButtonState[j].IsEnabled = true;
                    }
                }
            }
            TeamInfoModel = TeamInfoModel;
            ButtonState = ButtonState;
            NowModel = NowModel;
        }

        public void Swap()//换边
        {
            (TeamInfoModel.MainTeamInfo.State, TeamInfoModel.AwayTeamInfo.State) = (TeamInfoModel.AwayTeamInfo.State, TeamInfoModel.MainTeamInfo.State);
            //外层0~3代表当前上场选手 内层循环0~5 判断队伍是主队还是客队 选手名称判断内容：是否为上场选手、阵营，然后赋值给NowPlayer
            for (int i = 0; i < 5; i++)
            {
                NowModel.NowPlayer[i] = "";
            }
            for (int i = 0, j = 0; i < 6 && j < 4; i++)
            {
                if (TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    if (TeamInfoModel.MainTeamPlayer[i].State == "求生者" && TeamInfoModel.MainTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        NowModel.NowPlayer[j] = TeamInfoModel.MainTeamPlayer[i].Name;
                        j++;
                    }
                }
                else
                {
                    if (TeamInfoModel.AwayTeamPlayer[i].State == "求生者" && TeamInfoModel.AwayTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        NowModel.NowPlayer[j] = TeamInfoModel.AwayTeamPlayer[i].Name;
                        j++;
                    }
                }
            }
            //一层6~8循环 判断与上面相同 监管者
            for (int i = 6; i < 9; i++)
            {
                if (TeamInfoModel.MainTeamInfo.State == "监管者")
                {
                    if (TeamInfoModel.MainTeamPlayer[i].State == "监管者" && TeamInfoModel.MainTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        NowModel.NowPlayer[4] = TeamInfoModel.MainTeamPlayer[i].Name;
                        break;
                    }
                }
                else
                {
                    if (TeamInfoModel.AwayTeamPlayer[i].State == "监管者" && TeamInfoModel.AwayTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        NowModel.NowPlayer[4] = TeamInfoModel.AwayTeamPlayer[i].Name;
                        break;
                    }
                }
            }
            RootViewModel rootViewModel = BackWindow.backWindow.rootViewModel;
            //全局Ban自动填充
            for (int i = 0; i < 6; i++)
            {
                if (TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    rootViewModel.BpReceiveModel.SurHoleBan[i] = rootViewModel.BpReceiveModel.SurHoleBanMainRecord[i];
                }
                else
                {
                    rootViewModel.BpReceiveModel.SurHoleBan[i] = rootViewModel.BpReceiveModel.SurHoleBanAwayRecord[i];
                }
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", i);
            }
            TeamInfoModel = TeamInfoModel;
            NowModel = NowModel;
            rootViewModel.BpReceiveModel = rootViewModel.BpReceiveModel;
            rootViewModel.BpShowViewModel = rootViewModel.BpShowViewModel;
        }
        public void SwapPlayers(int num1, int num2)//求生pick界面的位置互换
        {
            (NowModel.NowPlayer[num1], NowModel.NowPlayer[num2]) = (NowModel.NowPlayer[num2], NowModel.NowPlayer[num1]);
            TeamInfoModel = TeamInfoModel;
            NowModel = NowModel;
        }

        public void ImportTeamInfoFromJson(string team)//从json导入队伍信息
        {
            //调用通用对话框导入json文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string json_path = openFileDialog.FileName;
                //读取json文件
                string json_str = File.ReadAllText(json_path);
                //解析json文件
                JObject json_obj = JObject.Parse(json_str);
                //获取队名
                string team_name = (string)json_obj["teamName"];
                //获取队标
                string logo_uri = (string)json_obj["LogoUri"];
                if (team == "main")
                {
                    TeamInfoModel.MainTeamInfo.Name = team_name;
                    TeamInfoModel.MainTeamInfo.LOGO = new BitmapImage(new Uri(logo_uri));
                }
                else
                {
                    TeamInfoModel.AwayTeamInfo.Name = team_name;
                    TeamInfoModel.AwayTeamInfo.LOGO = new BitmapImage(new Uri(logo_uri));
                }

                int SurProgress = 0, HunProgress = 6;
                // 遍历players数组  
                foreach (JObject player in json_obj["players"])
                {
                    string playerName = player["playerName"].ToString();
                    string type = player["type"].ToString();
                    // 根据type的值将选手名称添加到相应的列表中  
                    if (type == "sur")
                    {
                        if (team == "main")
                        {
                            TeamInfoModel.MainTeamPlayer[SurProgress].Name = playerName;
                        }
                        else
                        {
                            TeamInfoModel.AwayTeamPlayer[SurProgress].Name = playerName;
                        }
                        SurProgress++;
                    }
                    else if (type == "hun")
                    {
                        if (team == "main")
                        {
                            TeamInfoModel.MainTeamPlayer[HunProgress].Name = playerName;
                        }
                        else
                        {
                            TeamInfoModel.AwayTeamPlayer[HunProgress].Name = playerName;
                        }
                        HunProgress++;
                    }
                }
            }
            TeamInfoModel = TeamInfoModel;
            NowModel = NowModel;
        }
        public void ScoreSSet(string type, int Resault)//小比分（自动化）设置
        {
            if (Resault == 2)
            {
                TeamInfoModel.MainTeamInfo.Score.S += 2;
                TeamInfoModel.AwayTeamInfo.Score.S += 2;
            }
            else
            {
                if (type == "sur")
                {
                    if (TeamInfoModel.MainTeamInfo.State == "求生者")//主队是人队
                    {
                        if (Resault == 4)//四跑
                        {
                            TeamInfoModel.MainTeamInfo.Score.S += 5;
                        }
                        if (Resault == 3)//三跑
                        {
                            TeamInfoModel.MainTeamInfo.Score.S += 3;
                            TeamInfoModel.AwayTeamInfo.Score.S += 1;
                        }
                    }
                    if (TeamInfoModel.AwayTeamInfo.State == "求生者")//客队是人队
                    {
                        if (Resault == 4)//四跑
                        {
                            TeamInfoModel.AwayTeamInfo.Score.S += 5;
                        }
                        if (Resault == 3)//三跑
                        {
                            TeamInfoModel.MainTeamInfo.Score.S += 1;
                            TeamInfoModel.AwayTeamInfo.Score.S += 3;
                        }
                    }
                }
                else
                {
                    if (TeamInfoModel.MainTeamInfo.State == "监管者")//主队是屠夫
                    {
                        if (Resault == 4)//四抓
                        {
                            TeamInfoModel.MainTeamInfo.Score.S += 5;
                        }
                        if (Resault == 3)//三抓
                        {
                            TeamInfoModel.MainTeamInfo.Score.S += 3;
                            TeamInfoModel.AwayTeamInfo.Score.S += 1;
                        }
                    }
                    if (TeamInfoModel.AwayTeamInfo.State == "监管者")//客队是屠夫
                    {
                        if (Resault == 4)//四抓
                        {
                            TeamInfoModel.AwayTeamInfo.Score.S += 5;
                        }
                        if (Resault == 3)//三抓
                        {
                            TeamInfoModel.MainTeamInfo.Score.S += 1;
                            TeamInfoModel.AwayTeamInfo.Score.S += 3;
                        }
                    }
                }
            }
            ScoreViewRefresh();
            BackWindow.backWindow.rootViewModel.TeamInfoViewModel = BackWindow.backWindow.rootViewModel.TeamInfoViewModel;
        }
        public void BigScoreSettlement()
        {
            if (TeamInfoModel.MainTeamInfo.Score.S > TeamInfoModel.AwayTeamInfo.Score.S)//主队当前回合胜利
            {
                TeamInfoModel.MainTeamInfo.Score.W++;
                TeamInfoModel.AwayTeamInfo.Score.L++;
            }
            if (TeamInfoModel.MainTeamInfo.Score.S < TeamInfoModel.AwayTeamInfo.Score.S)//客队当前回合胜利
            {
                TeamInfoModel.MainTeamInfo.Score.L++;
                TeamInfoModel.AwayTeamInfo.Score.W++;
            }
            if (TeamInfoModel.MainTeamInfo.Score.S == TeamInfoModel.AwayTeamInfo.Score.S)//平局
            {
                TeamInfoModel.MainTeamInfo.Score.D++;
                TeamInfoModel.AwayTeamInfo.Score.D++;
            }
            TeamInfoModel.MainTeamInfo.Score.S = 0;
            TeamInfoModel.AwayTeamInfo.Score.S = 0;
            ScoreViewRefresh();
            //RefreshNow();
            BackWindow.backWindow.rootViewModel.TeamInfoViewModel = BackWindow.backWindow.rootViewModel.TeamInfoViewModel;
        }
        public void ScoreViewRefresh()//比分显示的内容拼合
        {
            TeamInfoModel.MainTeamInfo.Score.FrontView = $"W{TeamInfoModel.MainTeamInfo.Score.W} D{TeamInfoModel.MainTeamInfo.Score.D} L{TeamInfoModel.MainTeamInfo.Score.L}";
            TeamInfoModel.AwayTeamInfo.Score.FrontView = $"W{TeamInfoModel.AwayTeamInfo.Score.W} D{TeamInfoModel.AwayTeamInfo.Score.D} L{TeamInfoModel.AwayTeamInfo.Score.L}";
            TeamInfoModel.MainTeamInfo.Score.BackView = $"{TeamInfoModel.MainTeamInfo.Name} W:{TeamInfoModel.MainTeamInfo.Score.W} D:{TeamInfoModel.MainTeamInfo.Score.D} L:{TeamInfoModel.MainTeamInfo.Score.L} 小比分:{TeamInfoModel.MainTeamInfo.Score.S}";
            TeamInfoModel.AwayTeamInfo.Score.BackView = $"{TeamInfoModel.AwayTeamInfo.Name} W:{TeamInfoModel.AwayTeamInfo.Score.W} D:{TeamInfoModel.AwayTeamInfo.Score.D} L:{TeamInfoModel.AwayTeamInfo.Score.L} 小比分:{TeamInfoModel.AwayTeamInfo.Score.S}";
            BackWindow.backWindow.rootViewModel.TeamInfoViewModel = BackWindow.backWindow.rootViewModel.TeamInfoViewModel;
        }

        public void RefreshNow()
        {
            if (_TeamInfoModel.MainTeamInfo.State == "求生者")
            {
                NowModel.NowSurTeam.Name = TeamInfoModel.MainTeamInfo.Name;
                NowModel.NowHunTeam.Name = TeamInfoModel.AwayTeamInfo.Name;
                NowModel.NowSurTeam.LOGO = TeamInfoModel.MainTeamInfo.LOGO;
                NowModel.NowHunTeam.LOGO = TeamInfoModel.AwayTeamInfo.LOGO;
                NowModel.NowSurTeam.Score = TeamInfoModel.MainTeamInfo.Score;
                NowModel.NowHunTeam.Score = TeamInfoModel.AwayTeamInfo.Score;
                NowModel.NowSurTeam.Score.S = TeamInfoModel.MainTeamInfo.Score.S;
                NowModel.NowHunTeam.Score.S = TeamInfoModel.AwayTeamInfo.Score.S;
            }
            else
            {
                NowModel.NowHunTeam.Name = TeamInfoModel.MainTeamInfo.Name;
                NowModel.NowSurTeam.Name = TeamInfoModel.AwayTeamInfo.Name;
                NowModel.NowSurTeam.LOGO = TeamInfoModel.AwayTeamInfo.LOGO;
                NowModel.NowHunTeam.LOGO = TeamInfoModel.MainTeamInfo.LOGO;
                NowModel.NowHunTeam.Score = TeamInfoModel.MainTeamInfo.Score;
                NowModel.NowSurTeam.Score = TeamInfoModel.AwayTeamInfo.Score;
                NowModel.NowHunTeam.Score.S = TeamInfoModel.MainTeamInfo.Score.S;
                NowModel.NowSurTeam.Score.S = TeamInfoModel.AwayTeamInfo.Score.S;
            }
            TeamInfoModel = TeamInfoModel;
            NowModel = NowModel;
        }

        public void ClearScoreAll()
        {
            TeamInfoModel.MainTeamInfo.Score.W = 0;
            TeamInfoModel.MainTeamInfo.Score.D = 0;
            TeamInfoModel.MainTeamInfo.Score.L = 0;
            TeamInfoModel.MainTeamInfo.Score.S = 0;

            TeamInfoModel.AwayTeamInfo.Score.W = 0;
            TeamInfoModel.AwayTeamInfo.Score.D = 0;
            TeamInfoModel.AwayTeamInfo.Score.L = 0;
            TeamInfoModel.AwayTeamInfo.Score.S = 0;
            ScoreViewRefresh();
            //RefreshNow();
            BackWindow.backWindow.rootViewModel.TeamInfoViewModel = BackWindow.backWindow.rootViewModel.TeamInfoViewModel;
        }
    }
}
