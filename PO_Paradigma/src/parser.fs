module Parser

    open System
    open Types

    let toLines(content: String) : String[] =
        content.Split('\n')

    let rec parse<'T>(lines: String[], parser, index: int, result: 'T[]) : 'T[] = 
        if index >= lines.Length then result
        else 
            let result = Array.append result (parser(Array.get lines index))
            parse<'T>(lines, parser, index + 1, result)

    let vector3Parser(line: String, matchPattern: String) : Vector3[] = 
        if line = null || line.Length = 0 then [||]
        else
            let splitted = line.Split ' '
            let lineType = Array.get splitted 0
            if splitted.Length <> 4 || lineType <> matchPattern  then [||]
            else [|new Vector3(
                Double.Parse(Array.get splitted 1), 
                Double.Parse(Array.get splitted 2), 
                Double.Parse(Array.get splitted 3)
            )|]

    let vector2Parser(line: String, matchPattern: String) : Vector2[] = 
        if line = null || line.Length = 0 then [||]
        else
            let splitted = line.Split ' '
            let lineType = Array.get splitted 0
            if splitted.Length <> 3 || lineType <> matchPattern  then [||]
            else [|new Vector2(
                Double.Parse(Array.get splitted 1), 
                Double.Parse(Array.get splitted 2)
            )|]

    let triangleVertexParser(line: String) : TriangleVertex =
        if line = null || line.Length = 0 then null
        else
            let splitted = line.Split '/'
            if splitted.Length <> 4 then null
            else new TriangleVertex(
                Int16.Parse(Array.get splitted 0), 
                Int16.Parse(Array.get splitted 1),
                Int16.Parse(Array.get splitted 2)
            )

    let triangleParser(line: String) : Triangle[] =
        if line = null || line.Length = 0 then [||]
        else
            let splitted = line.Split ' '
            let lineType = Array.get splitted 0
            if splitted.Length <> 4 || lineType <> "f" then [||]
            else [|new Triangle(
                triangleVertexParser(Array.get splitted 1), 
                triangleVertexParser(Array.get splitted 2),
                triangleVertexParser(Array.get splitted 3)
            )|]

    let textureCoordParser(line: String) : Vector2[] =
        vector2Parser(line, "vt")

    let vertexParser(line: String) : Vector3[] =
        vector3Parser(line, "v")

    let normalParser(line: String) : Vector3[] =
        vector3Parser(line, "vn")

    let parseToMesh(lines: String[]) : Mesh =
        new Mesh(
            parse<Vector3>(lines, vertexParser, 0, [||]),
            parse<Vector2>(lines, textureCoordParser, 0, [||]),
            parse<Vector3>(lines, normalParser, 0, [||]),
            parse<Triangle>(lines, triangleParser, 0, [||])
        )