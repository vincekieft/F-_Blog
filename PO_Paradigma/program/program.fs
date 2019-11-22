module Main

open IO
open System
open Parser
open Types

(*    [<EntryPoint>]
    let main argv =
        Console.Write("Locate the .obj file you want to load\n")
        let path = Console.ReadLine()
        let content = IO.readPath(path)
        let lines = Parser.toLines(content)
        let mesh = Parser.parseToMesh(lines)
        
        printfn "Vertices: %i" mesh.Vertices.Length
        printfn "Normals: %i"mesh.Normals.Length
        printfn "Triangles: %i"mesh.Triangles.Length
        printfn "Coords: %i"mesh.Coords.Length

        let path = Console.ReadLine() // Keeps the console from closing
        0 // return an integer exit code*)

    [<EntryPoint>]
    let main argv =
        let content = "
        # cube.obj\n\
        v -0.500000 -0.500000 0.500000\n\
        v 0.500000 -0.500000 0.500000\n\
        v -0.500000 0.500000 0.500000\n\
        v 0.500000 0.500000 0.500000\n\
        v -0.500000 0.500000 -0.500000\n\
        v 0.500000 0.500000 -0.500000\n\
        v -0.500000 -0.500000 -0.500000\n\
        v 0.500000 -0.500000 -0.500000\n\
        vt 0.000000 0.000000\n\
        vt 1.000000 0.000000\n\
        vt 0.000000 1.000000\n\
        vt 1.000000 1.000000\n\
        vn 0.000000 0.000000 1.000000\n\
        vn 0.000000 1.000000 0.000000\n\
        vn 0.000000 0.000000 -1.000000\n\
        vn 0.000000 -1.000000 0.000000\n\
        vn 1.000000 0.000000 0.000000\n\
        vn -1.000000 0.000000 0.000000\n\
        f 1/1/1 2/2/1 3/3/1\n\
        f 3/3/1 2/2/1 4/4/1\n\
        f 3/1/2 4/2/2 5/3/2\n\
        f 5/3/2 4/2/2 6/4/2\n\
        f 5/4/3 6/3/3 7/2/3\n\
        f 7/2/3 6/3/3 8/1/3\n\
        f 7/1/4 8/2/4 1/3/4\n\
        f 1/3/4 8/2/4 2/4/4\n\
        f 2/1/5 8/2/5 4/3/5\n\
        f 4/3/5 8/2/5 6/4/5\n\
        f 7/1/6 1/2/6 5/3/6\n\
        f 5/3/6 1/2/6 3/4/6\n\
        "

        let lines = Parser.toLines(content)
        let mesh = Parser.parseToMesh(lines)
        
        printfn "Vertices: %i" mesh.Vertices.Length
        printfn "Normals: %i"mesh.Normals.Length
        printfn "Triangles: %i"mesh.Triangles.Length
        printfn "Coords: %i"mesh.Coords.Length

        let path = Console.ReadLine() // Keeps the console from closing
        0 // return an integer exit code