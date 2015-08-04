using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.ILTests
{
    [TestClass]
    public class FSUnitTests
    {
        //validate stack functionality: 
        //push element (x)
        //pop element: it should return x
        [TestMethod]
        public void validateStack()
        {
            var stack = new Stacks.Stack<string>();
            stack.Push("Test");
            Assert.AreEqual(stack.Pop, "Test");
        }
    }
}