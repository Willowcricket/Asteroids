using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScore : MonoBehaviour
{
    public static int ScoreValue;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreValue = GameManager.instance.Lives;
        score.text = "Lives: " + ScoreValue;
    }
}
