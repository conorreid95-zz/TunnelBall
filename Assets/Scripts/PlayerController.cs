using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;

    Camera mainCamera;

    Vector3 target;
    Vector3 leftTarget;

    float multiplier = 1f;

    public float ForwardMovement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        Physics.gravity = new Vector3(0f, -9.81f, 9.81f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = rigidbody.velocity.x;
        float y = rigidbody.velocity.y;
        float z = rigidbody.velocity.z;

        

        rigidbody.velocity = new Vector3(x, y, ForwardMovement);

        target = new Vector3(-4f, 0.84f, transform.position.z);

        Vector3 heading = target - transform.position;
        print("straight: " + heading);

        float mainThrustSpeed = 1200f * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(multiplier < 8f)
            {
                multiplier = multiplier + Time.deltaTime;
            }
            
            rigidbody.AddRelativeForce(new Vector3(heading.x, heading.y, 0f) * mainThrustSpeed * multiplier);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            multiplier = 1f;
        }

        Vector3 desiredPosition = new Vector3(-4f, 2f, transform.position.z - 7f);
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, desiredPosition, 0.10f);
        mainCamera.transform.position = smoothedPosition;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
