using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cosmetics.Tests.Products.ToothpasteTests
{
    [TestFixture]
    public class Toothpaste_Should
    {
        [Test]
        public void ReturnExpectedName_WhenIsConstructedWithValidData()
        {
            var paste = new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic" });

            Assert.AreEqual("Pesho", paste.Name);
        }

        [Test]
        public void ReturnExpectedBrand_WhenIsConstructedWithValidData()
        {
            var paste = new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic" });

            Assert.AreEqual("Nivea", paste.Brand);
        }

        [Test]
        public void ReturnExpectedPrice_WhenIsConstructedWithValidData()
        {
            var paste = new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic" });

            Assert.AreEqual(2.50m, paste.Price);
        }

        [Test]
        public void ReturnExpectedGenderType_WhenIsConstructedWithValidData()
        {
            var paste = new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic" });

            Assert.AreEqual(GenderType.Men, paste.Gender);
        }

        [Test]
        public void ReturnExpectedIngredients_WhenIsConstructedWithValidData()
        {
            var paste = new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic", "potato" });

            Assert.AreEqual("garlic, potato", paste.Ingredients);
        }

        [Test]
        public void ReturnExpectedPrint_WhenPrintIsCalled()
        {
            var paste = new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic", "potato" });

            string newLine = Environment.NewLine;
            string expectedPrint =
                "- Nivea - Pesho:" + newLine +
                "  * Price: $2,50" + newLine +
                "  * For gender: Men" + newLine +
                "  * Ingredients: garlic, potato";

            Assert.AreEqual(expectedPrint, paste.Print());
        }

        [Test]
        public void ThrowNullReferenceException_WhenIsConstructedWithNullName()
        {
            Assert.Throws<NullReferenceException>(() => new Toothpaste(null, "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic", "potato" }));
        }

        [TestCase("ne")]
        [TestCase("Invalid name Lenght")]
        public void ThrowIndexOutOfRangeException_WhenIsConstructedWithInvalidNameLenght(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Toothpaste(name, "Nivea", 2.50m, GenderType.Men, new List<string> { "garlic", "potato" }));
        }

        [Test]
        public void ThrowNullReferenceException_WhenIsConstructedWithNullBrand()
        {
            Assert.Throws<NullReferenceException>(() => new Toothpaste("Pesho", null, 2.50m, GenderType.Men, new List<string> { "garlic", "potato" }));
        }

        [TestCase("n")]
        [TestCase("Invalid name Lenght")]
        public void ThrowIndexOutOfRangeException_WhenIsConstructedWithInvalidBrandLenght(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Toothpaste("Pesho", name, 2.50m, GenderType.Men, new List<string> { "garlic", "potato" }));
        }

        [TestCase("noi")]
        [TestCase("Invalid Ingredient Lenght")]
        public void ThrowIndexOutOfRangeException_WhenIsConstructedWithInvalidIngredientLenght(string ingredient)
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Toothpaste("Pesho", "Nivea", 2.50m, GenderType.Men, new List<string> { ingredient, "potato" }));
        }
    }
}
