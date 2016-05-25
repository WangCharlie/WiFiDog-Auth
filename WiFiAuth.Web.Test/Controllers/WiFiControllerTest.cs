using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WiFiAuth.Web.Controllers;
using Xunit;

namespace WiFiAuth.Web.Test.Controllers
{
    /// <summary>
    /// WiFiControllerTest 的摘要说明
    /// </summary>
    public class WiFiControllerTest
    {
        public WiFiControllerTest()
        {

        }

        [Fact]
        public void Test_Ping()
        {
            var result = new WiFiController().Ping(null, 0, 0, 0, 0);

            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.NotNull(contentResult.Content);
            Assert.Equal("pong", contentResult.Content);
        }

        [Fact]
        public void Test_Get_Login()
        {
            var result = new WiFiController().Login(null,0,null,null,null);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
            Assert.Null(viewResult.Model);
            Assert.NotNull(viewResult.ViewData);
        }

        [Fact]
        public void Test_Post_Login()
        {
            var result = new WiFiController().Login(null, 0, null, null, null, null, null, null);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.False(redirectResult.Permanent);
            Assert.NotNull(redirectResult.Url);
        }

        [Fact]
        public void Test_Auth()
        {
            var result = new WiFiController().Auth(null, null, null, null, 0, 0);

            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.NotNull(contentResult.Content);
            Assert.Equal("auth: 1", contentResult.Content);
        }

        [Fact]
        public void Test_Portal()
        {
            var result = new WiFiController().Portal(null);

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.False(redirectResult.Permanent);
            Assert.NotNull(redirectResult.Url);
            Assert.Equal("/portal", redirectResult.Url);
        }

        [Fact]
        public void Test_Message()
        {
            var result = new WiFiController().Message(null);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Message", viewResult.ViewName);
            Assert.Null(viewResult.Model);
            Assert.NotNull(viewResult.ViewData);
        }
        
    }
}
