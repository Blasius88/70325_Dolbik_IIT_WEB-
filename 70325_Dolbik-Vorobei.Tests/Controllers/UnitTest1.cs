using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace _70325_Dolbik_Vorobei.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultRouteTest()
        { // Arrange // Макет Http - контекста 
            var mockContext=new Mock<HttpContextBase>();
            mockContext .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath) .Returns("~/");
            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            //Act //Получение данных маршрута 
            var result = routes.GetRouteData(mockContext.Object);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]); }
        }
    }
