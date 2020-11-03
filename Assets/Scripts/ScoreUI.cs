using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
     public void AddToScore(int points)
    {
        score += points;
    }
        
}
