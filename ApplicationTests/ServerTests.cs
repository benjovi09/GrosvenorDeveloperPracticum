﻿using Application;
using NUnit.Framework;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Server(new DishManager());
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void ErrorGetsReturnedWithBadInput()
        {
            var order = "one";
            string expected = "error";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteak()
        {
            var order = "evening,1";
            string expected = "steak";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServe2Potatoes()
        {
            var order = "evening,2,2";
            string expected = "potato(x2)";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteakPotatoWineCake()
        {
            var order = "evening,1,2,3,4";
            string expected = "steak,potato,wine,cake";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeSteakPotatox2Cake()
        {
            var order = "evening,1,2,2,4";
            string expected = "steak,potato(x2),cake";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CanServeEgg()
        {
            var order = "morning,1";
            string expected = "egg";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServe2Coffee()
        {
            var order = "morning,3,3";
            string expected = "coffee(x2)";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeEggToastCoffee()
        {
            var order = "morning,1,2,3";
            string expected = "egg,toast,coffee";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanServeEggToastCoffeex2()
        {
            var order = "morning,1,2,3,3";
            string expected = "egg,toast,coffee(x2)";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanParseCaseInsensitiveMenuType()
        {
            var order = "MORNIng,1,2";
            string expected = "egg,toast";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanGenerateErrorWithWrongDish()
        {
            var order = "evening,1,2,3,5";
            string expected = "error";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanGenerateErrorWhenTryingToServerMoreThanOneSteak()
        {
            var order = "evening,1,1,2,3";
            string expected = "error";
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }
    }
}