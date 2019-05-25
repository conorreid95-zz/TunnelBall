using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundLocal : MonoBehaviour
{
    public bool rotationEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(new Vector3(-4f, 0.84f, transform.position.z), new Vector3(0f, 0f, -90f), Time.deltaTime * 150f);
    }
}
