using System.Collections.Generic;
using DrinkIt.Controllers;
using DrinkIt.db;
using DrinkIt.Models;
using NUnit.Framework;
using DrinkIt.ViewModels;
using DrinkItTests;

namespace BeverageControllerTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GetBeveragesTest()
        {
            Beverage beverage1 = new Beverage {Id = 1, Image = "image1", Name = "beverage1"};
            Beverage beverage2 = new Beverage {Id = 2, Image = "image2", Name = "beverage2"};
            Beverage beverage3 = new Beverage {Id = 3, Image = "image3", Name = "beverage3"};

            FakeRepository repository = new FakeRepository();

            repository.Beverages.Add(beverage2);
            repository.Beverages.Add(beverage3);
            repository.Beverages.Add(beverage1);

            List<Beverage> beverages = new List<Beverage> {beverage1, beverage2, beverage3};
            AddDrinkViewModel expected = new AddDrinkViewModel {Beverages = beverages};

            BeverageController beverageController = new BeverageController(repository);

            AddDrinkViewModel actual = beverageController.GetBeverages();

            CollectionAssert.AreEqual(actual.Beverages, expected.Beverages);
        }
    }
}