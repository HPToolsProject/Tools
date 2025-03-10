using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Net.Http;
using System.Text;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Text.RegularExpressions;
using MailKit.Security;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.BiDi.Modules.Network;
using System.Reflection;
using Org.BouncyCastle.Tls;
using System.Drawing.Printing;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Diagnostics;
using System.Linq.Expressions;
using OpenQA.Selenium.DevTools.V131.Debugger;






namespace ToolsRestartPassApple
{
    public partial class Form1: Form
    {
        private static readonly HttpClient client = new HttpClient();
        private int so_luong;
        private SemaphoreSlim semaphore; // Giới hạn số luồng chạy cùng lúc
        public Form1()
        {
            InitializeComponent();
            so_luong = (int)soluong.Value;
            this.FormClosing += this.fmain_FormClosing;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string data = File.ReadAllText("config.txt");
                soluong.Value = Convert.ToInt16(data.Split('|')[0]);
                API_key.Text = data.Split('|')[1];
                password.Text = data.Split('|')[2];
                randompasscheck.Checked = Convert.ToBoolean(data.Split('|')[3]);
                cau_trl1.Text = data.Split('|')[4];
                cau_trl2.Text = data.Split('|')[5];
                cau_trl3.Text = data.Split('|')[6];
            }
            catch { }
        }

        private List<string> mails = new List<string>();
        private List<string> recoveryEmails = new List<string>();
        private List<string> recoveryPasswords = new List<string>();
        private List<string> proxyList = new List<string>();
        private bool StopThread;
        private int so_luong_da_chay;
        private List<string> listmailcheck = new List<string>();
        public string Output = "";
        private int soluongdangchay = 0;

