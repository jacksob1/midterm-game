using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        EventBus.Subscribe(EventBus.EventType.GameOver, DisplayButton);
    }
    public void RestartGame() {
        EventBus.Publish(EventBus.EventType.Restart);
        gameObject.SetActive(false);
    }

    void DisplayButton() {
        gameObject.SetActive(true);
    }
}
