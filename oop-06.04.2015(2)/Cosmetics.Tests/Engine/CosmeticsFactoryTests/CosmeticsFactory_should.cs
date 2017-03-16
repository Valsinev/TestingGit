using Cosmetics.Common;
using Cosmetics.Engine;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    [TestFixture]
    public class CosmeticsFactory_Should
    {
        [Test]
        public void CreateCategory_WhenCreateCategoryIsCalled()
        {
            var factory = new CosmeticsFactory();

            var category = factory.CreateCategory("Pesho");

            Assert.IsInstanceOf(typeof(Category), category);
        }

        [Test]
        public void CreateShampoo_WhenCreateShampooIsCalled()
        {
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.IsInstanceOf(typeof(Shampoo), shampoo);
        }

        [Test]
        public void CreateToothpaste_WhenCreateToothpasteIsCalled()
        {
            var factory = new CosmeticsFactory();

            var toothpaste = factory.CreateToothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic" });

            Assert.IsInstanceOf(typeof(Toothpaste), toothpaste);
        }

        [Test]
        public void CreateShoppingCart_WhenShoppingCartIsCalled()
        {
            var factory = new CosmeticsFactory();

            var shoppingcart = factory.ShoppingCart();

            Assert.IsInstanceOf(typeof(ShoppingCart), shoppingcart);
        }
    }
}
