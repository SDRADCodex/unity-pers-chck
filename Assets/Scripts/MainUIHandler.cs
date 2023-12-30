using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{   
    public GameObject bestScoreText;
    private Text highestScoreText;

    // Start is called before the first frame update
    void Start()
    {   
        highestScoreText = bestScoreText.GetComponent<Text>();
        if(GameManager.Instance != null){
            highestScoreText.text = "Best Score : "+GameManager.Instance.highestScorePlayerName+" : "+GameManager.Instance.score;
        }
    }
}
