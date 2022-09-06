using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private float score;

    [SerializeField] private TextMeshProUGUI scoreNumberText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int scoreGain)
    {
        score += scoreGain;
        scoreNumberText.text = score.ToString();
    }
}
