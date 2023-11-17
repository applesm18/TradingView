using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Security.Policy;
using System.Net.Http;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Web.WebView2.Core;
using System.Xml;
using System.Web;
using System.Net;
using mshtml;
using HtmlAgilityPack;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using static System.Windows.Forms.LinkLabel;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;
using System.Printing;
using System.Net.NetworkInformation;

namespace WpfCoinView
{
    public class ExchangeData
    {
        public string Exchange { get; set; }
        public string TrustScore { get; set; }
        public string ReservesData { get; set; }

        public string h24VolumeNormalized { get; set; }
        public string h24Volume { get; set; }

        public string MonthlyVisits { get; set; }

        public string Tocken { get; set; }

        public string ApiUrl { get; set; }

        public int Num{get; set;}

        //public string Last7Days { get; set; }

    }

    public class TdViewData
    {
        public string EXNAME { get; set; }
        public string A2B1 { get; set; }
        public string A2B2 { get; set; }
        public string A2B3 { get; set; }
        public string A2B4 { get; set; }
        public string A2B5 { get; set; }
        public string A2B6 { get; set; }
        public string A2B7 { get; set; }
        public string A2B8 { get; set; }
        public string A2B9 { get; set; }
        public string A2B10 { get; set; }
        public string A2B11 { get; set; }
        public string A2B12 { get; set; }
        public string A2B13 { get; set; }
        public string A2B14 { get; set; }
        public string A2B15 { get; set; }
        public string A2B16 { get; set; }
        public string A2B17 { get; set; }
        public string A2B18 { get; set; }
        public string A2B19 { get; set; }
        public string A2B20 { get; set; }
        public string A2B21 { get; set; }
        public string A2B22 { get; set; }
        public string A2B23 { get; set; }
        public string A2B24 { get; set; }
        public string A2B25 { get; set; }

    }

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        /// 
    public partial class MainWindow
    {
        private bool IsStartUp;
        private bool IsSartex1;
        private bool IsSartex2;
        private bool IsSartex3;
        private bool IsSartex4;
        private bool IsSartex5;
        private bool IsSartex6;
        private bool IsSartex7;
        private bool IsSartex8;
        private bool IsSartex9;
        private bool IsSartex10;

        private bool IsLoadingSartex1;
        private bool IsLoadingSartex2;
        private bool IsLoadingSartex3;
        private bool IsLoadingSartex4;
        private bool IsLoadingSartex5;
        private bool IsLoadingSartex6;
        private bool IsLoadingSartex7;
        private bool IsLoadingSartex8;
        private bool IsLoadingSartex9;
        private bool IsLoadingSartex10;

        private TdViewData[] m_Exchangelist;
        private ArrayList m_Coinlist;
        private ArrayList m_ExchangeNamelist;
        private System.Windows.Threading.DispatcherTimer m_LivedispatcherTimer;

        private ArrayList AtoBlist;
        private int m_TradingSleepCount;
        //private Microsoft.Web.WebView2.Wpf.WebView2 m_webcoin;
        public MainWindow()
        {            
            InitializeComponent();
            InitData();
            CreateLiveTimer();
        }

