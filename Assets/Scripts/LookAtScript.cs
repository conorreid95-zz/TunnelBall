using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0f, 0.84f, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
