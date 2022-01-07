using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MDTools.Tests
{
    [TestClass]
    public class MDToolTests
    {
        private MDTool? _cut;

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
    }
}