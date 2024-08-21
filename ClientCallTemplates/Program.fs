namespace LLM_API

open System
open FsHttp
open Newtonsoft.Json

open TestAPI

module API = 
    
    //CallRestApiWeather.runRestApiWeather ()
    
    CallRestApiWeatherThoth.runRestApiWeatherThoth ()

    Console.ReadKey() |> ignore

    //CallRestApi.runRestApi ()

    //CallRestApiThoth.runRestApiThoth ()

    //Console.ReadKey() |> ignore
    
    //CallRpc.runRpc ()

    //Console.ReadKey() |> ignore