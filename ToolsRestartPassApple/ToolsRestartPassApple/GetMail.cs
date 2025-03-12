using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Security;
using MailKit;
using System.Xml.Linq;
using OpenQA.Selenium;
using System.Threading;

namespace ToolsRestartPassApple
{
    internal class GetMail
    {
        public static string doc_mail_freenet(string mail, string password)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    try
                    {
                        // Thử kết nối IMAP trước
                        client.Connect("mx.freenet.de", 993, SecureSocketOptions.SslOnConnect);
                        client.Authenticate(mail, password);

                        // Mở hộp thư Inbox
                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadOnly);

                        // Duyệt từ email mới nhất về trước, tìm email đầu tiên từ Apple
                        for (int i = inbox.Count - 1; i >= 0; i--)
                        {
                            var message = inbox.GetMessage(i);
                            if (message.From.ToString().Contains("Apple") && message.To.ToString().ToLower().Contains(mail.ToLower()))
                            {
                                string emailBody = message.TextBody;

                                // Regex tìm URL đầu tiên
                                string urlPattern = @"(https://iforgot\.apple\.com/verify/email\?key=[^\s]+)";
                                Match match = Regex.Match(emailBody, urlPattern);

                                if (match.Success)
                                {
                                    client.Disconnect(true);
                                    return match.Value;
                                }

                                break;
                            }
                        }

                        client.Disconnect(true);
                    }
                    catch (Exception imapEx)
                    {
                        Console.WriteLine($"IMAP thất bại, thử chuyển sang POP3... Lỗi: {imapEx.Message}");
                        return doc_mail_freenet_pop3(mail, password); // Chuyển sang POP3 nếu IMAP thất bại
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            return null;
        }

