using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Assembly and Initialization cleanup Methods
    /// </summary>
    [TestClass]
    public class MyClassesTestInitialization
    {


        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In the Assembly Initialize Method.");
            //TODO: Create respources for tests. 


        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //TODO: Create resources for tests. 
        }
    }
}
