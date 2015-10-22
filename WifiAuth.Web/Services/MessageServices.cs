using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WifiAuth.Web.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        private static readonly String UCPASS_SMS_VERSION = "2014-06-30";
        private static readonly String UCPASS_SMS_ACCOUNT = "fc4742b8e106a66d1cf069af1600dbe4";
        private static readonly String UCPASS_SMS_TOKEN = "";
        private static readonly String UCPASS_SMS_APPID = "aa166f6bb21d4dfaa36c0fd5270dc3bb";
        private static readonly String UCPASS_SMS_TEMPLATE_URL = "https://api.ucpaas.com/{0}/Accounts/{1}/Messages/templateSMS.json?sig={2}";
        private static readonly String UCPASS_SMS_TEMPLATE_ID = "14756";
        private static readonly String UCPASS_SMS_REQUEST_MESSAGE = "{\"templateSMS\":{\"appId\":null,\"param\":null,\"templateId\":null,\"to\":null}}";

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }

        public async Task<String> SendTemplateSmsAsync(string number, int templateId, params string[] @params)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string sigstr = MD5Encrypt(UCPASS_SMS_ACCOUNT + UCPASS_SMS_TOKEN + date);
            string uriStr = string.Format(UCPASS_SMS_TEMPLATE_URL, UCPASS_SMS_VERSION, UCPASS_SMS_ACCOUNT, sigstr);
            string authStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(UCPASS_SMS_ACCOUNT + ":" + date));
            JObject body = JObject.Parse(UCPASS_SMS_REQUEST_MESSAGE);
            body["templateSMS"]["appId"] = UCPASS_SMS_APPID;
            body["templateSMS"]["templateId"] = templateId;
            body["templateSMS"]["to"] = number;
            body["templateSMS"]["param"] = String.Join(",", @params);
            string data = JsonConvert.SerializeObject(body);
            
            using (HttpClient httpClient = new HttpClient())
            {
                // Limit the max buffer size for the response so we don't get overwhelmed
                httpClient.MaxResponseContentBufferSize = 256000;
                using (HttpRequestMessage requestMessage = new HttpRequestMessage())
                {
                    requestMessage.RequestUri = new Uri(uriStr);
                    requestMessage.Method = HttpMethod.Post;
                    requestMessage.Headers.Add("Authorization", authStr);
                    requestMessage.Headers.Add("Accept", "application/json");
                    requestMessage.Content = new StringContent(data, UTF8Encoding.UTF8, "application/json;charset=utf-8");

                    HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead);
                    string content = await responseMessage.Content.ReadAsStringAsync();

                    return content;
                }
            }
        }

        /// MD5加密
        /// </summary>
        /// <param name="source">原内容</param>
        /// <returns>加密后内容</returns>
        private static string MD5Encrypt(string source)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(source));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
