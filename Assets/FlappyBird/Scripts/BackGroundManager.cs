using UnityEngine;
using DG.Tweening;

public class BackgroundColorChanger : MonoBehaviour
{
    public Camera mainCamera; // 메인 카메라 연결
    public Color[] colors; // 바꿀 색상 배열
    public float transitionTime = 2f; // 색상 전환 시간

    private int currentColorIndex = 0;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // 첫 색상 지정
        mainCamera.backgroundColor = colors[0];

        // 첫 전환 시작
        ChangeToNextColor();
    }

    void ChangeToNextColor()
    {
        // 다음 색상 인덱스 계산
        int nextColorIndex = (currentColorIndex + 1) % colors.Length;
        Color nextColor = colors[nextColorIndex];

        // 배경색을 부드럽게 전환
        mainCamera.DOColor(nextColor, transitionTime).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // 전환 끝나면 다음 색상으로 반복
                currentColorIndex = nextColorIndex;
                ChangeToNextColor();
            });
    }
}