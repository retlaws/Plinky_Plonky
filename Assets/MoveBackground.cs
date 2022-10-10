using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] float yAxisMovement = 1f; 

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(0, yAxisMovement);
        transform.Translate(move * -1 * Time.deltaTime);   
    }
}
