using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 500f;
    
    public Rigidbody2D rb;

    Vector3 movement;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        direction = movement;
        float inputMagnitude = Mathf.Clamp01(direction.magnitude);
        direction.Normalize();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1f, Color.red, 10);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 1f, 10);
            if (hit)
            {
                Debug.Log("Grabbed " + hit.collider.name);
            }
            else
            {
                Debug.Log("No item in range");
            }
        //}
    }

    void FixedUpdate()
    {
        //Movement
        transform.position = transform.position + movement * moveSpeed * Time.fixedDeltaTime;
        if (direction != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
