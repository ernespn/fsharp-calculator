module Program

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Writers
open Suave.Json
open Newtonsoft.Json
open Calculator


let CORS = 
  setHeader "Access-Control-Allow-Origin" "*" >=> setHeader "Access-Control-Allow-Headers" "content-type" 
  >=> setHeader "Access-Control-Allow-Methods" "POST, GET, OPTIONS, DELETE, PATCH"

let app =
  choose
    [ GET >=> choose
        [   pathScan "/add/%d/%d" (fun (a,b) -> OK ( JsonConvert.SerializeObject (value (add a b)) )) 
            >=> Writers.setMimeType "application/json; charset=utf-8"
            >=> CORS
            ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST"
          path "/goodbye" >=> OK "Good bye POST" ] 
      RequestErrors.NOT_FOUND "Page not found." ]

let cfg =
        { defaultConfig with
            bindings = [ HttpBinding.mk HTTP (System.Net.IPAddress.Parse "0.0.0.0") 8083us  ] }

startWebServer cfg app
