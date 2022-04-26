using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlendShape
{
    public int upper { get; set; }
    public int lower { get; set; }

    public BlendShape(int u = -1, int l = -1)
    {
        this.upper = u; this.lower = l;
    }
}

public class CharacterCustomization : Singleton<CharacterCustomization>
{
    public GameObject target;
    private SkinnedMeshRenderer skinnedMeshRender;
    private Dictionary<string, BlendShape> blendShapes = new Dictionary<string, BlendShape>(); 

    void Start()
    {
        skinnedMeshRender = target.GetComponentInChildren<SkinnedMeshRenderer>();
        ParseBlendShapeData();
    }

    void Update()
    {
        
    }

    private void ParseBlendShapeData()
    {
        string[] cBlendShapeName;

        for (int i = 0; i < skinnedMeshRender.sharedMesh.blendShapeCount; i++)
        {
            cBlendShapeName = skinnedMeshRender.sharedMesh.GetBlendShapeName(i).Split("_");

            if (!blendShapes.ContainsKey(cBlendShapeName[1]))
                blendShapes.Add(cBlendShapeName[1], new BlendShape(i, i));
            else
            {
                if (cBlendShapeName[0] == "u")
                    blendShapes[cBlendShapeName[1]].upper = i;
                if (cBlendShapeName[0] == "l")
                    blendShapes[cBlendShapeName[1]].lower = i;
            }
        }
    }

    public bool ChangeBlendShapeValue(string sBlendShapeName, float dValue)
    {
        if (!blendShapes.ContainsKey(sBlendShapeName))
        {
            Debug.LogError($"BlendShape {sBlendShapeName} not found!");
            return false;
        }

        int dBlendShapeIndex;

        if (dValue < 0)
            dBlendShapeIndex = blendShapes[sBlendShapeName].lower;
        else
            dBlendShapeIndex = blendShapes[sBlendShapeName].upper;

        if (dBlendShapeIndex == -1)
        {
            Debug.LogError($"BlendShapeIndex for {sBlendShapeName} not parsed!");
            return false;
        }

        skinnedMeshRender.SetBlendShapeWeight(dBlendShapeIndex, Mathf.Abs(dValue));

        return true;
    }

}
