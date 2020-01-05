using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrivialMvvm;

namespace TestCore
{
    public class MyObservable : Observable
    { }

    [TestClass]
    public class TestMvvm
    {
        [TestMethod]
        public void UnitObserveable_ctor()
        {
            var ob = new MyObservable();
        }
    }
}
