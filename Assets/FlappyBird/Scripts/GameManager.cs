using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject GameOverUI;

    public float timer=0;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerTextUI;

    public Bird bird;

    public CanvasGroup GameOverCanvasGroup; // GameOverUI에 CanvasGroup 추가 후 연결
    public Transform gameOverTextTransform;
    
    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (bird.isLive)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2");
        }
    }

    public void GameOver()
    {
        bird.isLive = false;
        Invoke("GameOverUIon", 1.5f);
        timerTextUI.text = "Time: " + timer.ToString("F2");
        timerText.gameObject.SetActive(false);
    }

    public void GameOverUIon()
    {
        GameOverUI.SetActive(true);
        bird.GetComponent<SpriteRenderer>().enabled = false;

        // CanvasGroup 알파값 0으로 초기화 (투명 상태)
        GameOverCanvasGroup.alpha = 0f;
        GameOverCanvasGroup.DOFade(1f, 1f);  // 1초 동안 서서히 나타나기

        GameOverUI.transform.localScale = Vector3.one;

        // 텍스트에만 펄스 애니메이션 적용 (작아졌다 커졌다 반복)
        gameOverTextTransform
            .DOScale(0.6f, 0.3f)
            .SetLoops(4, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    internal static void LoadScene(object buildIndex)
    {
        throw new NotImplementedException();
    }
}
