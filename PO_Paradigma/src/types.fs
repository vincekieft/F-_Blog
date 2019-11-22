module Types

    type Vector3(x: double, y: double, z: double) = 
        let x = x;
        let y = y;
        let z = z;

    type Vector2(x: double, y: double) = 
        let x = x;
        let y = y;

    [<AllowNullLiteralAttribute>]
    type TriangleVertex(vertex: int16, ?normal: int16, ?coord: int16) =
        let vertex = vertex
        let normal = normal
        let coord = coord

    type Triangle(v1: TriangleVertex, v2: TriangleVertex, v3: TriangleVertex) =
        let v1 = v1
        let v2 = v2
        let v3 = v3

    type Mesh(vertices: Vector3[], coords: Vector2[], normals: Vector3[], triangles: Triangle[]) = 
        let vertices = vertices
        let coords = coords
        let normals = normals
        let triangles = triangles

        member this.Vertices = vertices
        member this.Coords = coords
        member this.Normals = normals
        member this.Triangles = triangles
