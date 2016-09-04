module Program

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Json

let add x y = x+y
let result x = sprintf "{ \"result\":  %s ; \"from\": \"F# services\" }" x

let app =
  choose
    [ GET >=> choose
        [   pathScan "/add/%d/%d" (fun (a,b) -> OK ((add a b).ToString() |> result )) 
            ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST"
          path "/goodbye" >=> OK "Good bye POST" ] 
      RequestErrors.NOT_FOUND "Page not found." ]

let cfg =
        { defaultConfig with
            bindings = [ HttpBinding.mk HTTP (System.Net.IPAddress.Parse "0.0.0.0") 8083us  ] }

startWebServer cfg app
