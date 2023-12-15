using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 500f;
    
    [SerializeField]
    private LayerMask _grabLayer;
    [SerializeField]
    private LayerMask _snapLayer;

    Vector3 movement;
    Vector2 direction;
    GameObject item;

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

        if (Input.GetButtonDown("Select"))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1f, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 1f, _grabLayer);
            if (hit && (item == null))
            {
                Debug.Log("Grabbed " + hit.collider.name);
                item = hit.collider.gameObject;
            }
            else if (item != null)
            {
                RaycastHit2D place = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 1f, _snapLayer);
                if (place)
                {
                    item.transform.position = place.transform.position;
                    Debug.Log("Dropped " + item.name);
                    item = null;
                }
                else
                {
                    Debug.Log("No place to drop " + item.name);
                }                
            }
            else
            {
                Debug.Log("No item in range");
            }
        }
    }

    void FixedUpdate()
    {
        //Movement
        transform.position = transform.position + movement * moveSpeed * Time.fixedDeltaTime;
        if (item != null)
        {
            item.transform.position = transform.position;
        }
        if (direction != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
