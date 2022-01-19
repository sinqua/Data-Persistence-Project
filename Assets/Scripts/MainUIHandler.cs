using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;

    private int score;
    private string userName;

    // Start is called before the first frame update
    void Start()
    {
        score = MenuDataHandler.Instance.bestScore;
        userName = MenuDataHandler.Instance.bestUser;

        bestScoreText.text = "Best Score: " + score + " / " + "Name: " + userName;
    }
}
