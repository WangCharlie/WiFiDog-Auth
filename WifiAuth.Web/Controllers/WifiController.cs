using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WifiAuth.Web.Controllers
{
    /// <summary>
    /// Wifi Controller
    /// <para>ping: ping/?gw_id=%s&sys_uptime=%lu&sys_memfree=%u&sys_load=%.2f&wifidog_uptime=%lu</para>
    /// <para>login: login/?gw_address=%s&gw_port=%d&gw_id=%s&url=%s</para>
    /// <para>auth: auth/?stage=%s&ip=$s&mac=%s&token=%s&incoming=%d&outgoing=%d</para>
    /// <para>portal: portal/?gw_id=%s</para>
    /// <para>message: message/?message=%s</para>
    /// </summary>
    public class WifiController : Controller
    {
        /// <summary>
        /// wifi心跳
        /// </summary>
        /// <param name="gw_id">来自wifidog 配置文件中，用来区分不同的路由设备</param>
        /// <param name="sys_uptime">路由器的系统启动时间</param>
        /// <param name="sys_memfree">系统内存使用百分比</param>
        /// <param name="sys_load">系统载入</param>
        /// <param name="wifidog_uptime">持续运行时间（这个数据经常会有问题）</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Ping(string gw_id,
                                  long sys_uptime,
                                  long sys_memfree,
                                  float sys_load,
                                  long wifidog_uptime)
        {
            //to do something

            return Content("pong");
        }

        /// <summary>
        /// wifi登录验证页面
        /// </summary>
        /// <param name="gw_address">网关地址</param>
        /// <param name="gw_port">网关端口</param>
        /// <param name="gw_id">网关标识</param>
        /// <param name="mac">登录设备Mac地址</param>
        /// <param name="url">跳转的地址</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string gw_address,
                                   int gw_port,
                                   string gw_id,
                                   string mac,
                                   string url)
        {
            return View();
        }

        /// <summary>
        /// 设备提交登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="validCode"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string gw_address,
                                   int gw_port,
                                   string gw_id,
                                   string mac,
                                   string url,
                                   string userName, 
                                   string password,
                                   string validCode)
        {
            return Redirect(string.Format("http://{0}:{1}/wifidog/auth?token={2}",gw_address,gw_port,DateTime.Now.Ticks));
        }

        /// <summary>
        /// 网关验证设备Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Auth(string stage,
                                  string ip,
                                  string mac,
                                  string token,
                                  long incoming,
                                  long outgoing)
        {
            return Content("auth: 1");
        }

        [HttpGet]
        public IActionResult Portal(string gw_id)
        {
            return Redirect(Url.Action("~/"));
        }

        [HttpGet]
        public IActionResult Message(string message)
        {
            return View("Message");
        }
    }
}