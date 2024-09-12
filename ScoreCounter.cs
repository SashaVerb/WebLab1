using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI rightText;
    void Update()
    {
        leftText.text = Ball.leftCounter.ToString();
        rightText.text = Ball.rightCounter.ToString();
    }
}