        private void fmain_FormClosing(Object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Thông báo ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.No)
                e.Cancel = true;
            else
            {
                string data = $"{soluong.Value}|{API_key.Text}|{password.Text}|{randompasscheck.Checked}|{cau_trl1.Text}|{cau_trl2.Text}|{cau_trl3.Text}";

                // Xóa nội dung cũ và ghi nội dung mới
                File.WriteAllText("config.txt", data);

                Environment.Exit(0);
            }
        }

        private void bnt_start_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show($"Vui lòng thêm Account", "HP Tools");
                return;
            }
            int yy = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                {
                    yy++;
                    break;
                }
            }
            if (yy == 0)
            {
                MessageBox.Show("Vui lòng chọn mail cần chạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string DateFormat = DateTime.Now.ToString("dd-MM-yyy hh-mm-ss");
            Output = Application.StartupPath + @"\Output\Result " + DateFormat;
            if (!Directory.Exists(Output))
            {
                Directory.CreateDirectory(Output);
            }
            soluongdangchay = 0;
            StopThread = false;
            bnt_start.Enabled = false;
            Thread a = new Thread(() =>
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                    {
                        if (StopThread)
                        {
                            break;
                        }
                        while (!StopThread)
                        {
                            if (soluongdangchay < (int)soluong.Value)
                            {
                                break;
                            }
                            Thread.Sleep(500);
                        }
                        HamChay(i, dataGridView1.Rows[i].Cells["Mail"].Value.ToString(), dataGridView1.Rows[i].Cells["Pass"].Value.ToString(), Output);
                        soluongdangchay++;
                        Thread.Sleep(1000);
                    }
                }
                while (!StopThread)
                {
                    Thread.Sleep(1000);
                    if (soluongdangchay <= 0)
                    {
                        break;
                    }
                }
                GC.SuppressFinalize(this);
                GC.WaitForFullGCApproach();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                base.Invoke(new MethodInvoker(delegate ()
                {
                    bnt_start.Enabled = true;
                }));
            });
            a.Start();
            a.IsBackground = true;
        }
        private void SaveDatatoTxt(string path, string content)
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    File.AppendAllText(path, content + "\r\n");
                }));
            }
            catch { }
        }
        private string RandomPassword(int lengthLetters, int lengthDigits)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            Random random = new Random();

            string letters = new string(Enumerable.Repeat(chars, lengthLetters)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            string digits = new string(Enumerable.Repeat(numbers, lengthDigits)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            string password = letters + digits;

            // Xáo trộn mật khẩu để không có chữ số luôn ở cuối
            return new string(password.ToCharArray().OrderBy(x => random.Next()).ToArray());
        }
        private string ReverseProxy(string proxy)
        {
            if (proxy.Contains("@"))
            {
                // proxy dạng username:password@host:port
                var parts = proxy.Split('@');
                var credentials = parts[0].Split(':');
                var hostPort = parts[1];

                if (credentials.Length == 2)
                {
                    var username = credentials[0];
                    var password = credentials[1];
                    return $"{hostPort}:{username}:{password}";
                }
            }
            return proxy;
        }
        void HamChay(int i, string mail, string pass, string folderPath)
        {
            Thread thread = new Thread(() => 
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--window-size=100,600");
                options.AddArgument("--disable-notifications");
                options.AddExcludedArgument("enable-automation");
                options.AddArgument("--log-level=3");

                int max_width = Screen.PrimaryScreen.Bounds.Width;
                int max_height = Screen.PrimaryScreen.Bounds.Height;
                int chromeWidth = max_width / (int)Chieudai.Value;
                int chromeHeight = max_height / (int)Chieurong.Value;
                string chromesize = $"--window-size={chromeWidth},{chromeHeight}";
                options.AddArgument(chromesize);
                int width = chromeWidth;
                int height = chromeHeight;
                int distance_x = chromeWidth - 15;
                int distance_y = chromeHeight - 10;
                int max_column = (max_width - width) / distance_x + 1;
                int max_row = (max_height - height) / distance_y + 1;
                int row = (i % max_column == 0) ? (((i / max_column) % max_row == 0) ? (i / max_column) % max_row + 1 : (i / max_column) % max_row) : (i / max_column) % max_row + 1;
                int column = (i % max_column == 0) ? max_column : i % max_column;
                int margin_width_postion = (column - 1) * distance_x;
                int margin_height_position = (row - 1) * distance_y;
                string position = $"--window-position={margin_width_postion},{margin_height_position}";
                options.AddArgument(position);
                string proxy = "";
                if (proxyList.Count > 0)
                {
                    proxy = proxyList[(i / 1) % proxyList.Count];
                    proxy = ReverseProxy(proxy);
                    dataGridView1.Rows[i].Cells["Proxy"].Value = proxy;
                }
                try
                {
                    int count = Regex.Matches(proxy, ':'.ToString()).Count;
                    if (count == 3)
                    {
                        string host = proxy.Split(':')[0];
                        string port = proxy.Split(':')[1];
                        string fileproxyauth = Directory.GetCurrentDirectory() + "\\Proxy Auto Auth.crx";
                        options.AddExtension(fileproxyauth);
                        options.AddArgument($"--proxy-server={host}:{port}");
                    }
                    else
                    {
                        options.AddArgument($"--proxy-server={proxy}");
                    }
                }
                catch { }

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                IWebDriver driver = new ChromeDriver(service, options);

                try
                {
                    int count = Regex.Matches(proxy, ':'.ToString()).Count;
                    if (count == 3)
                    {
                        string username = proxy.Split(':')[2];
                        string password = proxy.Split(':')[3];
                        Thread.Sleep(2000);
                        var tabs = driver.WindowHandles;
                        driver.Close();
                        Thread.Sleep(2000);
                        try
                        {
                            driver.SwitchTo().Window(tabs[0]);
                        }
                        catch { }
                        Thread.Sleep(2000);
                        driver.Url = "chrome-extension://ggmdpepbjljkkkdaklfihhngmmgmpggp/options.html";
                        Thread.Sleep(3000);
                        driver.FindElement(By.XPath("//*[@id=\"login\"]")).SendKeys(username);
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys(password);
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//*[@id=\"save\"]")).Click();
                        Thread.Sleep(1000);
                    }

                    string new_password = randompasscheck.Checked ? RandomPassword(10,4) : password.Text;
                    dataGridView1.Rows[i].Cells["Status"].Value = "Bắt đầu";

                    driver.Navigate().GoToUrl("https://iforgot.apple.com/password/verify/appleid?language=vi_VN");

                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//input[contains(@class, 'iforgot-apple-id')]")).SendKeys(mail);
                    Thread.Sleep(3000);
                    dataGridView1.Rows[i].Cells["Status"].Value = "Giải captcha";

                    string apiKey = API_key.Text;

                    int maxAttempts = 5;
                    bool captchaSolved = false;


                    for (int attempt = 1; attempt <= maxAttempts; attempt++)
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = $"Giải captcha - Lần {attempt}";

                        // Lấy ảnh CAPTCHA
                        IWebElement imgElement = driver.FindElement(By.XPath("//img[contains(@alt, 'Thử thách bằng ảnh')]"));
                        string imageSrc = imgElement.GetAttribute("src");

                        // Giải CAPTCHA
                        string taskid = SolveCaptcha.Create2captchTask(apiKey, imageSrc);
                        Thread.Sleep(5000); // Chờ API trả về kết quả
                        string captchaCode = SolveCaptcha.Result2captchTask(apiKey, taskid);

                        // Nhập CAPTCHA
                        IWebElement captchaInput = driver.FindElement(By.XPath("//input[contains(@class, 'captcha-input')]"));
                        captchaInput.Clear();
                        captchaInput.SendKeys(captchaCode);
                        dataGridView1.Rows[i].Cells["Status"].Value = captchaCode;

                        Thread.Sleep(3000);

                        // Bấm nút tiếp tục
                        driver.FindElement(By.XPath("//button[contains(@class, 'nav-action') and contains(@class, 'button-primary')]")).Click();
                        Thread.Sleep(3000);

                        // Kiểm tra xem CAPTCHA có sai không
                        try
                        {
                            IWebElement errorElement = driver.FindElement(By.XPath("//span[contains(@class, 'form-message')]"));
                            if (errorElement.Displayed)
                            {
                                // CAPTCHA sai, cần thử lại
                                dataGridView1.Rows[i].Cells["Status"].Value = $"CAPTCHA sai - Thử lại";
                            }
                        }
                        catch (NoSuchElementException)
                        {
                            // Không tìm thấy thông báo lỗi => CAPTCHA đúng
                            dataGridView1.Rows[i].Cells["Status"].Value = "CAPTCHA chính xác";
                            captchaSolved = true; // Đặt cờ thành true
                            break; // Thoát khỏi vòng lặp
                        }

                        if (captchaSolved) //Thoát ra khỏi vòng lặp nếu captcha đã được giải quyết.
                        {
                            break;
                        }
                    }

                    // Kiểm tra nếu sau 10 lần vẫn sai
                    if (!captchaSolved)
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Giải CAPTCHA thất bại sau 10 lần thử!";
                        return;
                    }
                    Thread.Sleep(3000);
                    var button_xac_dinh_bi_ban = driver.FindElements(By.XPath("//button[starts-with(@id, 'button-')]"));
                    if (button_xac_dinh_bi_ban.Any())
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Tài khoản đã bị khóa!";
                        SaveDatatoTxt($@"{folderPath}\ban.txt", $"{mail}|{pass}");
                        return;
                    }
                    var input_sdt = driver.FindElements(By.XPath("//idms-textbox[@input-id=\"phoneNumber\"]"));
                    if (input_sdt.Any())
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Tài khoản dính sdt";
                        SaveDatatoTxt($@"{folderPath}\sdt.txt", $"{mail}|{pass}");
                        return;
                    }
                    //driver.FindElement(By.XPath("//button[@id='action'][1]")).Click();
                    int daan = 0;
                    while (true)
                    {
                        var buttons_tiep_tuc = driver.FindElements(By.XPath("//button[@id='action']"));

                        if (buttons_tiep_tuc.Count == 0)
                            break;

                        foreach (var button in buttons_tiep_tuc)
                        {
                            try
                            {
                                button.Click();
                                Thread.Sleep(5000); // Chờ một chút để trang cập nhật
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi khi bấm nút: " + ex.Message);
                            }
                            daan++;
                        }
                        if (daan > 4)
                        {
                            break;
                        }
                    }

                    Thread.Sleep(2000);
                    for (int x = 0; x < 10; x++)
                    {
                        var OKDONE = driver.FindElements(By.XPath("//i[@class=\"icon icon_green_check success xl desktop\"]"));

                        if (OKDONE.Count == 0)
                        {
                            if (x >= 8)
                            {
                                dataGridView1.Rows[i].Cells["Status"].Value = "Không gửi được code";
                                return;
                            }
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            break;
                        }
                    }

                    dataGridView1.Rows[i].Cells["Status"].Value = "Lấy link đổi pass";
                    string url_re_pass = "";
                    if (mail.EndsWith("freenet.de"))
                    {
                        Thread.Sleep(10000);
                        url_re_pass = GetMail.doc_mail_freenet(mail, pass);
                    }
                    else if (mail.EndsWith("mail.bg"))
                    {
                        Thread.Sleep(10000);
                        url_re_pass = GetMail.doc_mail_mailbg(mail, pass);
                    }
                    else if (mail.EndsWith("mail.com"))
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Loại mail.com này chưa được hỗ trợ!";
                        return;
                    }
                    else if (mail.EndsWith("gmx.com"))
                    {
                        //Thread.Sleep(10000);
                        //string url = doc_mail_gmx_com(driver, recoveryemail, recoverypassword);
                        //driver.Navigate().GoToUrl(url);
                        dataGridView1.Rows[i].Cells["Status"].Value = "Loại mail gmx.com này chưa được hỗ trợ!";
                        
                        return;
                    }
                    else if (mail.EndsWith("gmx.net"))
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Loại mail gmx.net này chưa được hỗ trợ!";
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Loại mail này chưa được hỗ trợ!";
                        return;
                    }
                    if (!string.IsNullOrEmpty(url_re_pass))
                    {
                        driver.Navigate().GoToUrl(url_re_pass);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Ko get được link Recover";
                        return;
                    }
                    dataGridView1.Rows[i].Cells["Status"].Value = "Đặt lại pass";
                    Thread.Sleep(4000);

                    var nut_forgot = driver.FindElements(By.XPath("//button[@class='button-caption-link forgot-pwd']"));
                    if (nut_forgot.Count > 0)
                    {
                        nut_forgot[0].Click();
                    }
                    Thread.Sleep(5000);

                    var passwordFields = driver.FindElements(By.XPath("//input[@type='password']"));
                    foreach (var field in passwordFields)
                    {
                        Thread.Sleep(2000);
                        field.SendKeys(new_password);
                    }

                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//button[@id='action']")).Click();

                    Thread.Sleep(6000);
                    try
                    {
                        driver.FindElement(By.XPath("//button[contains(@class, 'iforgot-btn')]")).Click();

                    }
                    catch { }

                    dataGridView1.Rows[i].Cells["Status"].Value = "Đổi mk thành công";

                    dang_nhap(driver, mail, new_password);
                    dataGridView1.Rows[i].Cells["Status"].Value = "Đăng nhập";

                    Thread.Sleep(6000);

                    var iframes = driver.FindElements(By.TagName("iframe"));
                    if (iframes.Count > 0)
                    {
                        driver.SwitchTo().Frame(iframes[0]); // Switch vào iframe đầu tiên
                    }
                    //driver.SwitchTo().Frame(0);

                    //driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
                    var cau_hoi_bao_mat = driver.FindElements(By.XPath("//input[@type='password' and contains(@aria-describedby, 'question-1')]"));
                    if (cau_hoi_bao_mat.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = "Tài khoản đã có sẵn câu hỏi bảo mật";
                        Thread.Sleep(3000);
                        SaveDatatoTxt($@"{folderPath}\chbm_mail_pass.txt", $"{mail}|{new_password}");
                        return;
                    }
                    Random rand = new Random();
                    int ngay = rand.Next(1, 13);
                    int thang = rand.Next(1, 13);
                    int nam = rand.Next(1985, 2007);
                    bool da_set_ngay_sinh = false;
                    try
                    {
                        Thread.Sleep(3000);
                        var inputFields = driver.FindElements(By.XPath("//input[contains(@class, 'generic-input-field') and contains(@class, 'compact-input')]"));

                        if (inputFields.Count > 0) // Kiểm tra nếu có ít nhất một phần tử được tìm thấy
                        {
                            var inputField = inputFields[0]; // Lấy phần tử đầu tiên (nếu có)
                            Thread.Sleep(500);
                            string thang_ngay_nam = $"{ngay:D2}{thang:D2}{nam}";
                            inputField.SendKeys(thang_ngay_nam);
                            Thread.Sleep(2000);
                            driver.FindElement(By.XPath("//button[@class='button button-primary last nav-action  pull-right weight-medium']")).Click();
                            da_set_ngay_sinh = true;
                        }

                        // Tiếp tục chạy các dòng code tiếp theo nếu không tìm thấy thẻ input
                    }
                    catch (Exception ex)
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = ex.Message;
                    }
                    string cau_tra_loi_1 = cau_trl1.Text;
                    string cau_tra_loi_2 = cau_trl2.Text;
                    string cau_tra_loi_3 = cau_trl3.Text;
                    bool da_set_cau_hoi = false;
                    try
                    {
                        Thread.Sleep(3000);
                        var hasOption = driver.FindElements(By.XPath("//option")).Count > 0;
                        var hasInput = driver.FindElements(By.XPath("//input")).Count > 0;
                        if (hasOption && hasInput)
                        {
                            Thread.Sleep(500);
                            Random random = new Random();
                            //Điền câu hỏi 1
                            int optioncauhoi = 0;
                            var inputFields = driver.FindElements(By.XPath("//input[contains(@class, 'generic-input-field') and contains(@class, 'form-textbox')]"));

                            for (int q = 0; q < 3; q++)
                            {
                                optioncauhoi = q == 0 ? random.Next(130, 136) : q == 1 ? random.Next(136, 142) : q == 2 ? random.Next(142, 148) : 0;
                                driver.FindElement(By.XPath($"//option[@value=\"{optioncauhoi}\"]")).Click();
                                Thread.Sleep(1200);
                                string cautraloi = q == 0 ? cau_tra_loi_1 : q == 1 ? cau_tra_loi_2 : q == 2 ? cau_tra_loi_3 : "";
                                inputFields[q].Clear();
                                Thread.Sleep(500);
                                inputFields[q].SendKeys(cautraloi);
                                Thread.Sleep(2000);
                                if (q == 2)
                                {
                                    driver.FindElement(By.XPath("//button[contains(@class, 'button-primary')]")).Click();
                                    da_set_cau_hoi = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dataGridView1.Rows[i].Cells["Status"].Value = ex.Message;
                    }

                    dataGridView1.Rows[i].Cells["Status"].Value = "Recover success";
                    string ngaythangnamluu = da_set_ngay_sinh ? $"{ngay:D2}/{thang:D2}/{nam}" : "";
                    string cauhoiluu = da_set_cau_hoi ? $"{cau_tra_loi_1}|{cau_tra_loi_2}|{cau_tra_loi_3}" : "";
                    SaveDatatoTxt($@"{folderPath}\Recover_Sucess.txt", $"{mail}|{pass} -> {mail}|{new_password}|{ngaythangnamluu}|{cauhoiluu}");
                    return;
                }
                catch (Exception ex)
                {
                    dataGridView1.Rows[i].Cells["Status"].Value = ex.Message;
                }
                finally
                {
                    dataGridView1.Rows[i].Cells[0].Value = false;
                    if (!kotatchrome.Checked)
                    {
                        driver.Quit();
                    }
                    soluongdangchay--;
                }
            });
            thread.Start();
        }

        private void dang_nhap(IWebDriver driver, string mail, string new_password)
        {
            driver.Navigate().GoToUrl("https://account.apple.com/sign-in");
            Thread.Sleep(5000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // 🔹 Chờ và chuyển vào iframe
            wait.Until(d => d.FindElement(By.Id("aid-auth-widget-iFrame")));
            driver.SwitchTo().Frame("aid-auth-widget-iFrame");

            // 🔹 Nhập email và nhấn "Continue"
            IWebElement accountInput = wait.Until(d => d.FindElement(By.Id("account_name_text_field")));
            accountInput.SendKeys(mail);
            Thread.Sleep(1000);

            IWebElement continueButton = wait.Until(d => d.FindElement(By.Id("sign-in")));
            continueButton.Click();
            Thread.Sleep(7000);  // Chờ trang tải

            // 🔹 Chờ ô nhập mật khẩu xuất hiện
            IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("password_text_field")));
            passwordInput.SendKeys(new_password);
            Thread.Sleep(1000);

            // 🔹 Chờ lại nút "Continue" rồi click lần 2
            continueButton = wait.Until(d => d.FindElement(By.Id("sign-in")));
            continueButton.Click();

        }



        //private string doc_mail_freenet(string mail, string password)
        //{
        //    try
        //    {
        //        using (var client = new ImapClient())
        //        {
        //            // Kết nối đến IMAP Server của Freenet
        //            client.Connect("mx.freenet.de", 993, SecureSocketOptions.SslOnConnect);

        //            // Đăng nhập vào tài khoản
        //            client.Authenticate(mail, password);

        //            // Mở hộp thư Inbox
        //            var inbox = client.Inbox;
        //            inbox.Open(FolderAccess.ReadOnly);

        //            // Duyệt từ email mới nhất về trước, tìm email đầu tiên từ Apple
        //            for (int i = inbox.Count - 1; i >= 0; i--)
        //            {
        //                var message = inbox.GetMessage(i);
        //                if (message.From.ToString().Contains("Apple")) // Chỉ lấy email gần nhất từ Apple
        //                {
        //                    string emailBody = message.TextBody;

        //                    // Regex tìm URL đầu tiên
        //                    string urlPattern = @"(https://iforgot\.apple\.com/verify/email\?key=[^\s]+)";
        //                    Match match = Regex.Match(emailBody, urlPattern);

        //                    if (match.Success)
        //                    {
        //                        client.Disconnect(true);
        //                        string Url = match.Value;
        //                        return Url; 
        //                    }

        //                    break; 
        //                }
        //            }

        //            client.Disconnect(true);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi: {ex.Message}");
        //    }

        //    return null; 
        //}


        private string doc_mail_gmx_com(IWebDriver driver, string recoveryemail, string recoverypassword)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.gmx.com/#.1559516-header-navlogin1-2");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@id='login-email']")).SendKeys(recoveryemail);
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("//input[@id='login-password']")).SendKeys(recoverypassword);
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("//button[@type='submit' and contains(@class, 'login-submit')]")).Click();
                Thread.Sleep(5000);
                string firstUrl = "https://www.youtube.com/watch?v=QlVtc1ImEDQ";
                return firstUrl;
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}"; // Trả về lỗi nếu có
            }
        }



        //private void button1_Click(object sender, EventArgs e)
        //{

        //    ChromeOptions options = new ChromeOptions();
        //    options.AddArgument("--window-size=100,600");
        //    options.AddArgument("--disable-notifications");
        //    options.AddExcludedArgument("enable-automation");
        //    options.AddArgument("--log-level=3");

        //    ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        //    service.HideCommandPromptWindow = true;

        //    IWebDriver driver = new ChromeDriver(service, options);
        //    dang_nhap(driver, "pollmann.1976@freenet.de", "qQwer32154543#@");

        //    try
        //    {
        //        Thread.Sleep(3000);
        //        driver.SwitchTo().Frame(0);
        //        Thread.Sleep(500);

        //        var inputFields = driver.FindElements(By.XPath("//input[contains(@class, 'generic-input-field') and contains(@class, 'compact-input')]"));

        //        if (inputFields.Count > 0) // Kiểm tra nếu có ít nhất một phần tử được tìm thấy
        //        {
        //            var inputField = inputFields[0]; // Lấy phần tử đầu tiên (nếu có)
        //            Thread.Sleep(500);
        //            Random rand = new Random();

        //            int ngay = rand.Next(1, 29);
        //            int thang = rand.Next(1, 13);
        //            int nam = rand.Next(1985, 2007);

        //            string thang_ngay_nam = $"{thang:D2}{ngay:D2}{nam}";
        //            inputField.SendKeys(thang_ngay_nam);
        //        }

        //        // Tiếp tục chạy các dòng code tiếp theo nếu không tìm thấy thẻ input
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            string proxyHost = "103.161.17.15";
            int proxyPort = 49337;
            string proxyUsername = "user49337";
            string proxyPassword = "wdkfyB4jJr";

            ChromeOptions options = new ChromeOptions();

            // Cấu hình Proxy
            options.AddArgument($"--proxy-server={proxyHost}:{proxyPort}");
            options.AddArgument("--window-size=100,600");
            options.AddArgument("--disable-notifications");
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--log-level=3");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            IWebDriver driver = new ChromeDriver(service, options);

            // Khởi tạo WebDriver
            driver.Navigate().GoToUrl("http://example.com"); // Trang đầu để chạy script auth

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript($"window.open('http://{proxyUsername}:{proxyPassword}@{proxyHost}:{proxyPort}');");

            //Console.WriteLine("Trình duyệt đã mở với proxy thành công.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cau_tra_loi_1 = cau_trl1.Text;
            string cau_tra_loi_2 = cau_trl2.Text;
            string cau_tra_loi_3 = cau_trl3.Text;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=100,600");
            options.AddArgument("--disable-notifications");
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--log-level=3");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            IWebDriver driver = new ChromeDriver(service, options);
            dang_nhap(driver, "pfriedel@freenet.de", "Qaz1236t42556789@6");
            //dang_nhap(driver, "pollmann.1976@freenet.de", "qQwer32154543#@");

            try
            {
                Thread.Sleep(3000);
                driver.SwitchTo().Frame(0);
                Thread.Sleep(500);
                Random random = new Random();
                //Điền câu hỏi 1
                int optioncauhoi = 0;
                var inputFields = driver.FindElements(By.XPath("//input[contains(@class, 'generic-input-field') and contains(@class, 'form-textbox')]"));

                for (int i = 0; i < 3; i++)
                {
                    optioncauhoi = i == 0 ? random.Next(130, 136) : i == 1 ? random.Next(136, 142) : i == 2 ? random.Next(142, 148) : 0;
                    driver.FindElement(By.XPath($"//option[@value=\"{optioncauhoi}\"]")).Click();
                    Thread.Sleep(1200);
                    string cautraloi = i == 0 ? cau_tra_loi_1 : i == 1 ? cau_tra_loi_2 : i == 2 ? cau_tra_loi_3 : "";
                    inputFields[i].Clear();
                    Thread.Sleep(500);
                    inputFields[i].SendKeys(cautraloi);
                    Thread.Sleep(2000);
                    //if (i == 2)
                    //{
                    //    driver.FindElement(By.XPath("//button[@class=\"button button-primary last nav-action  disabled  pull-right weight-medium\"]")).Click();
                    //}
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.Message);
            }

            try
            {
                Thread.Sleep(3000);
                driver.SwitchTo().Frame(0);
                Thread.Sleep(500);

                var inputFields = driver.FindElements(By.XPath("//input[contains(@class, 'generic-input-field') and contains(@class, 'compact-input')]"));

                if (inputFields.Count > 0) // Kiểm tra nếu có ít nhất một phần tử được tìm thấy
                {
                    var inputField = inputFields[0]; // Lấy phần tử đầu tiên (nếu có)
                    Thread.Sleep(500);
                    Random rand = new Random();

                    int ngay = rand.Next(1, 29);
                    int thang = rand.Next(1, 13);
                    int nam = rand.Next(1985, 2007);

                    string thang_ngay_nam = $"{thang:D2}{ngay:D2}{nam}";
                    inputField.SendKeys(thang_ngay_nam);
                }

                // Tiếp tục chạy các dòng code tiếp theo nếu không tìm thấy thẻ input
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            


        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (var client = new ImapClient())
        //        {
        //            // Kết nối đến IMAP Server của Freenet
        //            client.Connect("mx.freenet.de", 993, SecureSocketOptions.SslOnConnect);

        //            // Đăng nhập vào tài khoản
        //            client.Authenticate("gullyan@freenet.de", "TestPass123!");

        //            var inbox = client.Inbox;
        //            inbox.Open(FolderAccess.ReadOnly);

        //            // Duyệt từ email mới nhất về trước, tìm email đầu tiên từ Apple
        //            for (int i = inbox.Count - 1; i >= 0; i--)
        //            {
        //                var message = inbox.GetMessage(i);
        //                if (message.From.ToString().Contains("Apple")) // Chỉ lấy email gần nhất từ Apple
        //                {
        //                    string emailBody = message.TextBody;

        //                    // Regex tìm URL đầu tiên
        //                    string urlPattern = @"(https://iforgot\.apple\.com/verify/email\?key=[^\s]+)";
        //                    Match match = Regex.Match(emailBody, urlPattern);

        //                    if (match.Success)
        //                    {
        //                        client.Disconnect(true);
        //                        string Url = match.Value; // Trả về link đầu tiên tìm thấy
        //                    }

        //                    break; // Dừng ngay sau khi tìm thấy email Apple gần nhất
        //                }
        //            }

        //            client.Disconnect(true);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi: {ex.Message}");
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (var client = new ImapClient())
        //        {
        //            // Kết nối đến IMAP Server của Freenet
        //            client.Connect("mx.freenet.de", 993, SecureSocketOptions.SslOnConnect);

        //            // Đăng nhập vào tài khoản


        //            client.Authenticate("gullyan@freenet.de", "TestPass123!");

        //            // Mở hộp thư Inbox
        //            var inbox = client.Inbox;
        //            inbox.Open(FolderAccess.ReadOnly);

        //            List<string> emailContents = new List<string>();
        //            int count = 0;

        //            // Duyệt qua email, lấy 10 email gần nhất
        //            for (int i = inbox.Count - 1; i >= 0 && count < 10; i--)
        //            {
        //                var message = inbox.GetMessage(i);

        //                string emailSender = message.From.ToString(); // Đổi tên biến tránh trùng
        //                string subject = message.Subject;
        //                string emailBody = message.TextBody;

        //                // Thêm nội dung email vào danh sách
        //                emailContents.Add($"==== Email {count + 1} ====");
        //                emailContents.Add($"📩 Người gửi: {emailSender}");
        //                emailContents.Add($"📌 Chủ đề: {subject}");
        //                emailContents.Add($"📜 Nội dung:");
        //                emailContents.Add(emailBody);
        //                emailContents.Add("\n----------------------------------------\n"); // Ngăn cách email

        //                count++;
        //            }

        //            client.Disconnect(true);

        //            // Tạo thư mục lưu email nếu chưa tồn tại
        //            string directoryPath = "Emails";
        //            Directory.CreateDirectory(directoryPath);

        //            // Lưu nội dung email vào file text
        //            string filePath = Path.Combine(directoryPath, "Recent_Emails.txt");
        //            File.WriteAllLines(filePath, emailContents);

        //            Console.WriteLine($"Đã lưu nội dung của {count} email gần nhất vào {filePath}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi: {ex.Message}");
        //    }
        //}











        private void add_mail_file(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Add List Mail";
            opf.Filter = "Text |*.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                listmailcheck.Clear();
                listmailcheck = new List<string>(File.ReadAllLines(opf.FileName).ToList<string>());
                listmailcheck.RemoveAll(string.IsNullOrWhiteSpace);
                listmailcheck = listmailcheck.Distinct().ToList();
                opf.Dispose();
                for (int i = 0; i < listmailcheck.Count; i++)
                {
                    try
                    {
                        string listmail = listmailcheck[i].ToString().Trim();
                        string mail = "";
                        string passmail = "";
                        if (listmail.Contains("|"))
                        {
                            mail = listmail.Split('|')[0];
                            passmail = listmail.Split('|')[1];
                        }
                        else if (listmail.Contains(":"))
                        {
                            mail = listmail.Split(':')[0];
                            passmail = listmail.Split(':')[1];
                        }
                        //string mail = listmail.Split('|')[0];
                        ////string passmail = listmail.Split('|')[1];
                        int index = dataGridView1.Rows.Add();
                        int rows = dataGridView1.Rows.Count;
                        dataGridView1.Rows[index].Cells["STT"].Value = rows.ToString();
                        dataGridView1.Rows[index].Cells["MAIL"].Value = mail;
                        //dataGridView.Rows[index].Cells["PASSMAIL"].Value = passmail;
                        Tong_so_mail.Text = Convert.ToString(dataGridView1.RowCount);
                    }
                    catch { }
                }
            }
            Tong_so_mail.Text = Convert.ToString(listmailcheck.Count);
            MessageBox.Show($"Đã import thành công {listmailcheck.Count} Mail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void add_mail_clipboard(object sender, EventArgs e)
        {
            listmailcheck.Clear();
            string data = Clipboard.GetText(TextDataFormat.Text);
            listmailcheck = data.Split(new string[]
            {
                    "\r\n",
                    "\r",
                    "\n"
            }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            for (int i = 0; i < listmailcheck.Count; i++)
            {
                try
                {
                    string listmail = listmailcheck[i].ToString().Trim();
                    string mail = "";
                    string passmail = "";
                    if (listmail.Contains("|"))
                    {
                        mail = listmail.Split('|')[0];
                        passmail = listmail.Split('|')[1];
                    }
                    else if (listmail.Contains(":"))
                    {
                        mail = listmail.Split(':')[0];
                        passmail = listmail.Split(':')[1];
                    }
                    int index = dataGridView1.Rows.Add();
                    int rows = dataGridView1.Rows.Count;
                    dataGridView1.Rows[index].Cells["STT"].Value = rows.ToString();
                    dataGridView1.Rows[index].Cells["Mail"].Value = mail;
                    dataGridView1.Rows[index].Cells["Pass"].Value = passmail;
                    Tong_so_mail.Text = Convert.ToString(dataGridView1.RowCount);
                }
                catch { }
            }
            MessageBox.Show($"Nhập thành công {dataGridView1.Rows.Count} Mail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void add_proxy_clipboard(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ Clipboard
                string clipboardText = Clipboard.GetText();

                // Kiểm tra nếu Clipboard có dữ liệu
                if (string.IsNullOrWhiteSpace(clipboardText))
                {
                    MessageBox.Show("Bộ nhớ tạm không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xóa dữ liệu cũ trong danh sách Proxy
                proxyList.Clear();

                // Tách từng dòng proxy và thêm vào danh sách
                string[] lines = clipboardText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    proxyList.Add(line.Trim()); // Thêm proxy vào danh sách
                }
                tongproxy.Text = proxyList.Count.ToString();
                MessageBox.Show($"Thêm thành công {proxyList.Count} proxy từ Clipboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý Clipboard: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void add_proxy_file(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Chọn file chứa danh sách proxy"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Xóa danh sách cũ trước khi thêm mới
                    proxyList.Clear();

                    // Đọc tất cả các dòng trong file và lưu vào danh sách
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        proxyList.Add(line.Trim());
                    }
                    tongproxy.Text = proxyList.Count.ToString();
                    MessageBox.Show($"Đọc thành công {proxyList.Count} proxy từ file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Tong_so_mail_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int x = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    x++;
                }
            }
            dachon.Text = x.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                list.Clear();
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[0].Value))
                    {

                        list.Add(dataGridView1.Rows[j].Cells[0].Value.ToString());
                    }
                }
                dachon.Text = list.Count.ToString();
                Tong_so_mail.Text = dataGridView1.RowCount.ToString();
            }
            catch { }
        }

        private void chọnTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int r = 0; r < dataGridView1.RowCount; r++)
                {
                    dataGridView1.Rows[r].Cells[0].Value = true;
                }
                dachon.Text = dataGridView1.RowCount.ToString();
            }
            catch { }
        }
        private void UpdateSelectedCount()
        {
            int selectedCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    selectedCount++;
                }
            }

            dachon.Text = selectedCount.ToString();
        }

        private void chọnBôiĐenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                row.Cells[0].Value = true;
            }
            UpdateSelectedCount();
        }

        private void bỏChọnTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int r = 0; r < dataGridView1.RowCount; r++)
                {
                    dataGridView1.Rows[r].Cells[0].Value = null;
                }
                dachon.Text = 0.ToString();
            }
            catch { }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                {
                    list.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                }
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[0].Value))
                        {
                            dataGridView1.Rows.RemoveAt(j--);
                        }
                    }
                }
                catch { }
            }
            Tong_so_mail.Text = dataGridView1.RowCount.ToString();
        }

        private void randompasscheck_CheckedChanged(object sender, EventArgs e)
        {
            if (randompasscheck.Checked)
            {
                password.Enabled = false;
            }
            else
            {
                password.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\output");
            }
            catch
            {
                MessageBox.Show("Không thể mở folder save , vui lòng check lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnt_stop_Click(object sender, EventArgs e)
        {
            StopThread = true;
        }
    }
}
