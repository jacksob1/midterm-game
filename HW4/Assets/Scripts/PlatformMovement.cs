using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    float speed = 2f;
    float rotation_const = 0.5f;
    Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        EventBus.Subscribe(EventBus.EventType.Restart, ResetPosition);
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

    private void ResetPosition()
    {
        Vector3 startingPos = new Vector3(0, -3, 0);
        Quaternion startingRotation = new Quaternion(0, 0, 0, 0);
        this.gameObject.transform.position = startingPos;
        this.gameObject.transform.SetPositionAndRotation(startingPos, startingRotation);
    }
}
