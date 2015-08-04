module HelloWorld.Tests.StackTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Stacks

[<TestClass>]
type testrun() = 

    [<TestMethod>]
    member x.validateStackFS() =
            let stack = new Stack<string>();
            stack.Push "Hello World"
            Assert.AreEqual ("Hello World", stack.Pop)
            
            

         