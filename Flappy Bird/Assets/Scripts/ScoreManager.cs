using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    TMP_Text mytext;
    AudioSource audio;

    int score = 0;

    public int GetScore() {  return score; }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        mytext = GetComponent<TMP_Text>();
        FindObjectOfType<BirdController>().OnPlay += SetZero;
        FindObjectOfType<BirdController>().OnDeath += HideScoreText;
    }

    void SetZero()
    {
        mytext.text = "0";
    }

    public void IncreaseScore()
    {
        score += 1;
        mytext.text = "" + score;
        audio.Play();
    }

    void HideScoreText()
    {
        transform.DOMoveY(6, 1).SetEase(Ease.InBack);
    }

    
}
