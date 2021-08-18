using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlaneMover : MonoBehaviour
{
   
    Vector3 position;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        position.x = Mathf.RoundToInt(transform.position.x );
        position.z = Mathf.RoundToInt(transform.position.z );
        position.y = 0;
        transform.position = position;
    }
}
