using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreView : MonoBehaviour
{
    public Text score;
    public Text coins;
    public Text highscore;

    public TextMeshProUGUI finalScore;

    // Update is called once per frame
    void Update()
    {
        score.text = $"score: {FindObjectOfType<GameManager>().score.ToString()}";
        coins.text = $"coins: {FindObjectOfType<GameManager>().coins.ToString()}";
        highscore.text = $"highscore: {FindObjectOfType<GameManager>().highscore.ToString()}";
        finalScore.text = $"Score: {FindObjectOfType<GameManager>().score.ToString()}";
    }
}
