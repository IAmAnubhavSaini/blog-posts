using System;
using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.App
{
    [TestClass]
    public class GuideToGalaxyTests
    {
        [TestMethod]
        public void ShouldSanitizeLanguageFactInformation()
        {
            const string input = "., ABC     is    I....,,,  ,,";
            Assert.AreEqual("ABC is I", GuideToGalaxy.SanitizeInput(input));
        }
    }
}
