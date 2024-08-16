using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text mytext = GetComponent<TMP_Text>();
        Color c = mytext.color;
        c.a = 0.5f;
        mytext.DOColor(c, 1f).SetLoops(-1, LoopType.Yoyo);

        BirdController bird = FindObjectOfType<BirdController>();
        bird.OnPlay += DisableText;
    }

    void DisableText()
    {
        TMP_Text mytext = GetComponent<TMP_Text>();
        mytext.DOKill();
        gameObject.SetActive(false);
    }

    
}
