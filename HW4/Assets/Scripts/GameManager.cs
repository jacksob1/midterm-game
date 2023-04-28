using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    float time_remaining = 60f;
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text score_text;
    [SerializeField] AudioSource source;

    int score = 0;
    bool game_over = false;

    void Start()
    {
        text.text = time_remaining.ToString();
        score_text.text = "Score: " + score.ToString();
        EventBus.Subscribe(EventBus.EventType.GameOver, EndGame);
        EventBus.Subscribe(EventBus.EventType.Restart, RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_over) { 
            time_remaining -= Time.deltaTime;
            if (time_remaining <= 0) {
                EventBus.Publish(EventBus.EventType.GameOver);
            }
            text.text = "Time Remaining: " + Mathf.Round(time_remaining).ToString();
            score++;
            score_text.text = "Score: " + score.ToString();
        }
    }

    void EndGame() {
        Debug.Log("Ending Game");
        source.Play();
        game_over = true;
    }

    void RestartGame() {
        game_over = false;
        score = 0;
        time_remaining = 60f;
        score_text.text = "Score: " + score.ToString();
        text.text = "Time Remaining: " + Mathf.Round(time_remaining).ToString();
    }

    public bool GetGameOver() {
        Debug.LogFormat("Game Over: {0}", game_over);
        return game_over;
    }
}
