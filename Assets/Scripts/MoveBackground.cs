using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [Range(-1f, 1f)]
    [SerializeField] float scrollSpeed = 0.5f;

    float offset;
    Material mat; 

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
