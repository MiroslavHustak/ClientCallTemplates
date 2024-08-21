namespace LLM_API

open System
open FsHttp
open Newtonsoft.Json

open TestAPI

module API = 
    
    CallRestApiWeather.runRestApiWeather ()
    
    CallRestApiWeatherThoth.runRestApiWeatherThoth ()

    //Console.ReadKey() |> ignore

    //CallRestApi.runRestApi ()

    CallRestApiThoth.runRestApiThoth ()

    //Console.ReadKey() |> ignore
    
    //CallRpc.runRpc ()

    Console.ReadKey() |> ignore

    (*
    Key Differences:
    Data Location:
    
    GET: Data in the URL (query string).
    POST: Data in the body of the request.
    Use Case:
    
    GET: Retrieving information without causing side effects.
    POST: Sending data that modifies or creates resources.
    Security Considerations:
    
    GET: Less secure for sensitive data, as URLs can be logged in browser history, server logs, etc.
    POST: More secure for sensitive data, as the payload is not logged in URLs (although still needs HTTPS for full security).
    Size Limitation:
    
    GET: Limited by URL length (which can vary by browser but typically around 2,000 characters).
    POST: No strict size limitation, can send large amounts of data.

Key Differences Between GET, POST, and PUT:
Aspect	GET	POST	PUT
Purpose	Retrieve data from the server	Submit data to create or modify a resource	Update or replace an existing resource (or create if it doesn't exist)
Data Location	URL (query parameters)	Request body	Request body
Idempotency	Idempotent (repeated calls have the same effect)	Not idempotent (repeated calls can create multiple resources)	Idempotent (repeated calls have the same effect)
Caching	Typically cacheable	Not cacheable	Usually not cacheable
Security	Less secure for sensitive data (data in URL)	More secure for sensitive data (data in body, but use HTTPS)	Similar to POST, secure if HTTPS is used
Use Case	Retrieve information without side effects	Submit data that modifies or creates a resource	Update or fully replace an existing resource (or create)
Size Limitation	Limited by URL length (usually around 2,000 characters)	No strict size limitation, data in body	No strict size limitation, data in body
Typical Example	Retrieving a list of users	Creating a new user	Updating an existing user's details
Summary of When to Use Each:
GET:

When to Use: Retrieving data from the server without altering any resources.
Example: Fetching user details: GET /api/users/123
Idempotent? Yes.
POST:

When to Use: Sending data to the server to create a new resource or perform an action that changes state.
Example: Creating a new user: POST /api/users
Idempotent? No.
PUT:

When to Use: Updating an existing resource with new data, or creating the resource if it doesn't exist. PUT replaces the entire resource with the provided data.
Example: Updating a user’s details: PUT /api/users/123
Idempotent? Yes.
    *)