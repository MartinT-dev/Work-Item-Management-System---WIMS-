using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.WorkItems;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS_Tests.WIMSFactoryTest
{
    [TestClass]
    public class CreateStory_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeStory()
        {
            // Arrange
            var factory = WIMSFactory.Instance;

            // Act
            var member = new Member() { Name = "TestName" };
            var story = factory.CreateStory("TestBugOne", "TestDescOne",default, default, default, member);

            // Assert
            Assert.IsInstanceOfType(story, typeof(IStory));
        }
        [TestMethod]
        public void ThrowArgumentNullException_NullName_NullDescprition()
        {
            Assert.ThrowsException<ArgumentNullException>(
                 () => new Story(default, default, default, default, default, default));
        }
        [TestMethod]
        public void ThrowArgumentException_NameLength_Desc_Length()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Story("As", "As", default, default, default, default));
        }
    }
}
