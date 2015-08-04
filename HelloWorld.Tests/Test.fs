module HelloWorld.Tests.Basic

open NUnit.Framework

[<Test>]
let DoesItSayHello () = Assert.AreEqual("Hello World!", "Hello World!")
