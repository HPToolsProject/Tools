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
                            if (message.From.ToString().Contains("Apple"))
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
                        if (message.From.ToString().Contains("Apple"))
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
                            if (message.From.ToString().Contains("Apple"))
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
                        if (message.From.ToString().Contains("Apple"))
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

    }
}
