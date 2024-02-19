using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionControl_Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VersionControl_Part2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ValidInputTest()
        {
            Assert.IsTrue(Program.Input("1"));
            Assert.IsTrue(Program.Input("2"));
        }

        [TestMethod()]
        public void InValidInputTest()
        {
            Assert.IsFalse(Program.Input("9"));
            Assert.IsFalse(Program.Input("hello"));
        }

        [TestMethod()]
        public void PrintMenuTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.PrintMenu();

                Assert.IsTrue(sw.ToString().Contains("3. Display Random Dinosaur"));
            }
        }

        [TestMethod()]
        public void RandomIntegerTest()
        {
            Assert.IsTrue(Program.RandomInteger() >= 0);
            Assert.IsTrue(Program.RandomInteger() <= 10);
        }

        [TestMethod()]
        public void TodaysDateTest()
        {
            Assert.IsTrue(Program.TodaysDate() == "Today's date is: " + DateTime.Now.ToShortDateString());
        }

        [TestMethod()]
        public void RandomDinosaurTest()
        {
            Assert.IsTrue(Program.RandomDinosaur().Length > 17);
        }

        [TestMethod()]
        [DataRow("Nothing")]
        [DataRow("somebigword")]
        public void RandomStringModValidTest(string value)
        {
            using (var reader = new StringReader(value))
            {
                Console.SetIn(reader);

                var result = Program.RandomStringMod();

                Assert.IsNotNull(result);
                Assert.AreNotEqual(result, value);
            }
        }

        [TestMethod()]
        [DataRow("")]
        public void RandomStringModInValidTest(string value)
        {
            using (var reader = new StringReader(value))
            {
                Console.SetIn(reader);

                var result = Program.RandomStringMod();

                Assert.IsNull(result);
            }
        }

        [TestMethod()]
        public void MainTest()
        {
            using (var reader = new StringReader("2"))
            {
                Console.SetIn(reader);
            }
            Program.TodaysDate();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Assert.IsTrue(Program.TodaysDate() == "Today's date is: " + DateTime.Now.ToShortDateString());
            }
        }
    }
}