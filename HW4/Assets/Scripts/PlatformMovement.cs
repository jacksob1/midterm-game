using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    float speed = 2f;
    float rotation_const = 0.25f;
    Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;

        Vector2 movement = new Vector2(deltaX, deltaY);
        body.velocity = movement;
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 rotation = new Vector3(0, 0, -gameObject.transform.rotation.z + rotation_const);
            gameObject.transform.Rotate(rotation);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Vector3 rotation = new Vector3(0, 0, gameObject.transform.rotation.z - rotation_const);
            gameObject.transform.Rotate(rotation);
        }
        else {
            Vector3 rotation = new Vector3(0, 0, -gameObject.transform.rotation.z);
            gameObject.transform.Rotate(rotation);
        }
    }
}
