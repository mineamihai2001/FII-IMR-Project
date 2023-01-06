using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaleighSofaConstructor : FurnitureConstructor<RaleighSofaConstructor>
{
    override protected string GetPath() { return "Furniture/Sofa/Raleigh/"; }

    static RaleighSofaConstructor()
    {
        colorPaletteList.Add(new(new("Light Wood", null), new("Leather", ColorEnum.Black)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Leather", ColorEnum.SilverSand)));
        colorPaletteList.Add(new(new("Dark Wood", null), new("Leather", ColorEnum.White)));
    }

    override protected void Awake()
    {
        base.Awake();
        parameters.Add("Sofa Size", new(1, 1, 4));
    }

    public List<string> GetFurnitureParameters()
    {
        List<string> rv = new();
        foreach (KeyValuePair<string, FurnitureParameter> entry in parameters)
        {
            rv.Add(entry.Key);
        }
        return rv;
    }

    private static Vector3 GetMeshMinBoundaries(GameObject obj)
    {
        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float minZ = float.MaxValue;
        foreach (Vector3 vertex in obj.GetComponent<MeshFilter>().mesh.vertices)
        {
            if (vertex.x < minX)
                minX = vertex.x;
            if (vertex.y < minY)
                minY = vertex.y;
            if (vertex.z < minZ)
                minZ = vertex.z;
        }

        return new Vector3(minX, minY, minZ);
    }

    private static Vector3 GetMeshMaxBoundaries(GameObject obj)
    {
        float maxX = float.MinValue;
        float maxY = float.MinValue;
        float maxZ = float.MinValue;

        //for each vertice in readmode
        foreach (Vector3 vertex in obj.GetComponent<MeshFilter>().mesh.vertices)
        {
            if (vertex.x > maxX)
                maxX = vertex.x;
            if (vertex.y > maxY)
                maxY = vertex.y;
            if (vertex.z > maxZ)
                maxZ = vertex.z;
        }

        return new Vector3(maxX, maxY, maxZ);
    }

    private static Vector3 GetSize(GameObject obj, bool scaled = false)
    {
        var min = GetMeshMinBoundaries(obj);
        var max = GetMeshMaxBoundaries(obj);
        

        var rv = max - min;
        if (scaled)
            rv.Scale(obj.transform.localScale);


        return rv;       
    }
    private static float epsilon = 0.0001f;

    private static bool IsEqual(float a, float b)
    {
        return Mathf.Abs(a - b) < epsilon;
    }
    private static void MiddleSplitMeshe(GameObject obj, float offset)
    {
        Vector3 offsetVector = new Vector3(offset, 0f, 0f);

        var min = GetMeshMinBoundaries(obj);
        var max = GetMeshMaxBoundaries(obj);
        Vector3 middle = (max + min) / 2;


        List<Vector3> objVertices = new();
        Mesh objMesh = obj.GetComponent<MeshFilter>().sharedMesh;
        objMesh.GetVertices(objVertices);

        for (int i = 0; i < objVertices.Count; i++)
        {
            if (IsEqual(objVertices[i].x, middle.x))
                continue;
            if (objVertices[i].x > middle.x)
                objVertices[i] += offsetVector;
            else
                objVertices[i] -= offsetVector;
        }

        objMesh.SetVertices(objVertices);
        objMesh.RecalculateBounds();
        objMesh.RecalculateNormals();
        objMesh.RecalculateTangents();
    }

    private static float ArrayOfGameObject(GameObject obj, int count, float spaceBetween = 0f)
    {
        var objSize = GetSize(obj, true);
        var xSize = objSize.x;
        if (count == 1)
            return xSize;

        float rv = xSize * count + spaceBetween * (count - 1);
        obj.transform.position += new Vector3((rv-xSize)/2, 0, 0);
       
        
        for (int i = 1; i < count; i++)
        {
            GameObject clone = Instantiate(obj, obj.transform.parent, false);
            clone.transform.position -= new Vector3(objSize.x * i + spaceBetween * i, 0, 0);
        }

        return rv;
    }

    protected async override void Construct()
    {

        var sofaSize = parameters["Sofa Size"].Value;

        var leatherMaterial = await getMaterial(1);
        var woodMaterial = await getMaterial(0);

        GameObject bottomPillow = GetPart("bottom_pillow");
        bottomPillow.GetComponent<Renderer>().material = leatherMaterial;
        var bottomPillowSize = GetSize(bottomPillow);
        bottomPillow.transform.position += new Vector3(0, 0.356754f, -0.04246f);
        var pillowArraySize = ArrayOfGameObject(bottomPillow, sofaSize) / 100f;
        float objectsOffsize = (pillowArraySize - bottomPillowSize.x)/2;
        Vector3 objectOffsetVector = new(objectsOffsize * 100f, 0f, 0f);

        GameObject bottomBase = GetPart("bottom_base");
        bottomBase.GetComponent<Renderer>().material = leatherMaterial;
        bottomBase.transform.position += new Vector3(0, 0.34402f, 0);
        MiddleSplitMeshe(bottomBase, objectsOffsize);


        GameObject backBase = GetPart("back_base");
        backBase.GetComponent<Renderer>().material = leatherMaterial;
        backBase.transform.position += new Vector3(0, 0.545357f, 0.409679f);
        ArrayOfGameObject(backBase, sofaSize);

        GameObject backLeg = GetPart("back_leg");
        backLeg.GetComponent<Renderer>().material = woodMaterial;
        backLeg.transform.position += new Vector3(0, 0.198041f, 0.47664f);
        ArrayOfGameObject(backLeg, 2, 2 * (0.245601f + objectsOffsize * 100 ) - GetSize(backLeg).x * 100);

        GameObject frontLeg = GetPart("front_leg");
        frontLeg.GetComponent<Renderer>().material = woodMaterial;
        frontLeg.transform.position += new Vector3(0, 0.111322f, -0.31311f);
        ArrayOfGameObject(frontLeg, 2, 2 * (0.3785f + objectsOffsize * 100) - GetSize(frontLeg).x * 100);

        GameObject curveGrid = GetPart("cube_grid");
        curveGrid.GetComponent<Renderer>().material = woodMaterial;
        curveGrid.transform.position += new Vector3(0, 0.194029f, 0.085f);
        MiddleSplitMeshe(curveGrid, objectsOffsize);


        GameObject backPillow = GetPart("top_pillow");
        backPillow.GetComponent<Renderer>().material = leatherMaterial;
        backPillow.transform.position += new Vector3(0, 0.628776f, 0.311343f);
        ArrayOfGameObject(backPillow, sofaSize);

        GameObject topCylinder = GetPart("top_cylinder");
        topCylinder.GetComponent<Renderer>().material = woodMaterial;
        topCylinder.transform.position += new Vector3(0, 0.516011f, 0.463692f);
        MiddleSplitMeshe(topCylinder, objectsOffsize);
    }
}
