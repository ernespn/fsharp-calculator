module Program

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Json
open Newtonsoft.Json

let add x y = x+y
type result = { value : int ; from : string }
let value x = { value = x ; from = "F# services" }

let app =
  choose
    [ GET >=> choose
        [   pathScan "/add/%d/%d" (fun (a,b) -> OK ( JsonConvert.SerializeObject (value (add a b)) )) 
            >=> Writers.setMimeType "application/json; charset=utf-8"
            ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST"
          path "/goodbye" >=> OK "Good bye POST" ] 
      RequestErrors.NOT_FOUND "Page not found." ]

let cfg =
        { defaultConfig with
            bindings = [ HttpBinding.mk HTTP (System.Net.IPAddress.Parse "0.0.0.0") 8083us  ] }

startWebServer cfg app
