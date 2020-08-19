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
    public class CreateMember_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeMember()
        {
            // Arrange
            var factory = WIMSFactory.Instance;

            // Act
            var memeber = factory.CreateMember("TestMember");

            // Assert
            Assert.IsInstanceOfType(memeber, typeof(IMember));
        }
        [TestMethod]
        public void ThrowArgumentNullException_NullName()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Member(default));
        } 
        [TestMethod]
        public void ThrowArgumentException()
        {

            Assert.ThrowsException<ArgumentException>(
                () => new Member("As"));
        }

    }
}
