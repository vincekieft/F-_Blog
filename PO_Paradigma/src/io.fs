module IO
    
    open System
    open System.IO

    let validatePath(path: String) : Boolean =
        if path = null then false
        elif path = "" then false
        elif File.Exists(path) = false then false
        else true

    let readPath(path: String) : String =
        if validatePath path = false then raise (Exception("Invalid path"))
        else File.ReadAllText(path)