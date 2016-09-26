namespace calculator.Test

open Xunit
open Calculator

module calculatorTest =
    [<Fact>]
    let ``When 2 is added to 3 you get 5``() =
        Assert.Equal(5, add 2 3)
