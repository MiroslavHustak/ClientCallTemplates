namespace TestAPI

open System
open FsHttp
open Thoth.Json.Net

open ThothSerializationCoders
open ThothDeserializationCoders

//CLIENT CALL TEMPLATES
//REST API

module CallRestApiThoth =

    let private apiKey = "my-api-key"

    //************************* GET ****************************

    let getFromRestApi () =

        async
            {
                let url = "http://localhost:8080/" 
                
                
                let! response = 
                    http 
                        {
                            GET url
                            header "X-API-KEY" apiKey 
                        }
                    |> Request.sendAsync                                

                //let! response = get >> Request.sendAsync <| url  
                let! jsonString = Response.toTextAsync response 
                
                return
                    Decode.fromString decoderGet jsonString   
                    |> function
                        | Ok value ->
                                    value
                        | Error _  ->  
                                    { 
                                        Message = String.Empty
                                        Timestamp = String.Empty
                                    }                
            }

    let getFromRestApiWithParam () =
    
            async
                {
                    let url = "http://localhost:8080/api/greetings/greet?name=Alice"
    
                    let! response = 
                        http 
                            {
                                GET url
                                header "X-API-KEY" apiKey 
                            }
                        |> Request.sendAsync 

                    //let! response = get >> Request.sendAsync <| url  
                    let! jsonString = Response.toTextAsync response 
                    
                    return
                        Decode.fromString decoderGet jsonString   
                        |> function
                            | Ok value ->
                                        value
                            | Error _  ->  
                                        { 
                                            Message = String.Empty
                                            Timestamp = String.Empty
                                        }                               
                }

    //************************* POST ****************************
    
    let postToRestApi () =
        async
            {
                //let url = "http://localhost:8080/"
                let url = "http://localhost:8080/api/greetings/greet"
                
                let payload = 
                    {
                        Name = "Alice"
                    }               
                
                let thothJsonPayload = Encode.toString 2 (encoderPost payload)

                let! response = 
                    http
                        {
                            POST url
                            header "X-API-KEY" apiKey 
                            body                              
                            json thothJsonPayload
                        }
                    |> Request.sendAsync            

                let! jsonString = Response.toTextAsync response 
                
                return
                    Decode.fromString decoderPost jsonString   
                    |> function
                        | Ok value ->
                                    value
                        | Error _  ->  
                                    { 
                                        Message = String.Empty     
                                    }                
            } 
    
    //************************* PUT ****************************

    let putToRestApi () =
        async
            {
                let url = "http://localhost:8080/user" // !!! /user 

                let payload = 
                    {
                        Id = 2
                        Name = "Robert"
                        Email = "robert@example.com"
                    }
 
                let thothJsonPayload = Encode.toString 2 (encoderPut payload)  

                let! response = 
                    http
                        {
                            PUT url
                            header "X-API-KEY" apiKey 
                            body 
                            json thothJsonPayload
                        }
                    |> Request.sendAsync            

                let! jsonString = Response.toTextAsync response 
                               
                return
                    Decode.fromString decoderPut jsonString   
                    |> function
                        | Ok value ->
                                    value
                        | Error _  ->  
                                    { 
                                        Message = String.Empty
                                        UpdatedDataTableInfo = 
                                            {
                                                Id = -1
                                                Name = String.Empty
                                                Email = String.Empty     
                                            }
                                    }                             
            } 

    let runRestApiThoth () = 

        let response = getFromRestApi () |> Async.RunSynchronously
        printfn "\n\nMessageGet: %s\nTimestamp: %s" response.Message response.Timestamp

        let response1 = getFromRestApiWithParam () |> Async.RunSynchronously
        printfn "\n\nMessageGetWithParam: %s\nTimestamp: %s" response1.Message response1.Timestamp

        let response2 = postToRestApi () |> Async.RunSynchronously
        printfn "\n\nMessagePost: %s" response2.Message 
        
        let response3 = putToRestApi () |> Async.RunSynchronously
        printfn "\n\nMessagePut: %s" response3.Message 
        printfn "Updated: %A" response3.UpdatedDataTableInfo