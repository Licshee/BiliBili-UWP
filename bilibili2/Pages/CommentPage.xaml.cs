﻿using bilibili2.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace bilibili2.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CommentPage : Page
    {
        public delegate void GoBackHandler();
        public event GoBackHandler BackEvent;
        public CommentPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
           
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
        int ps = 1;
        string rootsid = "";
        string aid = "";
        string root = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            object[] o = e.Parameter as object[];
            bg.Color = ((SolidColorBrush)this.Frame.Tag).Color;
            grid_Commnet.DataContext = o[0] as CommentViewModel;
            ListView_Flyout.Items.Clear();
            ps = 1;
            aid = o[1].ToString();
            rootsid = ((CommentViewModel)o[0]).Rpid;
            await GetComments(o[1].ToString(), ((CommentViewModel)o[0]).Rpid);
        }
        private async Task GetComments(string aid, string rootid)
        {
            try
            {
                Comment_loading.Visibility = Visibility.Visible;
                btn_Load_More.Content = "加载中....";
                btn_Load_More.IsEnabled = false;
                WebClientClass wc = new WebClientClass();
                Random r = new Random();
                string results = await wc.GetResults(new Uri("http://api.bilibili.com/x/reply/reply?oid=" + aid + "&pn=1&ps=20&root=" + rootid + "&type=1&r=" + r.Next(1000, 99999)));
                var ban = JsonConvert.DeserializeObject<Model.ReplyRootModel>(results);
                ListView_Flyout.Items.Clear();
                foreach (var item in ban.Data.Replies)
                {
                    CommentViewModel resultsModel = new CommentViewModel()
                    {
                        Avatar = item.Member.Avatar,
                        Message = item.Content.Message,
                        Plat = Converter.ConvertToPlatform(item.Content.Plat),
                        Floor = $"{item.Floor}",
                        Uname = item.Member.Uname,
                        Mid = item.Member.Mid,
                        Time = Converter.ConvertToDate(long.Parse($"{item.Ctime}0000000")),
                        Like = $"{item.Like}",
                        Rcount =$"{item.Rcount}",
                        Rpid =$"{item.Rpid}",
                        LV=Converter.ConvertToLvPic(item.Member.LevelInfo.CurrentLevel)
                    };
                    ListView_Flyout.Items.Add(resultsModel);
                    if (ban.Data.Page.Count == 0)
                    {
                        btn_Load_More.Content = "加载完了...";
                        btn_Load_More.IsEnabled = false;
                    }
                    else
                    {
                        btn_Load_More.Content = "加载更多";
                        btn_Load_More.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                messShow.Show("读取评论失败\r\n" + ex.Message, 3000);
            }
            finally
            {
                Comment_loading.Visibility = Visibility.Collapsed;
            }
        }

        private async Task GetComments(string aid, string rootid, int num)
        {
            try
            {
                Comment_loading.Visibility = Visibility.Visible;
                btn_Load_More.Content = "加载中....";
                btn_Load_More.IsEnabled = false;
                WebClientClass wc = new WebClientClass();
                Random r = new Random();
                string results = await wc.GetResults(new Uri("http://api.bilibili.com/x/reply/reply?oid=" + aid + "&pn=" + num + "&ps=20&root=" + rootid + "&type=1&r=" + r.Next(1000, 99999)));
                var ban = JsonConvert.DeserializeObject<Model.ReplyRootModel>(results);

                foreach (var item in ban.Data.Replies)
                {
                    CommentViewModel resultsModel = new CommentViewModel()
                    {
                        Avatar = item.Member.Avatar,
                        Message = item.Content.Message,
                        Plat = Converter.ConvertToPlatform(item.Content.Plat),
                        Floor = $"{item.Floor}",
                        Uname = item.Member.Uname,
                        Mid = item.Member.Mid,
                        Time = Converter.ConvertToDate(long.Parse($"{item.Ctime}0000000")),
                        Like = $"{item.Like}",
                        Rcount = $"{item.Rcount}",
                        Rpid = $"{item.Rpid}",
                        LV = Converter.ConvertToLvPic(item.Member.LevelInfo.CurrentLevel)
                    };
                    ListView_Flyout.Items.Add(resultsModel);
                }
                if (ban.Data.Page.Count == 0)
                {
                    btn_Load_More.Content = "加载完了...";
                    btn_Load_More.IsEnabled = false;
                }
                else
                {
                    btn_Load_More.Content = "加载更多";
                    btn_Load_More.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                messShow.Show("读取评论失败\r\n" + ex.Message, 3000);
            }
            finally
            {
                Comment_loading.Visibility = Visibility.Collapsed;
            }
        }

        private async void btn_Zan_Click(object sender, RoutedEventArgs e)
        {
            string rpid = ((sender as HyperlinkButton).DataContext as CommentViewModel).Rpid;
            UserClass getUser = new UserClass();
            if (getUser.IsLogin())
            {
                try
                {
                    Uri ReUri = new Uri("http://api.bilibili.com/x/reply/action");

                    HttpClient hc = new HttpClient();
                    hc.DefaultRequestHeaders.Referer = new Uri("http://www.bilibili.com/");
                    string sendString = "";
                    if (((sender as HyperlinkButton).Content as TextBlock).Text == "赞同")
                    {
                        sendString = "jsonp=jsonp&oid=" + aid + "&type=1&rpid=" + rpid + "&action=1";
                    }
                    else
                    {
                        sendString = "jsonp=jsonp&oid=" + aid + "&type=1&rpid=" + rpid + "&action=0";
                    }
                    var response = await hc.PostAsync(ReUri, new HttpStringContent(sendString, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/x-www-form-urlencoded"));
                    response.EnsureSuccessStatusCode();
                    string result = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(result);
                    if ((int)json["code"] == 0)
                    {
                        if (((sender as HyperlinkButton).Content as TextBlock).Text == "赞同")
                        {
                            ((sender as HyperlinkButton).Content as TextBlock).Text = "取消赞";
                        }
                        else
                        {
                            ((sender as HyperlinkButton).Content as TextBlock).Text = "赞同";
                        }
                    }
                    else
                    {
                        messShow.Show("点赞失败\r\n"+ result, 3000);
                    }

                }
                catch (Exception)
                {
                }
            }
            else
            {
                messShow.Show("请先登录!", 3000);
            }
        }
        bool canLoad = true;
        private async void sv1_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (sv1.VerticalOffset == sv1.ScrollableHeight)
            {
                if (canLoad)
                {
                    canLoad = false;
                    ps++;
                    await GetComments(aid, rootsid, ps);
                    canLoad = true;
                }
            }
        }

        private void ListView_Flyout_ItemClick(object sender, ItemClickEventArgs e)
        {
            root = (e.ClickedItem as CommentViewModel).Rpid;
            txt_Com_1.Text = "回复 @" + (e.ClickedItem as CommentViewModel).Uname + ":";
        }

        private async void btn_Load_More_Click(object sender, RoutedEventArgs e)
        {
            if (canLoad)
            {
                canLoad = false;
                ps++;
                await GetComments(aid, rootsid, ps);
                canLoad = true;
            }
        }

        private async void brn_SendComment_1_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Com_1.Text.Length == 0)
            {
                messShow.Show("内容不能为空", 3000);
                return;
            }
            UserClass getUser = new UserClass();
            if (getUser.IsLogin())
            {
                try
                {
                    Uri ReUri = new Uri("http://api.bilibili.com/x/reply/add");
                    HttpClient hc = new HttpClient();
                    hc.DefaultRequestHeaders.Referer = new Uri("http://www.bilibili.com/");
                    if (root == "")
                    {
                        root = rootsid;
                    }
                    //jsonp=jsonp&message=(%E2%8C%92%E2%96%BD%E2%8C%92)&parent=95828061&root=95828061&type=1&plat=1&oid=4376012
                    string QuStr = "plat=6&jsonp=jsonp&message=" + Uri.EscapeDataString(txt_Com_1.Text) + "&parent=" + rootsid + "&root=" + root + "&type=1&plat=6&oid=" + aid;
                    var response = await hc.PostAsync(ReUri, new HttpStringContent(QuStr, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/x-www-form-urlencoded"));
                    response.EnsureSuccessStatusCode();
                    string result = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(result);
                    if ((int)json["code"] == 0)
                    {
                        await GetComments(aid, rootsid);
                        messShow.Show("评论成功！", 3000);
                    }
                    else
                    {
                        messShow.Show("评论失败！\r\n" + result, 3000);
                    }

                }
                catch (Exception ex)
                {
                    messShow.Show("评论时发生错误\r\n" + ex.Message, 3000);
                }
            }
            else
            {
                messShow.Show("请先登录!", 3000);

                //MessageDialog md = new MessageDialog("你造吗，你没有登录 (～￣▽￣)，先登录好伐~");
                //await md.ShowAsync();
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt_Com_1.Text += ((Button)sender).Content.ToString();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            CommentViewModel model = (sender as HyperlinkButton).DataContext as CommentViewModel;
            this.Frame.Navigate(typeof(UserInfoPage), model.Mid);
        }
    }
}
