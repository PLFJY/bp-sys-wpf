using bp_sys_wpf.Model;
using bp_sys_wpf.Views.Pages;
using System.ComponentModel;
using System.Windows.Media;
using Wpf.Ui.Controls;

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
        public NowViewModel nowView { get; set; } = new NowViewModel();
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
                                Name = $"Main{i}",
                                State = "求生者"
                            });
                            _TeamInfoModel.AwayTeamPlayer.Add(new Player
                            {
                                Name = $"Away{i}",
                                State = "求生者"
                            });
                        }
                        else
                        {
                            _TeamInfoModel.MainTeamPlayer.Add(new Player
                            {
                                Name = $"Main{i}",
                                State = "监管者"
                            });
                            _TeamInfoModel.AwayTeamPlayer.Add(new Player
                            {
                                Name = $"Away{i}",
                                State = "监管者"
                            });
                        }
                    }
                    _TeamInfoModel.MainTeamInfo.State = "求生者";//队伍阵营初始化
                    _TeamInfoModel.AwayTeamInfo.State = "监管者";
                }
                if (_TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    _TeamInfoModel.NowSurTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    _TeamInfoModel.NowHunTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                }
                else
                {
                    _TeamInfoModel.NowHunTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    _TeamInfoModel.NowSurTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                }
                return _TeamInfoModel;

            }
            set
            {
                _TeamInfoModel = value;
                if (_TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    _TeamInfoModel.NowSurTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    _TeamInfoModel.NowHunTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
                }
                else
                {
                    _TeamInfoModel.NowHunTeam.Name = _TeamInfoModel.MainTeamInfo.Name;
                    _TeamInfoModel.NowSurTeam.Name = _TeamInfoModel.AwayTeamInfo.Name;
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
                        if (TeamInfoModel.MainTeamInfo.State == "求生者" && nowView.NowModel.NowPlayer[i].Name == "")
                        {
                            nowView.NowModel.NowPlayer[i].Name = TeamInfoModel.MainTeamPlayer[number].Name;
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
                        if (TeamInfoModel.AwayTeamInfo.State == "求生者")
                        {
                            nowView.NowModel.NowPlayer[i].Name = TeamInfoModel.AwayTeamPlayer[number].Name;
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
                    if (TeamInfoModel.MainTeamInfo.State == "监管者" && nowView.NowModel.NowPlayer[4].Name == "")
                        nowView.NowModel.NowPlayer[4].Name = TeamInfoModel.MainTeamPlayer[number].Name;
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
                        nowView.NowModel.NowPlayer[4].Name = TeamInfoModel.AwayTeamPlayer[number].Name;
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
                        if (TeamInfoModel.MainTeamInfo.State == "求生者" && nowView.NowModel.NowPlayer[i].Name == TeamInfoModel.MainTeamPlayer[number].Name)
                        {
                            nowView.NowModel.NowPlayer[i].Name = "";
                            break;
                        }
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
                        if (TeamInfoModel.AwayTeamInfo.State == "求生者")
                        {
                            nowView.NowModel.NowPlayer[i].Name = "";
                            break;
                        }
                    }

                }
                for (int j = 0; j < 6; j++)//主队解除上场限制
                {
                    ButtonState.MainButtonState[j].IsEnabled = true;
                }
                for (int j = 0; j < 6; j++)//客队解除上场限制
                {
                    ButtonState.AwayButtonState[j].IsEnabled = true;
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
                    if (nowView.NowModel.NowPlayer[4].Name == TeamInfoModel.MainTeamPlayer[number].Name && TeamInfoModel.MainTeamInfo.State == "监管者")
                        nowView.NowModel.NowPlayer[4].Name = TeamInfoModel.MainTeamPlayer[number].Name;
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
                    if (nowView.NowModel.NowPlayer[4].Name == TeamInfoModel.AwayTeamPlayer[number].Name && TeamInfoModel.AwayTeamInfo.State == "监管者")
                        nowView.NowModel.NowPlayer[4].Name = "";
                    //启用上场按钮
                    for (int j = 6; j < 9; j++)
                    {
                        ButtonState.AwayButtonState[j].IsEnabled = true;
                    }
                }
            }
            TeamInfoModel = TeamInfoModel;
            ButtonState = ButtonState;
        }

        public void Swap()//换边
        {
            (TeamInfoModel.MainTeamInfo.State, TeamInfoModel.AwayTeamInfo.State) = (TeamInfoModel.AwayTeamInfo.State, TeamInfoModel.MainTeamInfo.State);
            //外层0~3代表当前上场选手 内层循环0~5 判断队伍是主队还是客队 选手名称判断内容：是否为上场选手、阵营，然后赋值给NowPlayer
            for (int i = 0; i < 5; i++)
            {
                nowView.NowModel.NowPlayer[i].Name = "";
            }
            for (int i = 0,j = 0; i < 6&&j<4; i++)
            {
                if (TeamInfoModel.MainTeamInfo.State == "求生者")
                {
                    if (TeamInfoModel.MainTeamPlayer[i].State == "求生者" && TeamInfoModel.MainTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        nowView.NowModel.NowPlayer[j].Name = TeamInfoModel.MainTeamPlayer[i].Name;
                        j++;
                    }
                }
                else
                {
                    if (TeamInfoModel.AwayTeamPlayer[i].State == "求生者" && TeamInfoModel.AwayTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        nowView.NowModel.NowPlayer[j].Name = TeamInfoModel.AwayTeamPlayer[i].Name;
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
                        nowView.NowModel.NowPlayer[4].Name = TeamInfoModel.MainTeamPlayer[i].Name;
                        break;
                    }
                }
                else
                {
                    if (TeamInfoModel.AwayTeamPlayer[i].State == "监管者" && TeamInfoModel.AwayTeamPlayer[i].IsPlayerTakeTheField == true)
                    {
                        nowView.NowModel.NowPlayer[4].Name = TeamInfoModel.AwayTeamPlayer[i].Name;
                        break;
                    }
                }
            }
            TeamInfoModel = TeamInfoModel;
        }
        public void SwapPlayers(int num1, int num2)
        {
            (nowView.NowModel.NowPlayer[num1], nowView.NowModel.NowPlayer[num2]) = (nowView.NowModel.NowPlayer[num2], nowView.NowModel.NowPlayer[num1]);
            TeamInfoModel = TeamInfoModel;
        }
    }
}
