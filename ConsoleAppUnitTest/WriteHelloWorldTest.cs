using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ConsoleAppBusinessLogic;

namespace UnitTestProject
{
    /// <summary>
    /// Three sample unit test methods using moq
    /// </summary>
    [TestClass]
    public class WriteHelloWorldTest
    {
        private WriteHelloWorld helloWorldWriter;
        private IWriter outputWriter;


        [TestInitialize]
        public void Initialize()
        {
            outputWriter = new Moq.Mock<IWriter>().Object;
            helloWorldWriter = new WriteHelloWorld(outputWriter);

        }

        [TestMethod]
        public void Validate_ValidMessage_IsTrue()
        {
            string message = "Hello World";
            Assert.IsTrue(helloWorldWriter.ValidateHelloWorld(message));
        }

        [TestMethod]
        public void Validate_InvalidMessage_IsFalse()
        {
            string message = "Not Hello World";
            Assert.IsFalse(helloWorldWriter.ValidateHelloWorld(message));
        }

        [TestMethod]
        public void WriteValidMessage_IsSuccessfull()
        {
            string message = "Hello World";
            Assert.IsTrue(helloWorldWriter.Write(message));
        }
    }
}