        // Hàm đọc mail qua POP3 nếu IMAP không hoạt động
        public static string doc_mail_freenet_pop3(string mail, string password)
        {
            try
            {
                using (var client = new Pop3Client())
                {
                    // Kết nối đến POP3 Server của Freenet
                    client.Connect("pop3.freenet.de", 995, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(mail, password);

                    // Kiểm tra số lượng email
                    int messageCount = client.Count;
                    for (int i = messageCount; i >= 1; i--)
                    {
                        var message = client.GetMessage(i);
                        if (message.From.ToString().Contains("Apple") && message.To.ToString().ToLower().Contains(mail.ToLower()))
                        {
                            string emailBody = message.TextBody;

                            // Regex tìm URL đầu tiên
                            string urlPattern = @"(https://iforgot\.apple\.com/verify/email\?key=[^\s]+)";
                            Match match = Regex.Match(emailBody, urlPattern);

                            if (match.Success)
                            {
                                client.Disconnect(true);
                                return match.Value;
                            }

                            break;
                        }
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"POP3 cũng thất bại. Lỗi: {ex.Message}");
            }

            return null;
        }
        public static string doc_mail_mailbg(string mail, string password)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    try
                    {
                        // Thử kết nối IMAP trước
                        client.Connect("imap.mail.bg", 993, SecureSocketOptions.SslOnConnect);
                        client.Authenticate(mail, password);

                        // Mở hộp thư Inbox
                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadOnly);

                        // Duyệt từ email mới nhất về trước, tìm email đầu tiên từ Apple
                        for (int i = inbox.Count - 1; i >= 0; i--)
                        {
                            var message = inbox.GetMessage(i);
                            if (message.From.ToString().Contains("Apple") && message.To.ToString().ToLower().Contains(mail.ToLower()))
                            {
                                string emailBody = message.TextBody;

                                // Regex tìm URL đầu tiên
                                string urlPattern = @"(https://iforgot\.apple\.com/verify/email\?key=[^\s]+)";
                                Match match = Regex.Match(emailBody, urlPattern);

                                if (match.Success)
                                {
                                    client.Disconnect(true);
                                    return match.Value;
                                }

                                break;
                            }
                        }

                        client.Disconnect(true);
                    }
                    catch (Exception imapEx)
                    {
                        Console.WriteLine($"IMAP thất bại, thử chuyển sang POP3... Lỗi: {imapEx.Message}");
                        return doc_mail_mailbg_pop3(mail, password); // Chuyển sang POP3 nếu IMAP thất bại
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            return null;
        }

        // Hàm đọc mail qua POP3 nếu IMAP không hoạt động
        public static string doc_mail_mailbg_pop3(string mail, string password)
        {
            try
            {
                using (var client = new Pop3Client())
                {
                    // Kết nối đến POP3 Server của Mail.bg
                    client.Connect("pop3.mail.bg", 995, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(mail, password);

                    // Kiểm tra số lượng email
                    int messageCount = client.Count;
                    for (int i = messageCount; i >= 1; i--)
                    {
                        var message = client.GetMessage(i);
                        if (message.From.ToString().Contains("Apple") && message.To.ToString().ToLower().Contains(mail.ToLower()))
                        {
                            string emailBody = message.TextBody;

                            // Regex tìm URL đầu tiên
                            string urlPattern = @"(https://iforgot\.apple\.com/verify/email\?key=[^\s]+)";
                            Match match = Regex.Match(emailBody, urlPattern);

                            if (match.Success)
                            {
                                client.Disconnect(true);
                                return match.Value;
                            }

                            break;
                        }
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"POP3 cũng thất bại. Lỗi: {ex.Message}");
            }

            return null;
        }




        public static string doc_mail_cham_com(IWebDriver driver, string mail, string password)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.mail.com/premiumlogin/#.7518-header-premiumlogin1-1");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@id='login-email']")).SendKeys("gsj13@email.com");
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("//input[@id='login-password']")).SendKeys("oY547V58Pf");
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("//button[@type='submit' and contains(@class, 'login-submit')]")).Click();

                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//a[@data-item-name='mail']")).Click();


                IWebElement iframeElement1 = driver.FindElement(By.XPath("//iframe[@name='mail']"));
                driver.SwitchTo().Frame(iframeElement1);


                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//tbody/tr[1]/td[2]")).Click();

                Thread.Sleep(2000);
                IWebElement iframeElement2 = driver.FindElement(By.XPath("//iframe[@name='mail-display-content']"));
                driver.SwitchTo().Frame(iframeElement2);
                Thread.Sleep(2000);
                //driver.FindElement(By.XPath("//div[contains(@class, 'email-body')]/p[4]/a[1]")).Click();
                IWebElement linkElement = driver.FindElement(By.XPath("//div[contains(@class, 'email-body')]/p[4]/a[1]"));
                string link_re_pass = linkElement.GetAttribute("href");

                return link_re_pass;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"POP3 cũng thất bại. Lỗi: {ex.Message}");
            }

            return null;
        }



        public static string doc_gmx_cham_com(IWebDriver driver, string mail, string password)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.gmx.com/#.1559516-header-navlogin1-2");

                Thread.Sleep(5000);

                if (IsElementExists(driver, "//iframe[@sandbox='allow-forms allow-popups allow-popups-to-escape-sandbox allow-same-origin allow-scripts']"))
                {
                    Thread.Sleep(3000);
                    IWebElement iframeElement3 = driver.FindElement(By.ClassName("permission-core-iframe"));
                    driver.SwitchTo().Frame(iframeElement3);

                    IWebElement iframeElement4 = driver.FindElement(By.XPath("//iframe[contains(@src, 'plus.gmx.com/lt')]"));
                    driver.SwitchTo().Frame(iframeElement4);

                    if (IsElementExists(driver, "//*[@id=\"onetrust-accept-btn-handler\"]"))
                    {
                        driver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")).Click();
                    }
                    //Thread.Sleep(5000);
                    driver.SwitchTo().DefaultContent();
                }
                else if (IsElementExists(driver, "//button[@aria-label=\"Close layer\"]"))
                {
                    driver.FindElement(By.XPath("//button[@aria-label=\"Close layer\"]")).Click();
                }


                Thread.Sleep(1000);
                int attempts = 0;
                while (attempts < 5)
                {
                    try
                    {
                        var emailInput = driver.FindElement(By.XPath("//input[@id='login-email']"));
                        emailInput.SendKeys("marco90@caramail.com");
                        Thread.Sleep(1000);
                        break;
                    }
                    catch (NoSuchElementException)
                    {
                        attempts++;
                        if (attempts < 5)
                        {
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy phần tử sau 5 lần thử.");
                        }
                    }
                }
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@id='login-password']")).SendKeys("Jotusutylana");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@type='submit' and contains(@class, 'login-submit')]")).Click();

                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//a[@data-item-name='mail']")).Click();


                IWebElement iframeElement1 = driver.FindElement(By.XPath("//iframe[@name='mail']"));
                driver.SwitchTo().Frame(iframeElement1);


                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//tbody/tr[1]/td[2]")).Click();

                Thread.Sleep(2000);
                IWebElement iframeElement2 = driver.FindElement(By.XPath("//iframe[@name='mail-display-content']"));
                driver.SwitchTo().Frame(iframeElement2);
                Thread.Sleep(2000);
                //driver.FindElement(By.XPath("//div[contains(@class, 'email-body')]/p[4]/a[1]")).Click();
                IWebElement linkElement = driver.FindElement(By.XPath("//div[contains(@class, 'email-body')]/p[4]/a[1]"));
                string link_re_pass = linkElement.GetAttribute("href");

                return link_re_pass;
            }
            catch (Exception ex)
            {
                // dataGridView1.Rows[i].Cells["Status"].Value = ex.Message;
            }

            return null;
        }

        public static bool IsElementExists(IWebDriver driver, string xpath)
        {
            try
            {
                List<IWebElement> Element = new List<IWebElement>();
                Element.AddRange(driver.FindElements(By.XPath(xpath)));
                if (Element.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
