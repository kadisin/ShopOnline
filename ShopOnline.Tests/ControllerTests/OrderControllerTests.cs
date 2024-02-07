using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ShopOnline.Controllers;
using ShopOnline.Models;
using ShopOnline.Repository.Generics;
using Assert = NUnit.Framework.Assert;

namespace ShopOnline.Tests.ControllerTests
{
    [TestClass]
    public class OrderControllerTests
    {
        private Mock<IRepository<Order>> _orderRepositoryMock;
        private Mock<IRepository<Product>> _productRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _orderRepositoryMock = new Mock<IRepository<Order>>();
            _productRepositoryMock = new Mock<IRepository<Product>>();

            //_productRepositoryMock.Setup(x => x.GetAll()).Returns(Task.FromResult<IEnumerable<Product>>(
            //    new List<Product>() 
            //    { 
            //        new Product { Name = "test", Price = 10.99M } 
            //    }
            //));
        }

        [TestMethod]
        public void OrderControllerCreateCorrectly()
        {
            //ARRANGE
            //ACT
            var orderController = new OrderController(_orderRepositoryMock.Object, _productRepositoryMock.Object);

            //ASSERT
            Assert.That(orderController, Is.Not.Null);
        }

        [TestMethod]
        public void CreateMethod_ParametersCorrect_ReturnCorrectProducts()
        {
            //ARRANGE
            var orderController = new OrderController(_orderRepositoryMock.Object, _productRepositoryMock.Object);
            var expectedResult = new List<Product>() { new Product { Name = "Test", Price = 10.99M } };

            //ACT
            var result = orderController.Create();

            //ASSERT
            Assert.That(result.Result, Is.EqualTo(expectedResult));
        }
    }
}
