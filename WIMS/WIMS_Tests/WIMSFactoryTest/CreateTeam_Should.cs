using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Contracts;

namespace WIMS_Tests.WIMSFactoryTest
{
    [TestClass]
    public class CreateTeam_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeTeam()
        {
            // Arrange
            var factory = WIMSFactory.Instance;

            // Act
            var team = factory.CreateTeam("TestTeam");

            // Assert
            Assert.IsInstanceOfType(team, typeof(ITeam));
        }
        [TestMethod]
        public void ThrowArgumentNullException_NullName()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Team(default));
        }
        [TestMethod]
        public void ThrowArgumentException()
        {

            Assert.ThrowsException<ArgumentException>(
                () => new Team("As"));
        }
    }
}
