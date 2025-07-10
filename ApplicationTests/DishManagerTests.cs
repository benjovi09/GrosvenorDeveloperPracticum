using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Enums;
using NUnit.Framework;


namespace ApplicationTests
{
    [TestFixture]
    public class DishManagerTests
    {
        private DishManager _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishManager();
        }

        [Test]
        public void EmptyListReturnsEmptyList()
        {
            var order = new Order();
            var actual = _sut.GetDishes(order);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void EveningListWith1ReturnsOneSteak()
        {
            var order = new Order
            {
                MenuType = MenuType.Evening,
                Dishes = new List<int>
                {
                    1
                }
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("steak", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }
        [Test]
        public void MorningListWith1ReturnsOneEgg()
        {
            var order = new Order
            {
                MenuType = MenuType.Morning,
                Dishes = new List<int>
                {
                    1
                }
            };

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("egg", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }
    }
}