        private void InitData()
        {
            m_TradingSleepCount = 0;
            int nWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int nHieght = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            this.LayoutTransform = new ScaleTransform(nWidth / 1920, nHieght / 1080);

            IsStartUp = false;
            IsSartex1 = false;
            IsSartex2 = false;
            IsSartex3 = false;
            IsSartex4 = false;
            IsSartex5 = false;
            IsSartex6 = false;
            IsSartex7 = false;
            IsSartex8 = false;
            IsSartex9 = false;
            IsSartex10 = false;

            IsLoadingSartex1 = false;
            IsLoadingSartex2 = false;
            IsLoadingSartex3 = false;
            IsLoadingSartex4 = false;
            IsLoadingSartex5 = false;
            IsLoadingSartex6 = false;
            IsLoadingSartex7 = false;
            IsLoadingSartex8 = false;
            IsLoadingSartex9 = false;
            IsLoadingSartex10 = false;


            m_Exchangelist = new TdViewData[10];
            for (int i = 0; i < 10;  i++)
            {
                TdViewData tdViewData = new TdViewData();
                m_Exchangelist[i] = tdViewData;
            }

            m_Coinlist = new ArrayList();
            AtoBlist = new ArrayList();
            m_ExchangeNamelist = new ArrayList();

            AtoBlist.Add("BTC/USDT");
            AtoBlist.Add("USDC/USDT");
            AtoBlist.Add("BTC/USDC");
            AtoBlist.Add("ETH/USDT");
            AtoBlist.Add("ETH/USDC");
            AtoBlist.Add("CTC/USDT");
            AtoBlist.Add("XRP/USDT");
            AtoBlist.Add("FON/USDT");
            AtoBlist.Add("MNT/USDT");
            AtoBlist.Add("FB/USDT");
            AtoBlist.Add("DOGE/USDT");
            AtoBlist.Add("WLD/USDT");
            AtoBlist.Add("SOL/USDT");
            AtoBlist.Add("XRP/USDC");
            AtoBlist.Add("LTC/USDT");
            AtoBlist.Add("CYBER/USDT");
            AtoBlist.Add("PEPE/USDT");
            AtoBlist.Add("TOMI/USDT");
            AtoBlist.Add("LINK/USDT");
            AtoBlist.Add("TRX/USDT");
            AtoBlist.Add("ARB/USDT");
            AtoBlist.Add("GALA/USDT");
            AtoBlist.Add("BUSD/USDT");
            AtoBlist.Add("MTC/USDT");
            AtoBlist.Add("MATIC/USDT");

            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            webcoin.CoreWebView2InitializationCompleted += Webcoin_CoreWebView2InitializationCompleted;
            webexchange1.CoreWebView2InitializationCompleted += Webexchange1_CoreWebView2InitializationCompleted;
            webexchange2.CoreWebView2InitializationCompleted += Webexchange2_CoreWebView2InitializationCompleted;
            webexchange3.CoreWebView2InitializationCompleted += Webexchange3_CoreWebView2InitializationCompleted;
            webexchange4.CoreWebView2InitializationCompleted += Webexchange4_CoreWebView2InitializationCompleted;
            webexchange5.CoreWebView2InitializationCompleted += Webexchange5_CoreWebView2InitializationCompleted;
            webexchange6.CoreWebView2InitializationCompleted += Webexchange6_CoreWebView2InitializationCompleted;
            webexchange7.CoreWebView2InitializationCompleted += Webexchange7_CoreWebView2InitializationCompleted;
            webexchange8.CoreWebView2InitializationCompleted += Webexchange8_CoreWebView2InitializationCompleted;
            webexchange9.CoreWebView2InitializationCompleted += Webexchange9_CoreWebView2InitializationCompleted;
            webexchange10.CoreWebView2InitializationCompleted += Webexchange10_CoreWebView2InitializationCompleted;


        }

        private void Webexchange10_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange10.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn10;
        }

