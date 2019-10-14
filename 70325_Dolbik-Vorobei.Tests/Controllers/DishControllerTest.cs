using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _70325_Dolbik_Vorobei.Controllers;
using _70325_Dolbik_Vorobei.Models;
using _70325_Dolbik_Vorobei.DAL;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace _70325_Dolbik_Vorobei.Tests.Controllers
{
    [TestClass]
    public class DishControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Dish>>();
            mock.Setup(r => r.GetAll())
            .Returns(new List<Dish>
            {
                new Dish { DishId=1 },
                new Dish { DishId=2 },
                new Dish { DishId=3 },
                new Dish { DishId=4 },
                new Dish { DishId=5 },
            });
            // Создание объекта контроллера
            var controller = new DishController(mock.Object);
            // Act
            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;
            NameValueCollection valueCollection =
                new NameValueCollection();
            valueCollection.Add("X-Requested-With", "XMLHttpRequest");
            valueCollection.Add("Accept", "application/json");
            // другой вариант: valueCollection.Add("Accept", "HTML");
            request.Setup(r => r.Headers).Returns(valueCollection);
            // Вызов метода List
            var view = controller.List(null, 2) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Dish> model = view.Model as PageListViewModel<Dish>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].DishId);
            Assert.AreEqual(5, model[1].DishId);
            
        }

        public void CategoryTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Dish>>();
            mock.Setup(r => r.GetAll())
            .Returns(new List<Dish>
            {
                new Dish { DishId=1, GroupName="1" },
                new Dish { DishId=2, GroupName="2" },
                new Dish { DishId=3, GroupName="1" },
                new Dish { DishId=4, GroupName="2" },
                new Dish { DishId=5, GroupName="2" },
            });
            // Создание объекта контроллера
            var controller = new DishController(mock.Object);
            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;
            // Act
            // Вызов метода List
            var view = controller.List("1", 1) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Dish> model = view.Model as PageListViewModel<Dish>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].DishId);
            Assert.AreEqual(3, model[1].DishId);
        }
    }
}
