using CodingExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.IO.Abstractions;

namespace ProximityTests
{
    [TestClass]
    public class ProcessTest
    {
        Mock<IProximitySearch> mockProximitySearch;
        Mock<IFileSystem> mockFileSystem;
        Process process;

        [TestInitialize]
        public void Intialize()
        {
            mockProximitySearch = new Mock<IProximitySearch>();
            mockFileSystem = new Mock<IFileSystem>();
            process = new Process(mockProximitySearch.Object,mockFileSystem.Object);
        }
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Start_InvalidArgumentLength()
        {
            //Invalid Argument Lengths
            string[] args = new string[5];
            process.Start(args);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Start_InvalidTypeRange()
        {
            string[] args = new string[4] { "test", "canal", "str", ".txt" };
            process.Start(args);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Start_InvalidNumberRange()
        {
            string[] args = new string[4] { "test", "canal", "1", ".txt" };
            process.Start(args);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Start_InvalidFilePath()
        {
            string[] args = new string[4] { "test", "canal", "3", "input5.txt" };
            process.Start(args);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Start_FileException()
        {
            string filePath = @".\ROFile.txt";
            string[] args = new string[4] { "test", "canal", "3", filePath };
            mockFileSystem.Setup(x => x.File.ReadAllText(filePath)).Throws(new Exception());
            process.Start(args);
        }

        [TestMethod]
        public void Start_ValidArgs()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "input.txt");
            string[] args = new string[4] { "test", "canal", "2", filePath };
            mockProximitySearch.Setup(x => x.CalculateOccurences(
                                      It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(2);
            mockFileSystem.Setup(x => x.File.ReadAllText(filePath)).Returns("dummy");
            Assert.IsTrue(process.Start(args) == 2);
        }
    }
}
