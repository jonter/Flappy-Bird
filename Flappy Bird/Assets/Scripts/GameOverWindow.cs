using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Button restartButton;

    [SerializeField] RectTransform overWindow;
    BirdController bird;
    // Start is called before the first frame update
    void Start()
    {
        overWindow.anchoredPosition = new Vector2(0, 2000);
        overWindow.gameObject.SetActive(false);
        bird = FindObjectOfType<BirdController>();
        bird.OnDeath += GameOver;
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        overWindow.DOKill();
    }

    void RestartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    void GameOver()
    {
        overWindow.gameObject.SetActive(true);
        overWindow.DOAnchorPosY(0, 1).SetEase(Ease.OutBack);
        ScoreManager manager = FindObjectOfType<ScoreManager>();
        int score = manager.GetScore();
        scoreText.text = "" + score;
    }





    
}
