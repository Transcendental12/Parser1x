using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrowserEmulator;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using xNet;
using System.Drawing.Imaging;

namespace Parser1x
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IWebDriver Browser;
        bool isWork;
        string onexmirror = "", parimirror = "", ligaiswork = "";
        string window1 = "", window2 = "", window3 = "";
        string mirror_actor_1 = "", mirror_actor_pari = "";
        List<string> zapret = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
           

            try
            {

                var driverService = FirefoxDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                FirefoxOptions option = new FirefoxOptions();

                option.AddArgument("--headless");
                option.AddArgument("--window-size=1600x1000");
                Browser = new FirefoxDriver(driverService, option);
                //Browser = new ChromeDriver(driverService, option);
              
                //Browser.Manage().Window.Size = new System.Drawing.Size(1600, 1200);
                Browser.Navigate().GoToUrl(parimirror);
                System.Threading.Thread.Sleep(3000);

                window1 = Browser.CurrentWindowHandle;

                ((IJavaScriptExecutor)Browser).ExecuteScript("window.open()");
                for (int j = 0; j < Browser.WindowHandles.Count; j++)
                    if (Browser.WindowHandles.ElementAt(j) != window1)
                        Browser.SwitchTo().Window(Browser.WindowHandles.ElementAt(j));

                Browser.Navigate().GoToUrl(onexmirror);
                System.Threading.Thread.Sleep(3000);
                try {
                    // (Browser as OpenQA.Selenium.Chrome.ChromeDriver).GetScreenshot().SaveAsFile("Screen.png", ImageFormat.Png);

                    if (Browser.FindElements(By.XPath("//*[contains(@class,'box-modal_close arcticmodal-close')]")).Count != 0)
                    {
                        Browser.FindElements(By.XPath("//*[contains(@class,'box-modal_close arcticmodal-close')]"))[0].Click();
                        System.Threading.Thread.Sleep(2000);
                    }

                    Browser.FindElement(By.XPath("//*[@id=\"countLiveEventsOnMain\"]/div[1]")).Click();
                    System.Threading.Thread.Sleep(2000);

                    if (Browser.FindElements(By.XPath("//*[contains(@class,'box-modal_close arcticmodal-close')]")).Count != 0)
                    {
                        Browser.FindElements(By.XPath("//*[contains(@class,'box-modal_close arcticmodal-close')]"))[0].Click();
                        System.Threading.Thread.Sleep(2000);
                    }

                    Browser.FindElement(By.XPath("//*[@id=\"countLiveEventsOnMain\"]/div[2]/div[6]")).Click();
                    System.Threading.Thread.Sleep(3000);
                }
                catch { }

                window2 = Browser.CurrentWindowHandle;

                if (ligaiswork == "work")
                {
                    try
                    {
                        ((IJavaScriptExecutor)Browser).ExecuteScript("window.open()");
                        for (int j = 0; j < Browser.WindowHandles.Count; j++)
                            if ((Browser.WindowHandles.ElementAt(j) != window1) && (Browser.WindowHandles.ElementAt(j) != window2))
                                Browser.SwitchTo().Window(Browser.WindowHandles.ElementAt(j));

                        Browser.Navigate().GoToUrl("https://www.ligastavok.ru/bets/live");
                        System.Threading.Thread.Sleep(3000);
                        //match.AddRange(HTML.ExtractTagsCollection(br.Document, "div", "class=\"bui-event-row-"));              

                        while (Browser.FindElements(By.XPath("//*[contains(@class,'bui-events-lazy-bar__button-')]")).Count != 0)
                            Browser.FindElements(By.XPath("//*[contains(@class,'bui-events-lazy-bar__button-')]"))[0].Click();

                        window3 = Browser.CurrentWindowHandle;
                    }
                    catch { }
                }

            }
            catch
            {
                Browser.Quit();
            }

            isWork = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Browser.Quit();
            }
            catch { }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            bool onex, pari, liga;
            Browser br = new Browser();
            br.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134";

            try
            {
                List<string> match = new List<string>();

                List<string> mirrors = new List<string>();
                if (mirror_actor_pari != "")
                {
                    mirrors.Add(mirror_actor_pari);
                }
                mirrors.Add("https://pm-516.info/live.html");
                mirrors.Add("https://pm-512.info/live.html");
                mirrors.Add("https://pm-505.info/live.html");
                mirrors.Add("https://pm-444.info/live.html");
                mirrors.Add("https://pm-439.info/live.html");
                mirrors.Add("https://pm-424.info/live.html");
                mirrors.Add("https://pm-422.info/live.html");
                mirrors.Add("https://pm-427.info/live.html");
                mirrors.Add("https://pm-429.info/live.html");
                pari = false;

                for (int i = 0; i < mirrors.Count; i++)
                {
                    br.Get(mirrors[i]);
                    match.AddRange(HTML.ExtractTagsCollection(br.Document, "div", "class=\"subitem\""));
                    if (match.Count != 0)
                    {
                        parimirror = mirrors[i];
                        pari = true;
                        break;
                    }
                }

                match.Clear();
                mirrors.Clear();

                if (mirror_actor_1 != "")
                {
                    mirrors.Add(mirror_actor_1);
                }
            //1xzerkalo.net можно зеркала получать вроде
            
                mirrors.Add("https://1xredkwj.host/ru/live/");
                mirrors.Add("https://1xrlyv.host/ru/live/");
                mirrors.Add("https://1xredbas.host/ru/live/");
                mirrors.Add("https://1xredxen.host/ru/live/");
                mirrors.Add("https://1xnfqd.host/ru/live/");
                mirrors.Add("https://1xfjme.host/ru/live/");
                mirrors.Add("https://1xyxmr.host/ru/live/");
                mirrors.Add("https://1xfwdq.host/ru/live/");
                mirrors.Add("https://1xgdke.host/ru/live/");
                mirrors.Add("https://1xgfrr.host/ru/live/");
                mirrors.Add("https://1xmhli.host/ru/live/");
                mirrors.Add("https://1xoqdt.host/ru/live/");
                mirrors.Add("https://1xizvg.host/ru/live/");
                
                onex = false;

                for (int i = 0; i < mirrors.Count; i++)
                {
                    br.Get(mirrors[i]);
                    match.AddRange(HTML.ExtractTagsCollection(br.Document, "div", "class=\"c-events__item c-events__item_game c-events-scoreboard__wrap"));
                    if (match.Count != 0)
                    {
                        onexmirror = mirrors[i];
                        onex = true;
                        break;
                    }
                }

                match.Clear();
                br.Get("https://www.ligastavok.ru/bets/live");
                liga = false;

                match.AddRange(HTML.ExtractTagsCollection(br.Document, "div", "class=\"bui-event-row-"));

                if (match.Count != 0)
                {
                    liga = true;
                    ligaiswork = "work";
                }

                backgroundWorker1.ReportProgress(1, "onex=" + onex.ToString() + " pari=" + pari.ToString() + " liga=" + liga.ToString() + " ");
            }
            catch
            {

            }
    }


        public class Params
        {
            public List<string> matches = new List<string>();
            public List<string> command1 = new List<string>();
            public List<string> command2 = new List<string>();
            public List<string> coef1 = new List<string>();
            public List<string> coefx = new List<string>();
            public List<string> coef2 = new List<string>();
            public List<string> href1 = new List<string>();

            public List<string> matches2 = new List<string>();
            public List<string> command12 = new List<string>();
            public List<string> command22 = new List<string>();
            public List<string> coef12 = new List<string>();
            public List<string> coefx2 = new List<string>();
            public List<string> coef22 = new List<string>();
            public List<string> href2 = new List<string>();

            public int countokras;
            public decimal vilka_cf1;
            public decimal vilka_cf2;
            public decimal vilka_cfx;
            public int number1;
            public int numberx;
            public int number2;
            public int number_obnul;
            public int i;
            public int k;
            public int stage;

            public string bukmeker1;
            public string bukmeker2;

            public int sec, milsec;
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            bool onex, pari, liga;
            onex = Convert.ToBoolean(Convert.ToString(e.UserState).Substring("onex=", " "));
            pari = Convert.ToBoolean(Convert.ToString(e.UserState).Substring("pari=", " "));
            liga = Convert.ToBoolean(Convert.ToString(e.UserState).Substring("liga=", " "));

            int a = Convert.ToInt32(e.ProgressPercentage);

            label_1xbettext.Visible = true;
            if (onex == true && pari == true)
            {
                label_1xbeticon.BackColor = Color.Green;
                label_pariicon.BackColor = Color.Green;
                button1.Enabled = true;
            }
            if (onex == false)
            {
                label_1xbeticon.BackColor = Color.Red;
                button1.Enabled = false;
            }
            if (pari == false)
            {
                label_pariicon.BackColor = Color.Red;
                button1.Enabled = false;
            }
            if (onex == false && pari == false)
            {
                label_1xbeticon.BackColor = Color.Red;
                label_pariicon.BackColor = Color.Red;
                button1.Enabled = false;
            }
            if (liga == false)
            {
                label_ligaicon.BackColor = Color.Red;
            }
            else if (liga == true)
            {
                label_ligaicon.BackColor = Color.Green;
            }

        }





        private void button3_Click(object sender, EventArgs e)
        {
            isWork = false;
            backgroundWorker2.CancelAsync();
            try
            {
                Browser.Quit();
            }
            catch { }
            label4.Text = "Не работает";
            label4.ForeColor = Color.Red;
            button3.Enabled = false;
            button1.Enabled = true;
            button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Приостановить")
            {
                isWork = false;
                backgroundWorker2.CancelAsync();
                button4.Text = "Продолжить";
                button5.Enabled = true;
            }
            else if (button4.Text == "Продолжить")
            {
                isWork = true;
                backgroundWorker2.RunWorkerAsync();
                button4.Text = "Приостановить";
                button5.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DG_vilkins.SelectedCells.Count >= 2)
            {
                int row1, row2 = -1;
                row1 = DG_vilkins.SelectedCells[0].RowIndex;
                for (int j = 0; j < DG_vilkins.SelectedCells.Count; j++)
                {
                    if (DG_vilkins.SelectedCells[j].RowIndex != row1 && row2 == -1)
                        row2 = DG_vilkins.SelectedCells[j].RowIndex; 
                }
                if (row1>row2)
                {
                    int a = row1;
                    row1 = row2;
                    row2 = a;
                }
                if (row2 != -1)
                {
                    string s1_k1 = DG_vilkins.Rows[row1].Cells[1].Value.ToString();
                    string s1_k2 = DG_vilkins.Rows[row1].Cells[2].Value.ToString();
                    string s2_k1 = DG_vilkins.Rows[row2].Cells[1].Value.ToString();
                    string s2_k2 = DG_vilkins.Rows[row2].Cells[2].Value.ToString();

                    DG_vilkins.Rows.Remove(DG_vilkins.Rows[row1]);
                    DG_vilkins.Rows.Remove(DG_vilkins.Rows[row2-1]);

                    zapret.Add(s1_k1);
                    zapret.Add(s1_k2);
                    zapret.Add(s2_k1);
                    zapret.Add(s2_k2);
                }
            }
        }

        private void DG_vilkins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Clipboard.SetText(DG_vilkins.Rows[e.RowIndex].Cells[7].Tag.ToString());
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isWork == true)
            {
                try
                {
                    DateTime dd = DateTime.Now;

                    List<string> ab = new List<string>();

                    List<string> matches2 = new List<string>();
                    List<string> command12 = new List<string>();
                    List<string> command22 = new List<string>();
                    List<string> coef12 = new List<string>();
                    List<string> coefx2 = new List<string>();
                    List<string> coef22 = new List<string>();
                    List<string> href2 = new List<string>();

                    int number_obnul = 0;

                    Browser.SwitchTo().Window(window1);
                    ab.AddRange(HTML.ExtractTagsCollection(Browser.PageSource, "table", "class=\"dt processed\""));

                    try
                    {
                        for (int i = 0; i < ab.Count; i++)
                        {
                            if (ab[i].Contains("<table class=\"dt processed\" evno=") && !ab[i].Contains("угловые") && !ab[i].Contains("желтые карточки"))
                            {
                                matches2.Add(HTML.ExtractTag(ab[i], "tbody"));
                            }
                        }
                        for (int i = 0; i < matches2.Count; i++)
                        {
                            string a = " " + (HTML.ExtractTagInnerHTML(matches2[i], "a")).Replace("<small>", "").Replace("</small>", "");
                            if (a.Contains("<div class"))
                                a = a.Substring(" ", "<div").Trim();
                            else if (a.Contains("<span class"))
                                a = a.Substring(" ", "<span class").Trim();
                            else
                                a.Trim();
                            command12.Add(a.Remove(a.IndexOf(" ")).Replace(" ", ""));
                            command22.Add(a.Substring("- ").Replace(" ", ""));

                            if ((HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[2], "i") != ""))
                            {
                                coef12.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[2], "i").Trim());
                            }
                            else
                            {
                                coef12.Add("-");
                            }

                            if ((HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[4], "i") != ""))
                            {
                                coef22.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[4], "i").Trim());
                            }
                            else
                            {
                                coef22.Add("-");
                            }

                            if ((HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[3], "i") != ""))
                            {
                                coefx2.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[3], "i").Trim()); ;
                            }
                            else
                            {
                                coefx2.Add("-");
                            }
                            if ((HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches2[i], "td")[1], "a") != ""))
                            {
                                href2.Add(parimirror.Replace("live.html", "") + HTML.ExtractAttributeValue(HTML.ExtractTag(HTML.ExtractTagsCollection(matches2[i], "td")[1], "a"), "href").Trim());
                            }
                            else
                            {
                                href2.Add("-");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Parimatch спарсить не удалось");
                        Browser.Quit();
                        backgroundWorker1.CancelAsync();
                    }

                    List<string> matches = new List<string>();
                    List<string> command1 = new List<string>();
                    List<string> command2 = new List<string>();
                    List<string> coef1 = new List<string>();
                    List<string> coefx = new List<string>();
                    List<string> coef2 = new List<string>();
                    List<string> href1 = new List<string>();

                    Browser.SwitchTo().Window(window2);
                    if (Browser.FindElements(By.XPath("//*[contains(@class,'box-modal_close arcticmodal-close')]")).Count != 0)
                    {
                        Browser.FindElements(By.XPath("//*[contains(@class,'box-modal_close arcticmodal-close')]"))[0].Click();
                        System.Threading.Thread.Sleep(2000);
                    }
                    matches.AddRange(HTML.ExtractTagsCollection(Browser.PageSource, "div", "class=\"c-events__item c-events__item_game c-events-scoreboard__wrap"));

                    try
                    {
                        for (int i = 0; i < matches.Count; i++)
                        {
                            string a = HTML.ExtractTagsCollection(matches[i], "div", "class=\"c-events__team\"")[0];
                            try
                            {
                                command1.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches[i], "div", "class=\"c-events__team\"")[0], "div", "class=\"c-events__team\"").Replace(" ", ""));
                            }
                            catch
                            {
                                command1.Add("-");
                            }
                            try
                            {
                                command2.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches[i], "div", "class=\"c-events__team\"")[1], "div", "class=\"c-events__team\"").Replace(" ", ""));
                            }
                            catch
                            {
                                command2.Add("-");
                            }
                            try
                            {
                                coef1.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches[i], "a", "class=\"c-bets__bet")[0], "a", "class=\"c-bets__bet").Replace(" ", "").Replace("\r\n", ""));
                            }
                            catch
                            {
                                coef1.Add("-");
                            }
                            try
                            {
                                coefx.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches[i], "a", "class=\"c-bets__bet")[1], "a", "class=\"c-bets__bet").Replace(" ", "").Replace("\r\n", ""));
                            }
                            catch
                            {
                                coefx.Add("-");
                            }
                            try
                            {
                                coef2.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(matches[i], "a", "class=\"c-bets__bet")[2], "a", "class=\"c-bets__bet").Replace(" ", "").Replace("\r\n", ""));
                            }
                            catch
                            {
                                coef2.Add("-");
                            }

                            try
                            {
                                href1.Add(onexmirror.Replace("live/", "") + HTML.ExtractAttributeValue(HTML.ExtractTag(matches[i], "a", "class=\"c-events__name"), "href").Replace(" ", "").Replace("\r\n", ""));
                            }
                            catch
                            {
                                href1.Add("-");
                            }

                        }
                    }
                    catch
                    {
                        MessageBox.Show("1xbet спарсить не удалось");
                        Browser.Quit();
                        backgroundWorker1.CancelAsync();
                    }

                    List<string> matches_liga = new List<string>();
                    List<string> command1_liga = new List<string>();
                    List<string> command2_liga = new List<string>();
                    List<string> coef1_liga = new List<string>();
                    List<string> coefx_liga = new List<string>();
                    List<string> coef2_liga = new List<string>();
                    List<string> href1_liga = new List<string>();

                    if (ligaiswork == "work")
                    {
                        Browser.SwitchTo().Window(window3);
                        matches_liga.AddRange(HTML.ExtractTagsCollection(Browser.PageSource, "div", "class=\"bui-event-row-"));

                        try
                        {
                            for (int i = 0; i < matches_liga.Count; i++)
                            {
                                try
                                {
                                    command1_liga.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(HTML.ExtractTag(HTML.ExtractTag(matches_liga[i], "div", "class=\"bui-event-row__info"), "a"), "span")[0], "span"));
                                }
                                catch
                                {
                                    command1_liga.Add("-");
                                }
                                try
                                {
                                    command2_liga.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(HTML.ExtractTag(HTML.ExtractTag(matches_liga[i], "div", "class=\"bui-event-row__info"), "a"), "span")[1], "span"));
                                }
                                catch
                                {
                                    command2_liga.Add("-");
                                }
                                try
                                {
                                    coef1_liga.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(HTML.ExtractTag(HTML.ExtractTag(matches_liga[i], "div", "class=\"bui-event-row-outcome-"), "div", "class=\"bui-group-outcome__default-"), "div", "class=\"bui-outcome-")[0], "span").Replace(",", "."));
                                }
                                catch
                                {
                                    coef1_liga.Add("-");
                                }
                                try
                                {
                                    coefx_liga.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(HTML.ExtractTag(HTML.ExtractTag(matches_liga[i], "div", "class=\"bui-event-row-outcome-"), "div", "class=\"bui-group-outcome__default-"), "div", "class=\"bui-outcome-")[1], "span").Replace(",", "."));
                                }
                                catch
                                {
                                    coefx_liga.Add("-");
                                }
                                try
                                {
                                    coef2_liga.Add(HTML.ExtractTagInnerHTML(HTML.ExtractTagsCollection(HTML.ExtractTag(HTML.ExtractTag(matches_liga[i], "div", "class=\"bui-event-row-outcome-"), "div", "class=\"bui-group-outcome__default-"), "div", "class=\"bui-outcome-")[2], "span").Replace(",", "."));
                        }
                                catch
                                {
                                    coef2_liga.Add("-");
                                }
                                try
                                {
                                    href1_liga.Add("https://www.ligastavok.ru/" + HTML.ExtractAttributeValue(HTML.ExtractTag(HTML.ExtractTag(matches_liga[i], "div", "class=\"bui-event-row__info"), "a"), "href"));
                                }
                                catch
                                {
                                    href1_liga.Add("-");
                                }

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Лигу ставок спарсить не удалось");
                            Browser.Quit();
                            backgroundWorker1.CancelAsync();
                        }
                    }





                    //ANALYS
                    //1xbet и parimatch
                    int countokras = 1;
                    for (int i = 0; i < matches.Count; i++)
                    {
                        for (int k = 0; k < matches2.Count; k++)
                        {
                            //if (coef1[i] != "-" && coef2[i] != "-" && coefx[i] != "-" && coef12[k] != "-" && coef22[k] != "-" && coefx2[k] != "-")
                            bool iscommand = false;
                            bool peremena_comand = false;
                            if (command1[i].Contains(command12[k]) || command2[i].Contains(command22[k]))
                            {
                                iscommand = true;
                                peremena_comand = false;
                            }
                            else if (command12[k].Contains(command1[i]) || command22[k].Contains(command2[i]))
                            {
                                iscommand = true;
                                peremena_comand = false;
                            }
                            else if (command12[k].Contains(command2[i]) || command22[k].Contains(command1[i]))
                            {
                                iscommand = true;
                                peremena_comand = true;
                            }
                            else if (command2[i].Contains(command12[k]) || command1[i].Contains(command22[k]))
                            {
                                iscommand = true;
                                peremena_comand = true;
                            }

                            if (iscommand == true)
                            {
                                if (peremena_comand == false)
                                {
                                    //проверяем есть ли все коэффициенты в командах, 1 Х 2. если одного какого-то нет, то вилку нет смысла искать.
                                    if ((coef1[i] != "-" || coef12[k] != "-") && (coef2[i] != "-" || coef22[k] != "-") && (coefx[i] != "-" || coefx2[k] != "-"))
                                    {
                                        decimal vilka_cf1, vilka_cf2, vilka_cfx;
                                        int number1, numberx, number2;

                                        if (coef1[i] == "-" || coef12[k] == "-")
                                        {
                                            if (coef1[i] == "-")
                                            {
                                                vilka_cf1 = Convert.ToDecimal(coef12[k].Replace(".", ","));
                                                number1 = 2;
                                            }
                                            else// (coef12[k] == "-") 
                                            {
                                                vilka_cf1 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                number1 = 1;
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToDecimal(coef1[i].Replace(".", ",")) >= Convert.ToDecimal(coef12[k].Replace(".", ",")))
                                            {
                                                vilka_cf1 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                number1 = 1;
                                            }
                                            else
                                            {
                                                vilka_cf1 = Convert.ToDecimal(coef12[k].Replace(".", ","));
                                                number1 = 2;
                                            }
                                        }




                                        if (coef2[i] == "-" || coef22[k] == "-")
                                        {
                                            if (coef2[i] == "-")
                                            {
                                                vilka_cf2 = Convert.ToDecimal(coef22[k].Replace(".", ","));
                                                number2 = 2;
                                            }
                                            else // (coef22[k] == "-")
                                            {
                                                vilka_cf2 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                number2 = 1;
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToDecimal(coef2[i].Replace(".", ",")) >= Convert.ToDecimal(coef22[k].Replace(".", ",")))
                                            {
                                                vilka_cf2 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                number2 = 1;
                                            }
                                            else
                                            {
                                                vilka_cf2 = Convert.ToDecimal(coef22[k].Replace(".", ","));
                                                number2 = 2;
                                            }
                                        }




                                        if (coefx[i] == "-" || coefx2[k] == "-")
                                        {
                                            if (coefx[i] == "-")
                                            {
                                                vilka_cfx = Convert.ToDecimal(coefx2[k].Replace(".", ","));
                                                numberx = 2;
                                            }
                                            else //(coefx2[k] == "-")
                                            {
                                                vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                numberx = 1;
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToDecimal(coefx[i].Replace(".", ",")) >= Convert.ToDecimal(coefx2[k].Replace(".", ",")))
                                            {
                                                vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                numberx = 1;
                                            }
                                            else
                                            {
                                                vilka_cfx = Convert.ToDecimal(coefx2[k].Replace(".", ","));
                                                numberx = 2;
                                            }
                                        }

                                        bool proverka = true;
                                        for (int n = 0; n < zapret.Count; n = n + 4)
                                        {
                                            //запрет уже с перевернутыми командами, он из грида. так что если нужно здесь перевернуть, то переворачивать.
                                            if (command1[i] == zapret[n] && command2[i] == zapret[n + 1] && command12[k] == zapret[n + 2] && command22[k] == zapret[n + 3])
                                            {
                                                proverka = false;
                                            }
                                        }

                                        if ((((1 / vilka_cfx) + (1 / vilka_cf1) + (1 / vilka_cf2)) < 1) && proverka == true)
                                        {

                                            int stage = 0;
                                            number_obnul++;
                                            Params pp = new Params();
                                            pp.coef1 = coef1;
                                            pp.coef12 = coef12;
                                            pp.coef2 = coef2;
                                            pp.coef22 = coef22;
                                            pp.coefx = coefx;
                                            pp.coefx2 = coefx2;
                                            pp.command1 = command1;
                                            pp.command12 = command12;
                                            pp.command2 = command2;
                                            pp.command22 = command22;
                                            pp.countokras = countokras;
                                            pp.i = i;
                                            pp.k = k;
                                            pp.matches = matches;
                                            pp.matches2 = matches2;
                                            pp.number1 = number1;
                                            pp.number2 = number2;
                                            pp.numberx = numberx;
                                            pp.number_obnul = number_obnul;
                                            pp.stage = stage;
                                            pp.vilka_cf1 = vilka_cf1;
                                            pp.vilka_cf2 = vilka_cf2;
                                            pp.vilka_cfx = vilka_cfx;
                                            pp.href1 = href1;
                                            pp.href2 = href2;
                                            pp.bukmeker1 = "1XBet";
                                            pp.bukmeker2 = "Parimatch";
                                            backgroundWorker2.ReportProgress(0, pp);
                                            countokras++;
                                            //backgroundWorker2.ReportProgress(0, "stage=0" + " i=" + i.ToString() + " k=" + k.ToString() + " countokras=" + countokras.ToString() + " vilka_cf1=" + vilka_cf1.ToString() + " vilka_cfx=" + vilka_cfx.ToString() + " vilka_cf2=" + vilka_cf2.ToString() + " number1=" + number1.ToString() + " number2=" + number2.ToString() + " numberx=" + numberx.ToString() + " number_obnul=" + number_obnul.ToString() + " ");

                                        }
                                    }
                                    else
                                    {
                                        //если команды перевернуты местами, то переворачиваем коэфы в первой (1хбет)
                                        if ((coef2[i] != "-" || coef12[k] != "-") && (coef1[i] != "-" || coef22[k] != "-") && (coefx[i] != "-" || coefx2[k] != "-"))
                                        {
                                            decimal vilka_cf1, vilka_cf2, vilka_cfx;
                                            int number1, numberx, number2;

                                            if (coef2[i] == "-" || coef12[k] == "-")
                                            {
                                                if (coef2[i] == "-")
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef12[k].Replace(".", ","));
                                                    number1 = 2;
                                                }
                                                else// (coef12[k] == "-")
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                    number1 = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coef2[i].Replace(".", ",")) >= Convert.ToDecimal(coef12[k].Replace(".", ",")))
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                    number1 = 1;
                                                }
                                                else
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef12[k].Replace(".", ","));
                                                    number1 = 2;
                                                }
                                            }



                                            if (coef1[i] == "-" || coef22[k] == "-")
                                            {
                                                if (coef1[i] == "-")
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef22[k].Replace(".", ","));
                                                    number2 = 2;
                                                }
                                                else // (coef22[k] == "-")
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                    number2 = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coef1[i].Replace(".", ",")) >= Convert.ToDecimal(coef22[k].Replace(".", ",")))
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                    number2 = 1;
                                                }
                                                else
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef22[k].Replace(".", ","));
                                                    number2 = 2;
                                                }
                                            }




                                            if (coefx[i] == "-" || coefx2[k] == "-")
                                            {
                                                if (coefx[i] == "-")
                                                {
                                                    numberx = 2;
                                                    vilka_cfx = Convert.ToDecimal(coefx2[k].Replace(".", ","));
                                                }
                                                else //(coefx2[k] == "-")
                                                {
                                                    numberx = 1;
                                                    vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coefx[i].Replace(".", ",")) >= Convert.ToDecimal(coefx2[k].Replace(".", ",")))
                                                {
                                                    numberx = 1;
                                                    vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                }
                                                else
                                                {
                                                    numberx = 2;
                                                    vilka_cfx = Convert.ToDecimal(coefx2[k].Replace(".", ","));
                                                }
                                            }

                                            bool proverka = true;
                                            for (int n = 0; n < zapret.Count; n = n + 4)
                                            {
                                                //запрет уже с перевернутыми командами, он из грида. так что если нужно здесь перевернуть, то переворачивать.
                                                if (command2[i] == zapret[n] && command1[i] == zapret[n + 1] && command12[k] == zapret[n + 2] && command22[k] == zapret[n + 3])
                                                {
                                                    proverka = false;
                                                }
                                            }

                                            if ((((1 / vilka_cfx) + (1 / vilka_cf1) + (1 / vilka_cf2)) < 1) && proverka == true)
                                            {

                                                int stage = 1;
                                                number_obnul++;
                                                Params pp = new Params();
                                                pp.coef1 = coef1;
                                                pp.coef12 = coef12;
                                                pp.coef2 = coef2;
                                                pp.coef22 = coef22;
                                                pp.coefx = coefx;
                                                pp.coefx2 = coefx2;
                                                pp.command1 = command1;
                                                pp.command12 = command12;
                                                pp.command2 = command2;
                                                pp.command22 = command22;
                                                pp.countokras = countokras;
                                                pp.i = i;
                                                pp.k = k;
                                                pp.matches = matches;
                                                pp.matches2 = matches2;
                                                pp.number1 = number1;
                                                pp.number2 = number2;
                                                pp.numberx = numberx;
                                                pp.number_obnul = number_obnul;
                                                pp.stage = stage;
                                                pp.href1 = href1;
                                                pp.href2 = href2;
                                                pp.bukmeker1 = "1XBet";
                                                pp.bukmeker2 = "Parimatch";
                                                pp.vilka_cf1 = vilka_cf1;
                                                pp.vilka_cf2 = vilka_cf2;
                                                pp.vilka_cfx = vilka_cfx;

                                                backgroundWorker2.ReportProgress(0, pp);
                                                countokras++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }



                    if (ligaiswork == "work")
                    {
                        //ANALYS
                        //1xbet и liga stavok
                        for (int i = 0; i < matches.Count; i++)
                        {
                            for (int k = 0; k < matches_liga.Count; k++)
                            {
                                //if (coef1[i] != "-" && coef2[i] != "-" && coefx[i] != "-" && coef12[k] != "-" && coef22[k] != "-" && coefx2[k] != "-")
                                bool iscommand = false;
                                bool peremena_comand = false;
                                if (command1[i].Contains(command1_liga[k]) || command2[i].Contains(command2_liga[k]))
                                {
                                    iscommand = true;
                                    peremena_comand = false;
                                }
                                else if (command1_liga[k].Contains(command1[i]) || command2_liga[k].Contains(command2[i]))
                                {
                                    iscommand = true;
                                    peremena_comand = false;
                                }
                                else if (command1_liga[k].Contains(command2[i]) || command2_liga[k].Contains(command1[i]))
                                {
                                    iscommand = true;
                                    peremena_comand = true;
                                }
                                else if (command2[i].Contains(command1_liga[k]) || command1[i].Contains(command2_liga[k]))
                                {
                                    iscommand = true;
                                    peremena_comand = true;
                                }

                                if (iscommand == true)
                                {
                                    if (peremena_comand == false)
                                    {
                                        //проверяем есть ли все коэффициенты в командах, 1 Х 2. если одного какого-то нет, то вилку нет смысла искать.
                                        if ((coef1[i] != "-" || coef1_liga[k] != "-") && (coef2[i] != "-" || coef2_liga[k] != "-") && (coefx[i] != "-" || coefx_liga[k] != "-"))
                                        {
                                            decimal vilka_cf1, vilka_cf2, vilka_cfx;
                                            int number1, numberx, number2;

                                            if (coef1[i] == "-" || coef1_liga[k] == "-")
                                            {
                                                if (coef1[i] == "-")
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                    number1 = 2;
                                                }
                                                else// (coef12[k] == "-") 
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                    number1 = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coef1[i].Replace(".", ",")) >= Convert.ToDecimal(coef1_liga[k].Replace(".", ",")))
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                    number1 = 1;
                                                }
                                                else
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                    number1 = 2;
                                                }
                                            }




                                            if (coef2[i] == "-" || coef2_liga[k] == "-")
                                            {
                                                if (coef2[i] == "-")
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                    number2 = 2;
                                                }
                                                else // (coef22[k] == "-")
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                    number2 = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coef2[i].Replace(".", ",")) >= Convert.ToDecimal(coef2_liga[k].Replace(".", ",")))
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                    number2 = 1;
                                                }
                                                else
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                    number2 = 2;
                                                }
                                            }




                                            if (coefx[i] == "-" || coefx_liga[k] == "-")
                                            {
                                                if (coefx[i] == "-")
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    numberx = 2;
                                                }
                                                else //(coefx2[k] == "-")
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                    numberx = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coefx[i].Replace(".", ",")) >= Convert.ToDecimal(coefx_liga[k].Replace(".", ",")))
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                    numberx = 1;
                                                }
                                                else
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    numberx = 2;
                                                }
                                            }

                                            bool proverka = true;
                                            for (int n = 0; n < zapret.Count; n = n + 4)
                                            {
                                                //запрет уже с перевернутыми командами, он из грида. так что если нужно здесь перевернуть, то переворачивать.
                                                if (command1[i] == zapret[n] && command2[i] == zapret[n + 1] && command1_liga[k] == zapret[n + 2] && command2_liga[k] == zapret[n + 3])
                                                {
                                                    proverka = false;
                                                }
                                            }

                                            if ((((1 / vilka_cfx) + (1 / vilka_cf1) + (1 / vilka_cf2)) < 1) && proverka == true)
                                            {

                                                int stage = 0;
                                                number_obnul++;
                                                Params pp = new Params();
                                                pp.coef1 = coef1;
                                                pp.coef12 = coef1_liga;
                                                pp.coef2 = coef2;
                                                pp.coef22 = coef2_liga;
                                                pp.coefx = coefx;
                                                pp.coefx2 = coefx_liga;
                                                pp.command1 = command1;
                                                pp.command12 = command1_liga;
                                                pp.command2 = command2;
                                                pp.command22 = command2_liga;
                                                pp.countokras = countokras;
                                                pp.i = i;
                                                pp.k = k;
                                                pp.matches = matches;
                                                pp.matches2 = matches_liga;
                                                pp.number1 = number1;
                                                pp.number2 = number2;
                                                pp.numberx = numberx;
                                                pp.number_obnul = number_obnul;
                                                pp.stage = stage;
                                                pp.vilka_cf1 = vilka_cf1;
                                                pp.vilka_cf2 = vilka_cf2;
                                                pp.vilka_cfx = vilka_cfx;
                                                pp.href1 = href1;
                                                pp.href2 = href1_liga;
                                                pp.bukmeker1 = "1XBet";
                                                pp.bukmeker2 = "Лига Ставок";
                                                backgroundWorker2.ReportProgress(0, pp);
                                                countokras++;
                                                //backgroundWorker2.ReportProgress(0, "stage=0" + " i=" + i.ToString() + " k=" + k.ToString() + " countokras=" + countokras.ToString() + " vilka_cf1=" + vilka_cf1.ToString() + " vilka_cfx=" + vilka_cfx.ToString() + " vilka_cf2=" + vilka_cf2.ToString() + " number1=" + number1.ToString() + " number2=" + number2.ToString() + " numberx=" + numberx.ToString() + " number_obnul=" + number_obnul.ToString() + " ");

                                            }
                                        }
                                        else
                                        {
                                            //если команды перевернуты местами, то переворачиваем коэфы в первой (1хбет)
                                            if ((coef2[i] != "-" || coef1_liga[k] != "-") && (coef1[i] != "-" || coef2_liga[k] != "-") && (coefx[i] != "-" || coefx_liga[k] != "-"))
                                            {
                                                decimal vilka_cf1, vilka_cf2, vilka_cfx;
                                                int number1, numberx, number2;

                                                if (coef2[i] == "-" || coef1_liga[k] == "-")
                                                {
                                                    if (coef2[i] == "-")
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                        number1 = 2;
                                                    }
                                                    else// (coef12[k] == "-")
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                        number1 = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(coef2[i].Replace(".", ",")) >= Convert.ToDecimal(coef1_liga[k].Replace(".", ",")))
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef2[i].Replace(".", ","));
                                                        number1 = 1;
                                                    }
                                                    else
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                        number1 = 2;
                                                    }
                                                }



                                                if (coef1[i] == "-" || coef2_liga[k] == "-")
                                                {
                                                    if (coef1[i] == "-")
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                        number2 = 2;
                                                    }
                                                    else // (coef22[k] == "-")
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                        number2 = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(coef1[i].Replace(".", ",")) >= Convert.ToDecimal(coef2_liga[k].Replace(".", ",")))
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef1[i].Replace(".", ","));
                                                        number2 = 1;
                                                    }
                                                    else
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                        number2 = 2;
                                                    }
                                                }




                                                if (coefx[i] == "-" || coefx_liga[k] == "-")
                                                {
                                                    if (coefx[i] == "-")
                                                    {
                                                        numberx = 2;
                                                        vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    }
                                                    else //(coefx2[k] == "-")
                                                    {
                                                        numberx = 1;
                                                        vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(coefx[i].Replace(".", ",")) >= Convert.ToDecimal(coefx_liga[k].Replace(".", ",")))
                                                    {
                                                        numberx = 1;
                                                        vilka_cfx = Convert.ToDecimal(coefx[i].Replace(".", ","));
                                                    }
                                                    else
                                                    {
                                                        numberx = 2;
                                                        vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    }
                                                }

                                                bool proverka = true;
                                                for (int n = 0; n < zapret.Count; n = n + 4)
                                                {
                                                    //запрет уже с перевернутыми командами, он из грида. так что если нужно здесь перевернуть, то переворачивать.
                                                    if (command2[i] == zapret[n] && command1[i] == zapret[n + 1] && command1_liga[k] == zapret[n + 2] && command2_liga[k] == zapret[n + 3])
                                                    {
                                                        proverka = false;
                                                    }
                                                }

                                                if ((((1 / vilka_cfx) + (1 / vilka_cf1) + (1 / vilka_cf2)) < 1) && proverka == true)
                                                {

                                                    int stage = 1;
                                                    number_obnul++;
                                                    Params pp = new Params();
                                                    pp.coef1 = coef1;
                                                    pp.coef12 = coef1_liga;
                                                    pp.coef2 = coef2;
                                                    pp.coef22 = coef2_liga;
                                                    pp.coefx = coefx;
                                                    pp.coefx2 = coefx_liga;
                                                    pp.command1 = command1;
                                                    pp.command12 = command1_liga;
                                                    pp.command2 = command2;
                                                    pp.command22 = command2_liga;
                                                    pp.countokras = countokras;
                                                    pp.i = i;
                                                    pp.k = k;
                                                    pp.matches = matches;
                                                    pp.matches2 = matches_liga;
                                                    pp.number1 = number1;
                                                    pp.number2 = number2;
                                                    pp.numberx = numberx;
                                                    pp.number_obnul = number_obnul;
                                                    pp.stage = stage;
                                                    pp.href1 = href1;
                                                    pp.href2 = href1_liga;
                                                    pp.bukmeker1 = "1XBet";
                                                    pp.bukmeker2 = "Лига Ставок";
                                                    pp.vilka_cf1 = vilka_cf1;
                                                    pp.vilka_cf2 = vilka_cf2;
                                                    pp.vilka_cfx = vilka_cfx;

                                                    backgroundWorker2.ReportProgress(0, pp);
                                                    countokras++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }







                    if (ligaiswork == "work")
                    {
                        //ANALYS
                        //Parimatch and liga stavok
                        for (int i = 0; i < matches2.Count; i++)
                        {
                            for (int k = 0; k < matches_liga.Count; k++)
                            {
                                //if (coef1[i] != "-" && coef2[i] != "-" && coefx[i] != "-" && coef12[k] != "-" && coef22[k] != "-" && coefx2[k] != "-")
                                bool iscommand = false;
                                bool peremena_comand = false;
                                if (command12[i].Contains(command1_liga[k]) || command22[i].Contains(command2_liga[k]))
                                {
                                    iscommand = true;
                                    peremena_comand = false;
                                }
                                else if (command1_liga[k].Contains(command12[i]) || command2_liga[k].Contains(command22[i]))
                                {
                                    iscommand = true;
                                    peremena_comand = false;
                                }
                                else if (command1_liga[k].Contains(command22[i]) || command2_liga[k].Contains(command12[i]))
                                {
                                    iscommand = true;
                                    peremena_comand = true;
                                }
                                else if (command22[i].Contains(command1_liga[k]) || command12[i].Contains(command2_liga[k]))
                                {
                                    iscommand = true;
                                    peremena_comand = true;
                                }

                                if (iscommand == true)
                                {
                                    if (peremena_comand == false)
                                    {
                                        //проверяем есть ли все коэффициенты в командах, 1 Х 2. если одного какого-то нет, то вилку нет смысла искать.
                                        if ((coef12[i] != "-" || coef1_liga[k] != "-") && (coef22[i] != "-" || coef2_liga[k] != "-") && (coefx2[i] != "-" || coefx_liga[k] != "-"))
                                        {
                                            decimal vilka_cf1, vilka_cf2, vilka_cfx;
                                            int number1, numberx, number2;

                                            if (coef12[i] == "-" || coef1_liga[k] == "-")
                                            {
                                                if (coef12[i] == "-")
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                    number1 = 2;
                                                }
                                                else// (coef12[k] == "-") 
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef12[i].Replace(".", ","));
                                                    number1 = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coef12[i].Replace(".", ",")) >= Convert.ToDecimal(coef1_liga[k].Replace(".", ",")))
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef12[i].Replace(".", ","));
                                                    number1 = 1;
                                                }
                                                else
                                                {
                                                    vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                    number1 = 2;
                                                }
                                            }




                                            if (coef22[i] == "-" || coef2_liga[k] == "-")
                                            {
                                                if (coef22[i] == "-")
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                    number2 = 2;
                                                }
                                                else // (coef22[k] == "-")
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef22[i].Replace(".", ","));
                                                    number2 = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coef22[i].Replace(".", ",")) >= Convert.ToDecimal(coef2_liga[k].Replace(".", ",")))
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef22[i].Replace(".", ","));
                                                    number2 = 1;
                                                }
                                                else
                                                {
                                                    vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                    number2 = 2;
                                                }
                                            }




                                            if (coefx2[i] == "-" || coefx_liga[k] == "-")
                                            {
                                                if (coefx2[i] == "-")
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    numberx = 2;
                                                }
                                                else //(coefx2[k] == "-")
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx2[i].Replace(".", ","));
                                                    numberx = 1;
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDecimal(coefx2[i].Replace(".", ",")) >= Convert.ToDecimal(coefx_liga[k].Replace(".", ",")))
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx2[i].Replace(".", ","));
                                                    numberx = 1;
                                                }
                                                else
                                                {
                                                    vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    numberx = 2;
                                                }
                                            }

                                            bool proverka = true;
                                            for (int n = 0; n < zapret.Count; n = n + 4)
                                            {
                                                //запрет уже с перевернутыми командами, он из грида. так что если нужно здесь перевернуть, то переворачивать.
                                                if (command12[i] == zapret[n] && command22[i] == zapret[n + 1] && command1_liga[k] == zapret[n + 2] && command2_liga[k] == zapret[n + 3])
                                                {
                                                    proverka = false;
                                                }
                                            }

                                            if ((((1 / vilka_cfx) + (1 / vilka_cf1) + (1 / vilka_cf2)) < 1) && proverka == true)
                                            {

                                                int stage = 0;
                                                number_obnul++;
                                                Params pp = new Params();
                                                pp.coef1 = coef12;
                                                pp.coef12 = coef1_liga;
                                                pp.coef2 = coef22;
                                                pp.coef22 = coef2_liga;
                                                pp.coefx = coefx2;
                                                pp.coefx2 = coefx_liga;
                                                pp.command1 = command12;
                                                pp.command12 = command1_liga;
                                                pp.command2 = command22;
                                                pp.command22 = command2_liga;
                                                pp.countokras = countokras;
                                                pp.i = i;
                                                pp.k = k;
                                                pp.matches = matches2;
                                                pp.matches2 = matches_liga;
                                                pp.number1 = number1;
                                                pp.number2 = number2;
                                                pp.numberx = numberx;
                                                pp.number_obnul = number_obnul;
                                                pp.stage = stage;
                                                pp.vilka_cf1 = vilka_cf1;
                                                pp.vilka_cf2 = vilka_cf2;
                                                pp.vilka_cfx = vilka_cfx;
                                                pp.href1 = href2;
                                                pp.href2 = href1_liga;
                                                pp.bukmeker1 = "Parimatch";
                                                pp.bukmeker2 = "Лига Ставок";
                                                backgroundWorker2.ReportProgress(0, pp);
                                                countokras++;
                                                //backgroundWorker2.ReportProgress(0, "stage=0" + " i=" + i.ToString() + " k=" + k.ToString() + " countokras=" + countokras.ToString() + " vilka_cf1=" + vilka_cf1.ToString() + " vilka_cfx=" + vilka_cfx.ToString() + " vilka_cf2=" + vilka_cf2.ToString() + " number1=" + number1.ToString() + " number2=" + number2.ToString() + " numberx=" + numberx.ToString() + " number_obnul=" + number_obnul.ToString() + " ");

                                            }
                                        }
                                        else
                                        {
                                            //если команды перевернуты местами, то переворачиваем коэфы в первой (1хбет)
                                            if ((coef22[i] != "-" || coef1_liga[k] != "-") && (coef12[i] != "-" || coef2_liga[k] != "-") && (coefx2[i] != "-" || coefx_liga[k] != "-"))
                                            {
                                                decimal vilka_cf1, vilka_cf2, vilka_cfx;
                                                int number1, numberx, number2;

                                                if (coef22[i] == "-" || coef1_liga[k] == "-")
                                                {
                                                    if (coef22[i] == "-")
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                        number1 = 2;
                                                    }
                                                    else// (coef12[k] == "-")
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef22[i].Replace(".", ","));
                                                        number1 = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(coef22[i].Replace(".", ",")) >= Convert.ToDecimal(coef1_liga[k].Replace(".", ",")))
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef22[i].Replace(".", ","));
                                                        number1 = 1;
                                                    }
                                                    else
                                                    {
                                                        vilka_cf1 = Convert.ToDecimal(coef1_liga[k].Replace(".", ","));
                                                        number1 = 2;
                                                    }
                                                }



                                                if (coef12[i] == "-" || coef2_liga[k] == "-")
                                                {
                                                    if (coef12[i] == "-")
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                        number2 = 2;
                                                    }
                                                    else // (coef22[k] == "-")
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef12[i].Replace(".", ","));
                                                        number2 = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(coef12[i].Replace(".", ",")) >= Convert.ToDecimal(coef2_liga[k].Replace(".", ",")))
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef12[i].Replace(".", ","));
                                                        number2 = 1;
                                                    }
                                                    else
                                                    {
                                                        vilka_cf2 = Convert.ToDecimal(coef2_liga[k].Replace(".", ","));
                                                        number2 = 2;
                                                    }
                                                }




                                                if (coefx2[i] == "-" || coefx_liga[k] == "-")
                                                {
                                                    if (coefx2[i] == "-")
                                                    {
                                                        numberx = 2;
                                                        vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    }
                                                    else //(coefx2[k] == "-")
                                                    {
                                                        numberx = 1;
                                                        vilka_cfx = Convert.ToDecimal(coefx2[i].Replace(".", ","));
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal(coefx2[i].Replace(".", ",")) >= Convert.ToDecimal(coefx_liga[k].Replace(".", ",")))
                                                    {
                                                        numberx = 1;
                                                        vilka_cfx = Convert.ToDecimal(coefx2[i].Replace(".", ","));
                                                    }
                                                    else
                                                    {
                                                        numberx = 2;
                                                        vilka_cfx = Convert.ToDecimal(coefx_liga[k].Replace(".", ","));
                                                    }
                                                }

                                                bool proverka = true;
                                                for (int n = 0; n < zapret.Count; n = n + 4)
                                                {
                                                    //запрет уже с перевернутыми командами, он из грида. так что если нужно здесь перевернуть, то переворачивать.
                                                    if (command22[i] == zapret[n] && command12[i] == zapret[n + 1] && command1_liga[k] == zapret[n + 2] && command2_liga[k] == zapret[n + 3])
                                                    {
                                                        proverka = false;
                                                    }
                                                }

                                                if ((((1 / vilka_cfx) + (1 / vilka_cf1) + (1 / vilka_cf2)) < 1) && proverka == true)
                                                {

                                                    int stage = 1;
                                                    number_obnul++;
                                                    Params pp = new Params();
                                                    pp.coef1 = coef12;
                                                    pp.coef12 = coef1_liga;
                                                    pp.coef2 = coef22;
                                                    pp.coef22 = coef2_liga;
                                                    pp.coefx = coefx2;
                                                    pp.coefx2 = coefx_liga;
                                                    pp.command1 = command12;
                                                    pp.command12 = command1_liga;
                                                    pp.command2 = command22;
                                                    pp.command22 = command2_liga;
                                                    pp.countokras = countokras;
                                                    pp.i = i;
                                                    pp.k = k;
                                                    pp.matches = matches2;
                                                    pp.matches2 = matches_liga;
                                                    pp.number1 = number1;
                                                    pp.number2 = number2;
                                                    pp.numberx = numberx;
                                                    pp.number_obnul = number_obnul;
                                                    pp.stage = stage;
                                                    pp.href1 = href2;
                                                    pp.href2 = href1_liga;
                                                    pp.bukmeker1 = "Parimatch";
                                                    pp.bukmeker2 = "Лига Ставок";
                                                    pp.vilka_cf1 = vilka_cf1;
                                                    pp.vilka_cf2 = vilka_cf2;
                                                    pp.vilka_cfx = vilka_cfx;

                                                    backgroundWorker2.ReportProgress(0, pp);
                                                    countokras++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }





                    Params pn = new Params();
                    pn.stage = 2;
                    backgroundWorker2.ReportProgress(0, pn);

                    //  Browser.Quit();
                    TimeSpan ss = DateTime.Now - dd;
                    int sec = 0, milsec = 0;
                    milsec = Convert.ToInt32(ss.TotalMilliseconds) - (Convert.ToInt32(ss.Seconds) * 1000);
                    sec = Convert.ToInt32(ss.Seconds);

                    Params pz = new Params();
                    pz.stage = 3;
                    pz.sec = sec;
                    pz.milsec = milsec;
                    backgroundWorker2.ReportProgress(0, pz);
                }
                catch
                {
                    // Browser.Quit();
                    Params py = new Params();
                    py.stage = 4;
                    backgroundWorker2.ReportProgress(0, py);
                }
            }
        }







        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Params pg = new Params();
                pg = (Params)e.UserState;
                int stage = pg.stage;

                if (Convert.ToInt32(stage) == 0)
                {

                    if (pg.number_obnul == 1)
                    {
                        while (DG_vilkins.Rows.Count != 0)
                            DG_vilkins.Rows.Remove(DG_vilkins.Rows[DG_vilkins.Rows.Count - 1]);
                    }

                   // int i = Convert.ToInt32(Convert.ToString(e.UserState).Substring("i=", " "));
                    //int k = Convert.ToInt32(Convert.ToString(e.UserState).Substring("k=", " "));
                    for (int n = 0; n < 2; n++)
                    {
                        DataGridViewRow Row = new DataGridViewRow();
                        Row.Height = 37;
                        DG_vilkins.Rows.Add(Row);
                    }

                    if (pg.countokras % 2 == 0)
                    {
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightGray;
                    }

                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[0].Value = pg.bukmeker1;
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[1].Value = pg.command1[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[2].Value = pg.command2[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[3].Value = pg.coef1[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[4].Value = pg.coefx[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[5].Value = pg.coef2[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[7].Value = "Copy";
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[7].Tag = pg.href1[pg.i];
                    decimal procent;
                    procent = Convert.ToDecimal(1 - ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                    procent = procent * 100;
                    procent = Math.Round(procent, 1);
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[6].Value = procent + "%";

                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[0].Value = pg.bukmeker2;
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[1].Value = pg.command12[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[2].Value = pg.command22[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[3].Value = pg.coef12[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[4].Value = pg.coefx2[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[5].Value = pg.coef22[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[7].Value = "Copy";
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[7].Tag = pg.href2[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[6].Value = procent + "%";

                    try
                    {
                        if (textBox3.Text != "")
                        {
                            decimal allmoney = Convert.ToDecimal(textBox3.Text);
                            int money1x = Convert.ToInt32((allmoney * (1 / pg.vilka_cf1)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            int moneyx = Convert.ToInt32((allmoney * (1 / pg.vilka_cfx)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            int moneyx2 = Convert.ToInt32((allmoney * (1 / pg.vilka_cf2)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));

                            if (pg.number1 == 1)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[3].Value += " (" + money1x + ")";
                            else if (pg.number1 == 2)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[3].Value += " (" + money1x + ")";

                            if (pg.numberx == 1)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[4].Value += " (" + moneyx + ")";
                            else if (pg.numberx == 2)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[4].Value += " (" + moneyx + ")";

                            if (pg.number2 == 1)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[5].Value += " (" + moneyx2 + ")";
                            else if (pg.number2 == 2)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[5].Value += " (" + moneyx2 + ")";

                            decimal average_money = (money1x * pg.vilka_cf1 + moneyx * pg.vilka_cfx + moneyx2 * pg.vilka_cf2) / 3;
                            decimal one_proc = allmoney / 100;
                            decimal all_procents = average_money / one_proc;
                            decimal real_procent = Math.Round((all_procents - 100), 2);

                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[6].Value = real_procent + "%";
                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[6].Value = real_procent + "%";
                        }
                        else
                        {
                            decimal allmoney = 100;
                            decimal money1x = Convert.ToDecimal((allmoney * (1 / pg.vilka_cf1)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            decimal moneyx = Convert.ToDecimal((allmoney * (1 / pg.vilka_cfx)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            decimal moneyx2 = Convert.ToDecimal((allmoney * (1 / pg.vilka_cf2)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));

                            decimal average_money = (money1x*pg.vilka_cf1 + moneyx*pg.vilka_cfx + moneyx2*pg.vilka_cf2) / 3;
                            decimal one_proc = allmoney / 100;
                            decimal all_procents = average_money / one_proc;
                            decimal real_procent = Math.Round((all_procents - 100), 2);

                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[6].Value = real_procent + "%";
                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[6].Value = real_procent + "%";
                        }
                    }
                    catch { }

                    pg.countokras++;

                    if (pg.number1 == 1)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[3].Style.BackColor = Color.LightGreen;
                    else if (pg.number1 == 2)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightGreen;

                    if (pg.numberx == 1)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[4].Style.BackColor = Color.LightGreen;
                    else if (pg.numberx == 2)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[4].Style.BackColor = Color.LightGreen;

                    if (pg.number2 == 1)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[5].Style.BackColor = Color.LightGreen;
                    else if (pg.number2 == 2)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[5].Style.BackColor = Color.LightGreen;
                }
                else if (Convert.ToInt32(stage) == 1)
                {

                    if (pg.number_obnul == 1)
                    {
                        while (DG_vilkins.Rows.Count != 0)
                            DG_vilkins.Rows.Remove(DG_vilkins.Rows[DG_vilkins.Rows.Count - 1]);
                    }

                    for (int n = 0; n < 2; n++)
                    {
                        DataGridViewRow Row = new DataGridViewRow();
                        Row.Height = 37;
                        DG_vilkins.Rows.Add(Row);
                    }

                    if (pg.countokras % 2 == 0)
                    {
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightGray;
                    }

                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[0].Value = pg.bukmeker1;
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[1].Value = pg.command2[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[2].Value = pg.command1[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[3].Value = pg.coef2[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[4].Value = pg.coefx[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[5].Value = pg.coef1[pg.i];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[7].Value = "Copy";
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[7].Tag = pg.href1[pg.i];
                    decimal procent;
                    procent = Convert.ToDecimal(1 - ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                    procent = procent * 100;
                    procent = Math.Round(procent, 1);
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[6].Value = procent.ToString() + "%";

                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[0].Value = pg.bukmeker2;
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[1].Value = pg.command12[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[2].Value = pg.command22[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[3].Value = pg.coef12[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[4].Value = pg.coefx2[pg.k];
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[5].Value = pg.coef22[pg.k];

                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[7].Value = "Copy";
                    DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[7].Tag = pg.href2[pg.k];

                   DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[6].Value = procent.ToString() + "%";

                    try
                    {
                        if (textBox3.Text != "")
                        {
                            decimal allmoney = Convert.ToDecimal(textBox3.Text);
                            int money1x = Convert.ToInt32((allmoney * (1 / pg.vilka_cf1))/ ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            int moneyx = Convert.ToInt32((allmoney * (1 / pg.vilka_cfx))/ ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            int moneyx2 = Convert.ToInt32((allmoney * (1 / pg.vilka_cf2))/ ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));

                            if (pg.number1 == 1)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[3].Value += " (" + money1x +  ")";
                            else if (pg.number1 == 2)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[3].Value += " (" + money1x + ")";

                            if (pg.numberx == 1)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[4].Value += " (" + moneyx + ")";
                            else if (pg.numberx == 2)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[4].Value += " (" + moneyx + ")";

                            if (pg.number2 == 1)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[5].Value += " (" + moneyx2 + ")";
                            else if (pg.number2 == 2)
                                DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[5].Value += " (" + moneyx2 + ")";

                            decimal average_money = (money1x * pg.vilka_cf1 + moneyx * pg.vilka_cfx + moneyx2 * pg.vilka_cf2) / 3;
                            decimal one_proc = allmoney / 100;
                            decimal all_procents = average_money / one_proc;
                            decimal real_procent = Math.Round((all_procents - 100), 2);

                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[6].Value = real_procent + "%";
                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[6].Value = real_procent + "%";

                        }
                        else
                        {
                            decimal allmoney = 100;
                            decimal money1x = Convert.ToDecimal((allmoney * (1 / pg.vilka_cf1)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            decimal moneyx = Convert.ToDecimal((allmoney * (1 / pg.vilka_cfx)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));
                            decimal moneyx2 = Convert.ToDecimal((allmoney * (1 / pg.vilka_cf2)) / ((1 / pg.vilka_cfx) + (1 / pg.vilka_cf1) + (1 / pg.vilka_cf2)));

                            decimal average_money = (money1x * pg.vilka_cf1 + moneyx * pg.vilka_cfx + moneyx2 * pg.vilka_cf2) / 3;
                            decimal one_proc = allmoney / 100;
                            decimal all_procents = average_money / one_proc;
                            decimal real_procent = Math.Round((all_procents - 100), 2);

                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[6].Value = real_procent + "%";
                            DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[6].Value = real_procent + "%";
                        }
                    }
                    catch { }

                    pg.countokras++;

                    if (pg.number1 == 1)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[3].Style.BackColor = Color.LightGreen;
                    else if (pg.number1 == 2)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightGreen;

                    if (pg.numberx == 1)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[4].Style.BackColor = Color.LightGreen;
                    else if (pg.numberx == 2)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[4].Style.BackColor = Color.LightGreen;

                    if (pg.number2 == 1)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 2].Cells[5].Style.BackColor = Color.LightGreen;
                    else if (pg.number2 == 2)
                        DG_vilkins.Rows[DG_vilkins.Rows.Count - 1].Cells[5].Style.BackColor = Color.LightGreen;
                }

                else if (Convert.ToInt32(stage) == 2)
                {
                    try
                    {
                        for (int i = 0; i < DG_vilkins.RowCount; i++)
                        {
                            if (DG_vilkins.Rows[i].Cells[0].Value == null && DG_vilkins.Rows[i].Cells[1].Value == null && DG_vilkins.Rows[i].Cells[2].Value == null)
                            {
                                DG_vilkins.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    catch { }
                    foreach (DataGridViewColumn column in DG_vilkins.Columns)
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                else if (Convert.ToInt32(stage) == 3)
                {
                    string milsec, sec;
                    milsec = Convert.ToString(pg.milsec);
                    sec = Convert.ToString(pg.sec);

                    label_time.Text = "Примерное время обновления: " + sec.ToString() + " секунд " + milsec.ToString() + " миллисек.";
                        label4.Text = "Работает";
                        label4.ForeColor = Color.Green;
                }

                else if (Convert.ToInt32(stage) == 4)
                {
                    label4.Text = "Не работает";
                    label4.ForeColor = Color.Red;
                }
            }
            catch
            {
                label4.Text = "Не работает";
                label4.ForeColor = Color.Red;
                //  Browser.Quit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                mirror_actor_1 = textBox1.Text;
                mirror_actor_pari = textBox2.Text;
            }
            backgroundWorker1.RunWorkerAsync();

        }
    }
}
/*
               brow.Get("https://pm-422.info/live.html");
               System.Threading.Thread.Sleep(3000);
               richTextBox1.Text = brow.Document;

               /* бет365 блокирует контент от частого захода, либо же это блокировка сама происходит от сервера. короче не подходит.
               Browser.Navigate().GoToUrl("https://www.348365365.com/#/IP/");
               System.Threading.Thread.Sleep(2000);
               Browser.FindElement(By.XPath("//*[@id=\"dv1\"]/a")).Click();
               System.Threading.Thread.Sleep(4000);
               Browser.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div[1]/nav/a[2]")).Click();
               System.Threading.Thread.Sleep(8000);
               richTextBox1.Text = Browser.PageSource;
               richTextBox1.Text = HTML.ExtractTag(Browser.PageSource, "div", "class=\"ipo-CompetitionRenderer \"");

            //   brow.

               */
