module Calculator

type result = { result : int ; from : string }

let add x y = x+y
let value x = { result = x ; from = "F# services" }