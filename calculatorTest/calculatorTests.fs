namespace calculator.Test

open Xunit
open Calculator

module calculatorTest =
    [<Fact>]
    let ``When 2 is added to 3 you get 5``() =
        Assert.Equal(5, add 2 3)

    [<Fact>]
    let ``When always return from clause f# services and the value passed``() =
        let result = value 3 
        Assert.Equal(3, result.value)
        Assert.Equal("F# services", result.from)