namespace calculator.Test

open NUnit.Framework
open Calculator

[<TestFixture>]
module calculatorTest =
    [<Test>]
    let ``When 2 is added to 3 you get 5``() =
        Assert.AreEqual(5, add 2 3)

    [<Test>]
    let ``When always return from clause f# services and the value passed``() =
        let result = value 3 
        Assert.AreEqual(3, result.value)
        Assert.AreEqual("F# services", result.from)