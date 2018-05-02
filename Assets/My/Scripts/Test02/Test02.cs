using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour
{
    public Material mat;
    public Vector4 vec4;

    private Material defMat;

	// Use this for initialization
	void Start ()
    {
        var atlas = GetComponent<UISprite>().atlas;
        defMat = atlas.spriteMaterial;
        atlas.spriteMaterial = mat;
}

    private void Update()
    {
        //mat.SetVector("_ClipRange0", new Vector4(vec4.x, vec4.y, Mathf.Sin(vec4.z), Mathf.Cos(vec4.w)));

    }

    void OnDestroy()
    {
        GetComponent<UISprite>().atlas.spriteMaterial = defMat;
    }
}
