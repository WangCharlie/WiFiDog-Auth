using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Sqlite;

namespace WifiAuth.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (SqliteConnection conn = new SqliteConnection(@"Data Source=E:/Database/SQLite/default.db;Cache=Shared"))
            {
                conn.Open();
                var d = conn.Query("SELECT * FROM FOO;");
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
