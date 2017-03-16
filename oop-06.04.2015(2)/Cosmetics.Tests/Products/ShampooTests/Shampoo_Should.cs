using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;
using System;

namespace Cosmetics.Tests.Products.ShampooTests
{
    [TestFixture]
    public class Shampoo_Should
    {
        [Test]
        public void ReturnExpectedName_WhenIsConstructedWithValidData()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.AreEqual("Pesho", shampoo.Name);
        }

        [Test]
        public void ReturnExpectedBrand_WhenIsConstructedWithValidData()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.AreEqual("Nivea", shampoo.Brand);
        }

        [Test]
        public void ReturnExpectedPrice_WhenIsConstructedWithValidData()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.AreEqual(1250m, shampoo.Price);
        }

        [Test]
        public void ReturnExpectedGenderType_WhenIsConstructedWithValidData()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.AreEqual(GenderType.Men, shampoo.Gender);
        }

        [Test]
        public void ReturnExpectedQuantity_WhenIsConstructedWithValidData()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.AreEqual(500, shampoo.Milliliters);
        }

        [Test]
        public void ReturnExpectedUsageType_WhenIsConstructedWithValidData()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.AreEqual(UsageType.EveryDay, shampoo.Usage);
        }

        [Test]
        public void ReturnExpectedPrint_WhenPrintIsCalled()
        {
            var shampoo = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            string newLine = Environment.NewLine;
            string expectedPrint =
                "- Nivea - Pesho:" + newLine +
                "  * Price: $1250,00" + newLine +
                "  * For gender: Men" + newLine +
                "  * Quantity: 500 ml" + newLine +
                "  * Usage: EveryDay";

            Assert.AreEqual(expectedPrint, shampoo.Print());
        }

        [Test]
        public void ThrowNullReferenceException_WhenIsConstructedWithNullName()
        {
            Assert.Throws<NullReferenceException>(() => new Shampoo(null, "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("ne")]
        [TestCase("Invalid name Lenght")]
        public void ThrowIndexOutOfRangeException_WhenIsConstructedWithInvalidNameLenght(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Shampoo(name, "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay));
        }

        [Test]
        public void ThrowNullReferenceException_WhenIsConstructedWithNullBrand()
        {
            Assert.Throws<NullReferenceException>(() => new Shampoo("Pesho", null, 2.50m, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("n")]
        [TestCase("Invalid name Lenght")]
        public void ThrowIndexOutOfRangeException_WhenIsConstructedWithInvalidBrandLenght(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Shampoo("Pesho", name, 2.50m, GenderType.Men, 500, UsageType.EveryDay));
        }
    }
}
