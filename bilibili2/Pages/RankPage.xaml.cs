﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.UI.Core;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace bilibili2.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RankPage : Page
    {
        public delegate void GoBackHandler();
        public event GoBackHandler BackEvent;
        public RankPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
          
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bg.Color = ((SolidColorBrush)this.Frame.Tag).Color;
        }
      

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {

            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
            else
            {
                BackEvent();
            }
        }

        HttpClient hc;
        public async Task GetQZRank()
        {
            try
            {

                WebClientClass wc = new WebClientClass();
                string results = await wc.GetResults(new Uri("http://api.bilibili.cn/list?appkey=84b739484c36d653&order=hot&original=0&page=1&pagesize=20"));
                JObject json = JObject.Parse(results);
                QQ_Rank_QZ.Items.Clear();
                var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                {
                    Aid = item.Value<string>("aid"),
                    Title = item.Value<string>("title"),
                    Pic = item.Value<string>("pic"),
                    Author = item.Value<string>("author"),
                    Play = item.Value<string>("play"),
                    VideoReview = item.Value<string>("video_review"),
                    Num = i + 1
                });
                QQ_Rank_QZ.ItemsSource = ReList;
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }
        }
        public async Task GetYCRank()
        {
            try
            {
                WebClientClass wc = new WebClientClass();
                string results = await wc.GetResults(new Uri("http://api.bilibili.com/list?appkey=422fd9d7289a1dd9&order=hot&original=1&page=1&pagesize=20"));
                JObject json = JObject.Parse(results);
                QQ_Rank_YC.Items.Clear();
                var ReList = json["list"].Children().Where(item=>item.Path!="list.num").Values().Select((item, i) => new AVInfoViewModel
                {
                    Aid = item.Value<string>("aid"),
                    Title = item.Value<string>("title"),
                    Pic = item.Value<string>("pic"),
                    Author = item.Value<string>("author"),
                    Play = item.Value<string>("play"),
                    VideoReview = item.Value<string>("video_review"),
                    Num = i + 1
                });
                QQ_Rank_YC.ItemsSource = ReList;
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }
        }
        public async Task GetFJRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=13 "));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_FJ.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_FJ.ItemsSource = ReList;
                }

            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }
        }
        public async Task GetDHRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=1"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_DH.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_DH.ItemsSource = ReList;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }

        public async Task GetYYRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=3"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_YY.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_YY.ItemsSource = ReList;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }
        public async Task GetWDRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=129"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_WD.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_WD.ItemsSource = ReList;
                }

            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }

        public async Task GetYXRank()
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=4"));
                hr.EnsureSuccessStatusCode();
                string results = await hr.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(results);
                QQ_Rank_YX.Items.Clear();
                var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                {
                    Aid = item.Value<string>("aid"),
                    Title = item.Value<string>("title"),
                    Pic = item.Value<string>("pic"),
                    Author = item.Value<string>("author"),
                    Play = item.Value<string>("play"),
                    VideoReview = item.Value<string>("video_review"),
                    Num = i + 1
                });
                QQ_Rank_YX.ItemsSource = ReList;
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }
        public async Task GetKJRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=36"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_KJ.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_KJ.ItemsSource = ReList;
                }


            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }

        public async Task GetYLRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=5"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_YL.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_YL.ItemsSource = ReList;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }
        public async Task GetGCRank()
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=119"));
                hr.EnsureSuccessStatusCode();
                string results = await hr.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(results);
                QQ_Rank_GC.Items.Clear();
                var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                {
                    Aid = item.Value<string>("aid"),
                    Title = item.Value<string>("title"),
                    Pic = item.Value<string>("pic"),
                    Author = item.Value<string>("author"),
                    Play = item.Value<string>("play"),
                    VideoReview = item.Value<string>("video_review"),
                    Num = i + 1
                });
                QQ_Rank_GC.ItemsSource = ReList;
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }


        public async Task GetDYRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=422fd9d7289a1dd9&order=hot&original=0&page=1&pagesize=20&tid=23"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_DY.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_DY.ItemsSource = ReList;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }
        public async Task GetDSJRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=84b739484c36d653&order=hot&original=0&page=1&pagesize=20&tid=11"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_DSJ.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_DSJ.ItemsSource = ReList;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }
        public async Task GetSSRank()
        {
            try
            {
                using (hc = new HttpClient())
                {
                    HttpResponseMessage hr = await hc.GetAsync(new Uri("http://api.bilibili.cn/list?appkey=84b739484c36d653&order=hot&original=0&page=1&pagesize=20&tid=155"));
                    hr.EnsureSuccessStatusCode();
                    string results = await hr.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(results);
                    QQ_Rank_SS.Items.Clear();
                    var ReList = json["list"].Children().Where(item => item.Path != "list.num").Values().Select((item, i) => new AVInfoViewModel
                    {
                        Aid = item.Value<string>("aid"),
                        Title = item.Value<string>("title"),
                        Pic = item.Value<string>("pic"),
                        Author = item.Value<string>("author"),
                        Play = item.Value<string>("play"),
                        VideoReview = item.Value<string>("video_review"),
                        Num = i + 1
                    });
                    QQ_Rank_SS.ItemsSource = ReList;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog(ex.Message);
                await md.ShowAsync();
            }

        }


        private void QQ_Rank_YC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(VideoInfoPage), ((AVInfoViewModel)e.ClickedItem).Aid);
        }
        bool QZLoad = false;
        bool YCLoad = false;
        bool FJLoad = false;
        bool DHLoad = false;
        bool YYLoad = false;
        bool WDLoad = false;
        bool YXLoad = false;
        bool KJLoad = false;
        bool YLLoad = false;
        bool GCLoad = false;
        bool DYLoad = false;
        bool DSJLoad = false;
        bool SSLoad = false;
        private async void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (pivot.SelectedIndex)
            {
                case 0:
                    if (!YCLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetYCRank();
                        YCLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 1:
                    if (!QZLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetQZRank();
                        QZLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 2:
                    if (!FJLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetFJRank();
                        FJLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 3:
                    if (!DHLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetDHRank();
                        DHLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 4:
                    if (!YYLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetYYRank();
                        YYLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 5:
                    if (!WDLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetWDRank();
                        WDLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 6:
                    if (!YXLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetYXRank();
                        YXLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 7:
                    if (!KJLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetKJRank();
                        KJLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 8:
                    if (!YLLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetYLRank();
                        YLLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 9:
                    if (!GCLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetGCRank();
                        GCLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 10:
                    if (!DYLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetDYRank();
                        DYLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 11:
                    if (!DSJLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetDSJRank();
                        DSJLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 12:
                    if (!SSLoad)
                    {
                        pr_loading.Visibility = Visibility.Visible;
                        await GetSSRank();
                        SSLoad = true;
                        pr_loading.Visibility = Visibility.Collapsed;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
