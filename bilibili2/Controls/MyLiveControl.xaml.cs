using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace bilibili2.Controls
{
    public sealed partial class MyLiveControl : UserControl
    {
        public MyLiveControl()
        {
            this.InitializeComponent();
        }
        public delegate void PlayHandler(string aid);
        public event PlayHandler PlayEvent;
        public event PlayHandler ErrorEvent;
        public bool isLoaded = false;
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualWidth <= 500)
            {
                ViewBox2_num.Width = ActualWidth / 2 - 15;
                double d = ((ViewBox2_num.Width + 12) / 1.15) * 2;
                gridview_Hot.Height = d;
                gridview_DJ.Height = d;
                gridview_FY.Height = d;
                gridview_HH.Height = d;
                gridview_JJ.Height = d;
                gridview_MZ.Height = d;
                gridview_SH.Height = d;
                gridview_WL.Height = d;
                gridview_YZ.Height = d;
                //PageCount = 4;
            }
            else
            {
                if (this.ActualWidth <= 800)
                {
                    ViewBox2_num.Width = ActualWidth / 3 - 15;
                    double d = ((ViewBox2_num.Width + 12) / 1.15) * 2;
                    gridview_Hot.Height = d;
                    gridview_DJ.Height = d;
                    gridview_FY.Height = d;
                    gridview_HH.Height = d;
                    gridview_JJ.Height = d;
                    gridview_MZ.Height = d;
                    gridview_SH.Height = d;
                    gridview_WL.Height = d;
                    gridview_YZ.Height = d;
                }
                else
                {
                    int i = Convert.ToInt32(ActualWidth / 200);
                    ViewBox2_num.Width = ActualWidth / i - 15;
                    double d = ((ViewBox2_num.Width + 12) / 1.15);
                    gridview_Hot.Height = d;
                    gridview_DJ.Height = d;
                    gridview_FY.Height = d;
                    gridview_HH.Height = d;
                    gridview_JJ.Height = d;
                    gridview_MZ.Height = d;
                    gridview_SH.Height = d;
                    gridview_WL.Height = d;
                    gridview_YZ.Height = d;
                }
            }
        }

        public async void GetLiveInfo()
        {
            try
            {
                pr_Load.Visibility = Visibility.Visible;
                gridview_Hot.Items.Clear();
                gridview_DJ.Items.Clear();
                gridview_FY.Items.Clear();
                gridview_HH.Items.Clear();
                gridview_JJ.Items.Clear();
                gridview_MZ.Items.Clear();
                gridview_SH.Items.Clear();
                gridview_WL.Items.Clear();
                gridview_YZ.Items.Clear();
                WebClientClass wc = new WebClientClass();
                string url = string.Format("http://live.bilibili.com/AppIndex/home?_device=wp&_ulv=10000&access_key={0}&appkey={1}&build=411005&platform=android&scale=xxhdpi", ApiHelper.access_key, ApiHelper._appKey);
                url += "&sign=" + ApiHelper.GetSign(url);
                string results = await wc.GetResults(new Uri(url));
                var model = JsonConvert.DeserializeObject<Model.HomeLiveRootModel>(results);
                if (model.Code == 0)
                {
                    foreach (var item in model.Data.Partitions)
                    {
                        switch (item.Partition.Name)
                        {
                            case "热门直播":
                                var hot = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online=vm.Online
                                });
                                foreach (var vm in hot)
                                {
                                    gridview_Hot.Items.Add(vm);
                                }
                                break;
                            case "萌宅推荐":
                                var mz = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in mz)
                                {
                                    gridview_MZ.Items.Add(vm);
                                }
                                break;
                            case "绘画专区":
                                var hh = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in hh)
                                {
                                    gridview_HH.Items.Add(vm);
                                }
                                break;
                            case "御宅文化":
                                var yz = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in yz)
                                {
                                    gridview_YZ.Items.Add(vm);
                                }
                                break;
                            case "生活娱乐":
                                var sh = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in sh)
                                {
                                    gridview_SH.Items.Add(vm);
                                }
                                break;
                            case "单机联机":
                                var dj = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in dj)
                                {
                                    gridview_DJ.Items.Add(vm);
                                }
                                break;
                            case "网络游戏":
                                var wl = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in wl)
                                {
                                    gridview_WL.Items.Add(vm);
                                }
                                break;
                            case "电子竞技":
                                var dz = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in dz)
                                {
                                    gridview_JJ.Items.Add(vm);
                                }
                                break;
                            case "放映厅":
                                var fy = item.Lives.Select(vm => new HomeLiveViewModel
                                {
                                    Src = vm.Cover.Src,
                                    Name = vm.Owner.Name,
                                    Mid = $"{vm.Owner.Mid}",
                                    Face = vm.Owner.Face,
                                    Online = vm.Online
                                });
                                foreach (var vm in fy)
                                {
                                    gridview_FY.Items.Add(vm);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    isLoaded = true;
                }
                else
                {
                    ErrorEvent("读取直播失败" + model.Message);
                    isLoaded = false;
                }
            }
            catch (Exception ex)
            {
                ErrorEvent("读取直播失败" + ex.Message);
                isLoaded = false;
            }
            finally
            {
                pr_Load.Visibility = Visibility.Collapsed;
            }
        }
    }
}
