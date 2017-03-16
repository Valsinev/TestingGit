using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;
using System;

namespace Cosmetics.Tests.Products.CategoryTests
{
    [TestFixture]
    public class Category_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenConstructedWithNullString()
        {
            Assert.Throws<NullReferenceException>(() => new Category(null));
        }

        [TestCase("a")]
        [TestCase("Longer than fifteen symbols text")]
        public void ThrowNullReferenceException_WhenConstructedWithNullString(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Category(name));
        }

        [Test]
        public void ReturnExpectedName_WhenConstructedWithValidString()
        {
            var category = new Category("Pesho");

            Assert.AreEqual("Pesho", category.Name);
        }

        [Test]
        public void ThrowNullReferenceException_WhenAddingNullCosmetics()
        {
            var category = new Category("Pesho");

            Assert.Throws<NullReferenceException>(() => category.AddCosmetics(null));
        }

        [Test]
        public void AddCosmetics_WhenAddCosmeticsIsCalled()
        {
            var category = new Category("Pesho");

            var cosmetic = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            category.AddCosmetics(cosmetic);

            Assert.AreEqual(1, category.Products.Count);
        }

        [Test]
        public void ThrowNullReferenceException_WhenRemovingNullCosmetics()
        {
            var category = new Category("Pesho");

            Assert.Throws<NullReferenceException>(() => category.RemoveCosmetics(null));
        }

        [Test]
        public void ThrowInvalidOperationException_WhenRemovingUncontainedCosmetic()
        {
            var category = new Category("Pesho");

            var cosmetic = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            Assert.Throws<InvalidOperationException>(() => category.RemoveCosmetics(cosmetic));
        }

        [Test]
        public void RemoveCosmeticCorrectly_WhenRemoveCosmeticIsCalled()
        {
            var category = new Category("Pesho");

            var cosmetic = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            category.AddCosmetics(cosmetic);
            category.RemoveCosmetics(cosmetic);

            Assert.AreEqual(0, category.Products.Count);
        }

        [Test]
        public void ReturnCorrectStringFormat_WhenPrintIsCalled()
        {
            var category = new Category("Pesho");

            var cosmetic = new Shampoo("Pesho", "Nivea", 2.50m, GenderType.Men, 500, UsageType.EveryDay);

            string newLine = Environment.NewLine;

            string expectedString =
                "Pesho category - 1 product in total" + newLine +
                "- Nivea - Pesho:" + newLine +
                "  * Price: $1250,00" + newLine +
                "  * For gender: Men" + newLine +
                "  * Quantity: 500 ml" + newLine +
                "  * Usage: EveryDay";

            category.AddCosmetics(cosmetic);

            Assert.AreEqual(expectedString, category.Print());
        }
    }
}
