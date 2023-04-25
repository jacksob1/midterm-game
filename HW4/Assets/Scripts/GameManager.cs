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
    int score = 0;

    void Start()
    {
        text.text = time_remaining.ToString();
        score_text.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time_remaining -= Time.deltaTime;
        text.text = time_remaining.ToString();
        score++;
        score_text.text = "Score: " + score.ToString();
    }
}
