using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace ToolsRestartPassApple
{
    class SolveCaptcha
    {
        public static string Create2captchTask(string api_key, string base64)
        {
           
            try
            {
                HttpRequest request = new HttpRequest();
                request.UserAgent = Http.ChromeUserAgent();
                string body = $@"{{
                    ""clientKey"": ""{api_key}"",
                    ""task"": {{
                        ""type"": ""ImageToTextTask"",
                        ""body"": ""{base64}"",
                        ""phrase"": false,
                        ""case"": true,
                        ""numeric"": 0,
                        ""math"": false,
                        ""minLength"": 1,
                        ""maxLength"": 6,
                        ""comment"": ""enter the text you see on the image""
                    }},
                    ""languagePool"": ""en""
                }}";
                string reponse = request.Post("https://api.2captcha.com/createTask", body, "application/json").ToString();
                if (reponse.Contains("taskId"))
                {
                    var jb = JObject.Parse(reponse);
                    string taskid = jb["taskId"].ToString();
                    return taskid;
                }
            }
            catch { }
            return null;
        }


        public static string Result2captchTask(string api_key, string taskid )
        {

            try
            {
                HttpRequest request = new HttpRequest();
                request.UserAgent = Http.ChromeUserAgent();

                string body = $@"{{
                ""clientKey"": ""{api_key}"",
                ""taskId"": ""{taskid}""
            }}";

                for (int i = 0; i < 5; i++)
                {
                    string response = request.Post("https://api.2captcha.com/getTaskResult", body, "application/json").ToString();
                    var jb = JObject.Parse(response);


                    // Nếu có lỗi (errorId khác 0), trả về lỗi ngay lập tức
                    if (jb["errorId"]?.ToObject<int>() != 0)
                    {
                        return "Error:";
                    }

                    string status = jb["status"]?.ToString();

                    // Nếu có kết quả (status == "ready"), lấy kết quả và trả về
                    if (status == "ready")
                    {
                        string text_captcha = jb["solution"]?["text"]?.ToString();
                        return text_captcha ?? "Error.";
                    }

              
                    if (status == "processing")
                    {
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }

            return "Error: Max retries reached, no result available.";
        }


    }
}
