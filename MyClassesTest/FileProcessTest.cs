using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\Users\Stephen.Pino\Documents\BadFileName.bad";
        private string _GOODFileName;

        public TestContext TestContext { get; set; }

        /*Should code change in project the test should provide exception for developer to know issues. */
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            SetGoodFileName();
            TestContext.WriteLine("Creating the file" + _GOODFileName);
            File.AppendAllText(_GOODFileName, "Some Text");
            TestContext.WriteLine("Testing the file" + _GOODFileName);
            fromCall = fp.FileExists(_GOODFileName);
            TestContext.WriteLine("Deleting the file" + _GOODFileName);
            File.Delete(_GOODFileName);

            //Assert
            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GOODFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GOODFileName.Contains("[AppPath]"))
            {
                _GOODFileName = _GOODFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            fromCall = fp.FileExists(BAD_FILE_NAME);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //Arrange
            FileProcess fp = new FileProcess();

            //Act
            fp.FileExists("");            
            
        }

        [TestMethod]        
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            //Arrange
            FileProcess fp = new FileProcess();

            try
            {   //Act
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //Act - Test was a success if caught
                return;
            }

            //Assert
            Assert.Fail("call to FileExists method did not throw a ArgumentNullException");
        }
    }
}
