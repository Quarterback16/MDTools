using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MDTools.Tests
{
    [TestClass]
    public class MDToolTests
    {
        private MDTool _cut;

        [TestInitialize]
        public void Setup()
        {
            _cut = new MDTool();
        }

        [TestMethod]
        public void MDTool_Instantiates_Ok()
        {
            Assert.IsNotNull(_cut);
        }

        [TestMethod]
        public void InsertAtTag_WhenFileDoesNotExist_Fails()
        {
            var result = _cut.InsertAtTag(
                "testTag",
                "XXXX",
                "unknown-testfile.md");
            System.Console.WriteLine(result.Error);
            Assert.IsTrue(result.IsFailure);
        }

        [TestMethod]
        public void InsertAtTag_WhenFileDoesExist_Continues()
        {
            var result = _cut.InsertAtTag(
                "testTag",
                "XXXX",
                "testfile.md");
            Assert.IsTrue(result.IsSuccess);
            System.Console.WriteLine(result);
        }

        [TestMethod]
        public void InsertAtTag_WhenTagNotThere_Fails()
        {
            var result = _cut.InsertAtTag(
                "invalid-testTag",
                "XXXX",
                "testfile.md");
            Assert.IsTrue(result.IsFailure);
            System.Console.WriteLine(result.Error);
        }
    }
}