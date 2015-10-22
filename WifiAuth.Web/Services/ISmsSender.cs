using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WifiAuth.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);

        Task<String> SendTemplateSmsAsync(string number, int templateId, params string[] @params);
    }
}
