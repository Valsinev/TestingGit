using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;
using System;

namespace Cosmetics.Tests.Products.ShoppingCartTests
{
    [TestFixture]
    public class ShoppingCart_Should
    {
        [Test]
        public void AddProduct_WhenAddProductIsCalled()
        {
            var cart = new ShoppingCart();

            var product = new Shampoo("Pesho", "Nivea", 2.5m, GenderType.Men, 500, UsageType.EveryDay);

            cart.AddProduct(product);

            Assert.AreEqual(true, cart.ContainsProduct(product));
        }

        [Test]
        public void RemoveProduct_WhenRemoveProductIsCalled()
        {
            var cart = new ShoppingCart();

            var product = new Shampoo("Pesho", "Nivea", 2.5m, GenderType.Men, 500, UsageType.EveryDay);

            cart.AddProduct(product);
            cart.RemoveProduct(product);

            Assert.AreEqual(false, cart.ContainsProduct(product));
        }

        [Test]
        public void ThrowNullReferenceException_WhenAddingNullProduct()
        {
            var cart = new ShoppingCart();

            Assert.Throws<NullReferenceException>(() => cart.AddProduct(null));
        }

        [Test]
        public void ThrowNullReferenceException_WhenRemovingNullProduct()
        {
            var cart = new ShoppingCart();

            Assert.Throws<NullReferenceException>(() => cart.RemoveProduct(null));
        }

        [Test]
        public void ReturnCorrectTotalAmount_WhenTotalPriceIsCalled()
        {
            var cart = new ShoppingCart();

            var product = new Shampoo("Pesho", "Nivea", 2.5m, GenderType.Men, 500, UsageType.EveryDay);

            cart.AddProduct(product);
            cart.AddProduct(product);

            Assert.AreEqual(2500m, cart.TotalPrice());
        }
    }
}