        private void Webexchange9_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange9.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn9;
        }

        private void Webexchange8_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange8.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn8;
        }

        private void Webexchange7_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange7.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn7;

        }

        private void Webexchange6_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange6.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn6;
        }

        private void Webexchange5_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange5.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn5;
        }

        private void Webexchange4_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange4.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn4;
        }

        private void Webexchange3_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange3.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn3;
        }

        private void Webexchange2_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange2.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn2;
        }

        private void Webexchange1_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webexchange1.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded_fn1;
        }

        private void CreateLiveTimer()
        {
            m_LivedispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            m_LivedispatcherTimer.Tick += LiveExchangeTimer;
            m_LivedispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            m_LivedispatcherTimer.Start();
        }

        private bool TradingSleep(int sleepcount)
        {
            if(m_TradingSleepCount > sleepcount)
            {
                m_TradingSleepCount = 0;
                return true;
            }

            m_TradingSleepCount++;
            return false;
        }

        private void LiveExchangeTimer(object sender, EventArgs e)
        {
            m_LivedispatcherTimer.Stop();
            UpdateViewData();
            if(TradingSleep(1))
            {
                ReloadTrading();
            }
            //UpdateExchange();
            //webView.CoreWebView2.Reload();
            
            m_LivedispatcherTimer.Start();
        }

        private void UpdateViewData()
        {
            for(int i = 0; i < m_ExchangeNamelist.Count; i++)
            {
                ExchangeData Item = (ExchangeData)m_ExchangeNamelist[i];
                UpdateExchangeEx(Item.Num);
            }
        }
        private void ReloadTrading()
        {
            if(!GetLoadFlag(1)) webexchange1.CoreWebView2.Reload();
            if(!GetLoadFlag(2)) webexchange2.CoreWebView2.Reload();
            if(GetLoadFlag(3)) webexchange3.CoreWebView2.Reload();
            if(!GetLoadFlag(4)) webexchange4.CoreWebView2.Reload();
            if(!GetLoadFlag(5)) webexchange5.CoreWebView2.Reload();
            if(!GetLoadFlag(6)) webexchange6.CoreWebView2.Reload();
            if(!GetLoadFlag(7)) webexchange7.CoreWebView2.Reload();
            if(!GetLoadFlag(8)) webexchange8.CoreWebView2.Reload();
            if(!GetLoadFlag(9)) webexchange9.CoreWebView2.Reload();
            if(!GetLoadFlag(10)) webexchange10.CoreWebView2.Reload();
        }
        private void Webcoin_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webcoin.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded1;
        }
        private async void CoreWebView2_DOMContentLoaded1(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            string sHtml = await webcoin.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
            string sHtmlDecoded = System.Text.RegularExpressions.Regex.Unescape(sHtml);

            object[] oPageText = { sHtmlDecoded };
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(oPageText);
            var collection = doc.getElementsByTagName("span");

            foreach (mshtml.IHTMLElement obj in collection)
            {
                if (obj.className == "lg:tw-flex font-bold tw-items-center tw-justify-between")
                {
                    var str = obj.innerText.Split("\r\n")[0];
                    m_Coinlist.Add(str);
                    if (m_Coinlist.Count > 10) break;
                }
            }

            for(int i = 0; i < m_Coinlist.Count; i++)
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Binding = new System.Windows.Data.Binding(m_Coinlist[i].ToString());
                //coinGrid.Columns.Add(textColumn);
            }
        }

        private void OnAppClose(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {

            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
            webView.CoreWebView2.WebResourceResponseReceived += CoreWebView2_WebResourceResponseReceived;


            //webView.Source = new Uri("https://www.coingecko.com/en/exchanges");
        }

        private async void CoreWebView2_DOMContentLoaded_fn1(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if (!IsSartex1)
            {
                IsSartex1 = true;
                UpdateExchangeEx(1);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn2(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex2)
            {
                IsSartex2 = true;
                UpdateExchangeEx(2);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn3(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex3)
            {
                IsSartex3 = true;
                UpdateExchangeEx(3);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn4(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex4)
            {
                IsSartex4 = true;
                UpdateExchangeEx(4);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn5(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex5)
            {
                IsSartex5 = true;
                UpdateExchangeEx(5);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn6(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex6)
            {
                IsSartex6 = true;
                UpdateExchangeEx(6);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn7(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex7)
            {
                IsSartex7 = true;
                UpdateExchangeEx(7);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn8(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex8)
            {
                IsSartex8 = true;
                UpdateExchangeEx(8);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn9(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex9)
            {
                IsSartex9 = true;
                UpdateExchangeEx(9);
            }
        }

        private async void CoreWebView2_DOMContentLoaded_fn10(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if(!IsSartex10)
            {
                IsSartex10 = true;
                UpdateExchangeEx(10);
            }
        }

        private async void UpdateExchangeEx(int num)
        {
            string sHtml = null;
            switch (num)
            {
                case 1:
                    sHtml = await webexchange1.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 2:
                    sHtml = await webexchange2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;

                case 3:
                    sHtml = await webexchange3.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 4:
                    sHtml = await webexchange4.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 5:
                    sHtml = await webexchange5.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 6:
                    sHtml = await webexchange6.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 7:
                    sHtml = await webexchange7.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 8:
                    sHtml = await webexchange8.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 9:
                    sHtml = await webexchange9.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
                case 10:
                    sHtml = await webexchange10.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                    break;
            }

            SetLoadFlag(num);
            string sHtmlDecoded = System.Text.RegularExpressions.Regex.Unescape(sHtml);

            object[] oPageText = { sHtmlDecoded };
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(oPageText);

            var collectons = doc.getElementsByTagName("tbody");

            int parseCount = 0;
            string[] pricelist = new string[30];
            foreach (mshtml.IHTMLElement obj in collectons)
            {                
                mshtml.IHTMLElementCollection elemcollection = (mshtml.IHTMLElementCollection)obj.children;
                foreach (IHTMLElement sub1 in elemcollection)
                {
                    string strprice = null;
                    string stratob = null;
                    var strlist = sub1.innerHTML.Split("</A>");
                    if (strlist.Length < 2)
                    {
                        stratob = "unknown1";
                        strprice = "unknown1";
                        continue;
                    }
                    if(strlist.Length == 2)
                    {
                        var tmplist = strlist[1].Split("</TD>");
                        if (tmplist.Length > 2)
                        {
                            var tmp11list = tmplist[2].Split("\">");
                            stratob = tmp11list[tmp11list.Length - 1];
                        }
                        else
                        {
                            stratob = "unknown2";
                            strprice = "unknown2";

                        }

                    }
                    else{
                        var tmplist = strlist[2].Split("target=_blank>");
                        stratob = tmplist[tmplist.Length - 1];
                    }
                    
                    var tmp1list = sub1.innerHTML.Split("</DIV>");
                    var tmp2list = tmp1list[0].Split("\">");
                    strprice = tmp2list[tmp2list.Length - 1];

                    

                    for (int i = 0; i < AtoBlist.Count; i++)
                    {
                        string stra2b = AtoBlist[i].ToString();
                        if (stratob.ToUpper().Contains(stra2b.ToUpper()))
                        {
                            pricelist[i] = strprice;
                            parseCount++;
                        }
                    }
                }
            }

            if (parseCount < 5) return;
            if (m_ExchangeNamelist.Count < 1) return;
            
            TdViewData ItemData = new TdViewData();
            ExchangeData ExchangeData = (ExchangeData)m_ExchangeNamelist[num - 1];
            ItemData.EXNAME = ExchangeData.Exchange;
            ItemData.A2B1 = pricelist[0];
            ItemData.A2B2 = pricelist[1];
            ItemData.A2B3 = pricelist[2];
            ItemData.A2B4 = pricelist[3];
            ItemData.A2B5 = pricelist[4];
            ItemData.A2B6 = pricelist[5];
            ItemData.A2B7 = pricelist[6];
            ItemData.A2B8 = pricelist[7];
            ItemData.A2B9 = pricelist[8];
            ItemData.A2B10 = pricelist[9];
            ItemData.A2B11 = pricelist[10];
            ItemData.A2B12 = pricelist[11];
            ItemData.A2B13 = pricelist[12];
            ItemData.A2B14 = pricelist[13];
            ItemData.A2B15 = pricelist[14];
            ItemData.A2B16 = pricelist[15];
            ItemData.A2B17 = pricelist[16];
            ItemData.A2B18 = pricelist[17];
            ItemData.A2B19 = pricelist[18];
            ItemData.A2B20 = pricelist[19];
            ItemData.A2B21 = pricelist[20];
            ItemData.A2B22 = pricelist[21];
            ItemData.A2B23 = pricelist[22];
            ItemData.A2B24 = pricelist[23];
            ItemData.A2B25 = pricelist[24];

            m_Exchangelist[num-1] = ItemData;


            ListExchange.ItemsSource = m_Exchangelist;
            ListExchange.Items.Refresh();
        }

        private void SetLoadFlag(int num)
        {
            switch (num)
            {
                case 1:
                    IsLoadingSartex1 = true; break;
                case 2:
                    IsLoadingSartex2 = true; break; 
                case 3: 
                    IsLoadingSartex3 = true; break;
                case 4: 
                    IsLoadingSartex4 = true; break;
                case 5: 
                    IsLoadingSartex5 = true; break;
                case 6: 
                    IsLoadingSartex6 = true; break;
                case 7:
                    IsLoadingSartex7 = true; break;
                case 8: 
                    IsLoadingSartex8 = true; break;
                case 9:
                    IsLoadingSartex9 = true; break;
                case 10:
                    IsLoadingSartex10 = true; break;
            }
        }

        private bool GetLoadFlag(int num)
        {
            return false;
            switch(num)
            {
                case 1: return IsLoadingSartex1;
                case 2: return IsLoadingSartex2;
                case 3: return IsLoadingSartex3;
                case 4: return IsLoadingSartex4;
                case 5: return IsLoadingSartex5;
                case 6: return IsLoadingSartex6;
                case 7: return IsLoadingSartex7;
                case 8: return IsLoadingSartex8;
                case 9: return IsLoadingSartex9;
                case 10: return IsLoadingSartex10;
            }

            return false;
        }

        private async void CoreWebView2_WebResourceResponseReceived(object? sender, CoreWebView2WebResourceResponseReceivedEventArgs e)
        {
            Console.WriteLine("We can see this is called at the time of every response");
        }

        private async void UpdateExchange()
        {

            if (m_ExchangeNamelist.Count < 1)
            {

                string sHtml = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                string sHtmlDecoded = System.Text.RegularExpressions.Regex.Unescape(sHtml);


                object[] oPageText = { sHtmlDecoded };
                HTMLDocument doc = new HTMLDocument();
                IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
                doc2.write(oPageText);
                var collection = doc.getElementsByTagName("span");
                var collection2 = doc.getElementsByTagName("div");
                var collection3 = doc.getElementsByTagName("td");


                ArrayList exchangelist = new ArrayList();
                ArrayList trustscores = new ArrayList();
                ArrayList reservesdata = new ArrayList();
                ArrayList h24volumes = new ArrayList();
                ArrayList MonthlyVisits = new ArrayList();
                ArrayList Tockens = new ArrayList();


                m_ExchangeNamelist.Clear();

                foreach (mshtml.IHTMLElement obj in collection)
                {
                    if (obj.className == "pt-2 flex-column")
                    {
                        var str = obj.innerText.Split("\r\n")[0];
                        exchangelist.Add(str);
                    }

                    if (obj.className == "font-weight-bold text-black")
                    {
                        var str = obj.innerText.Split("\r\n")[0];
                        trustscores.Add(str);
                    }

                    if (obj.className == "tw-inline-flex tw-items-center tw-font-medium tw-bg-yellow-100 tw-text-yellow-800 dark:tw-bg-white dark:tw-bg-opacity-5 dark:tw-text-yellow-400 tw-px-2 tw-py-0.5 tw-rounded tw-text-xs tw-max-h-5")
                    {
                        var str = obj.innerText.Split("\r\n")[0];
                        reservesdata.Add(str);
                    }

                    if (obj.className == "pt-2 flex-column")
                    {
                        //var str = obj.innerText.Split("\r\n")[0];
                        var strlist = obj.innerHTML.Split("\">");
                        var sublist = strlist[0].Split("/");
                        var tocken = sublist[sublist.Length - 1];
                        Tockens.Add(tocken);
                    }

                    if (reservesdata.Count > 20) break;

                }


                foreach (mshtml.IHTMLElement obj in collection2)
                {

                    if (obj.className == "trade-vol-amount text-right")
                    {
                        var str = obj.innerText.Split("\r\n")[0];
                        h24volumes.Add(str);
                    }



                    if (h24volumes.Count > 30) break;

                }

                foreach (mshtml.IHTMLElement obj in collection3)
                {

                    if (obj.className == "text-right")
                    {
                        var str = obj.innerText.Split("\r\n")[0];
                        MonthlyVisits.Add(str);
                    }


                    if (MonthlyVisits.Count > 20) break;

                }

                //m_Exchangelist.Clear();

                int minlen = Math.Min(exchangelist.Count, reservesdata.Count);
                minlen = Math.Min(minlen, trustscores.Count);
                minlen = Math.Min(minlen, h24volumes.Count);
                minlen = Math.Min(minlen, MonthlyVisits.Count);
                minlen = Math.Min(minlen, Tockens.Count);
                minlen = Math.Min(minlen, 10);

                for (int i = 0; i < minlen; i++)
                {
                    ExchangeData item = new ExchangeData();
                    item.Exchange = exchangelist[i].ToString();
                    item.ReservesData = reservesdata[i].ToString();
                    item.TrustScore = trustscores[i].ToString();
                    item.h24VolumeNormalized = h24volumes[i * 2].ToString();
                    item.h24Volume = h24volumes[i * 2 + 1].ToString();
                    item.MonthlyVisits = MonthlyVisits[i].ToString();
                    item.Tocken = Tockens[i].ToString();
                    item.ApiUrl = "https://www.coingecko.com/en/exchanges/" + Tockens[i].ToString();
                    item.Num = i + 1;

                    m_Exchangelist[item.Num - 1].EXNAME = item.Exchange;
                    m_ExchangeNamelist.Add(item);
                    
                }
            }

            for(int i = 0; i < m_ExchangeNamelist.Count; i++)
            {
                ExchangeData item = (ExchangeData)m_ExchangeNamelist[i];
                SetApiUrlAndReload(item.ApiUrl, item.Num);
            }

            ListExchange.ItemsSource = m_Exchangelist;
            ListExchange.Items.Refresh();
            Console.WriteLine("count = " + m_ExchangeNamelist.Count.ToString());

        }

        private void SetApiUrlAndReload(string apiUrl, int num)
        {
            switch (num)
            {
                case 1:
                    if (!IsSartex1) return;
                    webexchange1.Source = new Uri(apiUrl);
                    webexchange1.CoreWebView2.Reload();
                    break;
                case 2:
                    if (!IsSartex1) return;
                    webexchange2.Source = new Uri(apiUrl);
                    webexchange2.CoreWebView2.Reload();
                    break;
                case 3:
                    if (!IsSartex1) return;
                    webexchange3.Source = new Uri(apiUrl);
                    webexchange3.CoreWebView2.Reload();
                    break;
                case 4:
                    if (!IsSartex1) return;
                    webexchange4.Source = new Uri(apiUrl);
                    webexchange4.CoreWebView2.Reload();
                    break;
                case 5:
                    if (!IsSartex1) return;
                    webexchange5.Source = new Uri(apiUrl);
                    webexchange5.CoreWebView2.Reload();
                    break;
                case 6:
                    if (!IsSartex1) return;
                    webexchange6.Source = new Uri(apiUrl);
                    webexchange6.CoreWebView2.Reload();
                    break;
                case 7:
                    if (!IsSartex1) return;
                    webexchange7.Source = new Uri(apiUrl);
                    webexchange7.CoreWebView2.Reload();
                    break;
                case 8:
                    if (!IsSartex1) return;
                    webexchange8.Source = new Uri(apiUrl);
                    webexchange8.CoreWebView2.Reload();
                    break;
                case 9:
                    if (!IsSartex1) return;
                    webexchange9.Source = new Uri(apiUrl);
                    webexchange9.CoreWebView2.Reload();
                    break;
                case 10:
                    if (!IsSartex1) return;
                    webexchange10.Source = new Uri(apiUrl);
                    webexchange10.CoreWebView2.Reload();
                    break;

            }
        }

        private async void CoreWebView2_DOMContentLoaded(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            if (!IsStartUp)
            {
                IsStartUp = true;
                UpdateExchange();
            }
        }

        private async void CoreWebView2_DOMContentLoadedCoin(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        {

            string sHtml = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
            string sHtmlDecoded = System.Text.RegularExpressions.Regex.Unescape(sHtml);

            object[] oPageText = { sHtmlDecoded };
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(oPageText);
            var collection = doc.getElementsByTagName("span");

            foreach (mshtml.IHTMLElement obj in collection)
            {
                if (obj.className == "lg:tw-flex font-bold tw-items-center tw-justify-between")
                {
                    var str = obj.innerText.Split("\r\n")[0];
                    m_Coinlist.Add(str);
                    if (m_Coinlist.Count > 10) break;
                }
            }

            //coinGrid.ItemsSource = m_Coinlist;
        }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            
        }
       

        public async Task GetHome()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.coingecko.com/en/exchanges");
            response.EnsureSuccessStatusCode();
        }

        private void wexchangeWebBrowser_Navigated(object sender, WebBrowserNavigatingEventArgs e)
        {

        }
    }
}
