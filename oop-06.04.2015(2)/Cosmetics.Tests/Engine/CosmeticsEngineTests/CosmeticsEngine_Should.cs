using Cosmetics.Engine;
using Moq;
using NUnit.Framework;
using System;

namespace Cosmetics.Tests.Engine.CosmeticsEngineTests
{
    [TestFixture]
    public class CosmeticsEngine_Should
    {
        [Test]
        public void CreateInstanceOfCosmeticsEngine_WhenInstanceIsCalled()
        {
            var engine = CosmeticsEngine.Instance;

            Assert.IsInstanceOf(typeof(CosmeticsEngine), engine);
        }
    }
}
