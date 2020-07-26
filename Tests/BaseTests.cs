using NUnit.Framework;
using NUnitTestProject1.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public class BaseTests : BasePage
    {

        //[SetUp]
        //public void StartTest()
        //{
        //    this.OpenURL();
        //}

        [TearDownAttribute]
        public void EndTest()
        {
            this.CloseDriver();
        }
    }
}
