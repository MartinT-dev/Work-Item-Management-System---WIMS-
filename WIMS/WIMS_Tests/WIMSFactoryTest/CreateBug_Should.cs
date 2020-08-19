using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS_Tests.WIMSFactoryTest
{
    [TestClass]
    public class CreateBug_Should
    {   
        [TestMethod]
        public void ReturnInstanceOfTypeBug()
        {
            // Arrange
            var factory = WIMSFactory.Instance;

            // Act
            var member = new Member() { Name = "TestName" };
            var steps = new List<string>() { "step", "one" };
            var bug = factory.CreateBug("TestBugOne","TestDescOne",steps,default,default,default,member);

            // Assert
            Assert.IsInstanceOfType(bug, typeof(IBug));
        }
        [TestMethod]
        public void ThrowArgumentNullException_NullName_NullDescprition()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Bug(default, default,default,default,default,default,default));
        } 
        [TestMethod]
        public void ThrowArgumentException_NameLength_Desc_Length()
        {
            Assert.ThrowsException<ArgumentException>(
                () => new Bug("As", "As", default,default,default,default,default));
        } 

      
    }
}
