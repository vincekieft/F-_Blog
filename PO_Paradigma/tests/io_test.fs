module io_test

open NUnit.Framework
open IO
open System

[<TestFixture>]
type IOTests () =

    member this.validatePathTest() = 
        Assert.Throws<Exception>(fun () -> IO.validatePath(null) |> ignore)
