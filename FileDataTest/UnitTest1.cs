using System;
using System.Linq;
using System.Text.RegularExpressions;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileDataTest
{
    [TestClass]
    public class FileDataTest
    {
        private static bool RegexCheckVersion(string testString)
        {
            var rgx = new Regex(@"^\d[.]\d[.]\d\d?$");
            return rgx.IsMatch(testString);
        }

        private static bool TestSize(string testString)
        {
            return testString.All(c => c >= '0' && c <= '9');
        }

        [TestMethod]
        public void WrongNumberOfArguments()
        {
            var args = new[] { "-v" };
            var argumentManipulator = new ArgumentManipulator(args);
            var result = argumentManipulator.Execute();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void WrongNumberOfArguments2()
        {
            var args = new[] { "-v", "c:/test.txt", "I am not supposed to be here" };
            var argumentManipulator = new ArgumentManipulator(args);
            var result = argumentManipulator.Execute();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void UnsupportedArgument()
        {
            var args = new[] { "-d", "c:/test.txt" };
            var argumentManipulator = new ArgumentManipulator(args);
            var result = argumentManipulator.Execute();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestVersion()
        {
            var args = new[]
            {
                new []{
                    "-v",
                    "c:/test.txt"
                },
                new []{
                    "--v",
                    "c:/test.txt"
                },
                new []{
                    "/v",
                    "c:/test.txt"
                },
                new []{
                    "--version",
                    "c:/test.txt"
                }
            };

            foreach (var argPair in args)
            {
                var argumentManipulator = new ArgumentManipulator(argPair);
                var result = argumentManipulator.Execute();
                Assert.IsTrue(RegexCheckVersion(result));
            }
        }

        [TestMethod]
        public void TestSize()
        {
            var args = new[]
            {
                new []{
                    "-s",
                    "c:/test.txt"
                },
                new []{
                    "--s",
                    "c:/test.txt"
                },
                new []{
                    "/s",
                    "c:/test.txt"
                },
                new []{
                    "--size",
                    "c:/test.txt"
                }
            };

            foreach (var argPair in args)
            {
                var argumentManipulator = new ArgumentManipulator(argPair);
                var result = argumentManipulator.Execute();
                Assert.IsTrue(TestSize(result));
            }
        }

    }
}
