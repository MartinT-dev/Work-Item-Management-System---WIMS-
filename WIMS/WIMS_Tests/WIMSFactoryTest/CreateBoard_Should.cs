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
    public class CreateBoard_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeBoard()
        {
            // Arrange
            var factory = WIMSFactory.Instance;

            // Act
            var board = factory.CreateBoard("TestBoard");

            // Assert
            Assert.IsInstanceOfType(board, typeof(IBoard));
        }
        [TestMethod]
        public void ThrowArgumentNullException_NullName()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Board(default));
        }
        [TestMethod]
        public void ThrowArgumentException()
        {

            Assert.ThrowsException<ArgumentException>(
                () => new Board("As"));
        }
    }
}
