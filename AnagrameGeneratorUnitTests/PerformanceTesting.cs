using BuisnessLogic;
using Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BusinessLogicUnitTests
{
    class PerformanceTesting
    {
        private readonly ITxtReader txtReader;

        public PerformanceTesting()
        {
            txtReader = new TxtReader();
        }

        [Test]
        public void NewMethodPerformance()
        {
            var timer = new Stopwatch();
            timer.Start();

            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var words = txtReader.TxtFileReader(textFilePath);

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Debug.WriteLine(foo);
        }
    }
}
