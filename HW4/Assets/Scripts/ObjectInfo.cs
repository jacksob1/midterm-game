using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    private void Start()
    {
        EventBus.Subscribe(EventBus.EventType.GameOver, Death); 
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7) {
            EventBus.Publish(EventBus.EventType.GameOver);
        }
    }

    void Death() {
        EventBus.Unsubscribe(EventBus.EventType.GameOver, Death);
        Destroy(gameObject);
    }
}
