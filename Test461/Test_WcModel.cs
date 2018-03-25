using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppModel;
using AppViewModel;

namespace Test
{
    [TestClass]
    public class Test_All
    {
        [TestMethod]
        public void WcCtor()
        {
            var wc = new WcModel();
            Assert.AreEqual (0, wc.Bind.History.Count);
        }

        [TestMethod]
        public void WcParse()
        {
            var wc = new WcModel();
            int k1 = wc.Parse ("a bb ccc");
            Assert.AreEqual (3, k1);
            Assert.AreEqual (1, wc.Bind.History.Count);
        }

        [TestMethod]
        public void VmInput()
        {
            var wc = new WcModel();

            var pr = new WcPresenter (wc);

            Assert.AreEqual (0, pr.WC.History.Count);

            wc.Parse ("aaa bb c");
            Assert.IsTrue (pr.WC.History[0].StartsWith ("3 words"));
        }
    }
}
