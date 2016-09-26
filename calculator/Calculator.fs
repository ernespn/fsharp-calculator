module Calculator

type result = { value : int ; from : string }

let add x y = x+y
let value x = { value = x ; from = "F# services" }