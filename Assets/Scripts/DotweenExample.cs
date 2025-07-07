using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class DotweenExample : MonoBehaviour
{
    public Image img;
    public Button playButton; // 버튼 연결

    void Start()
    {
        // transform.DOMove(new Vector3(3, 5, 0), 2f);
        // transform.DOScale(new Vector3(2, 2, 2), 2f);
        // transform.DORotate(new Vector3(0, 0, 180), 3f, RotateMode.FastBeyond360);
        // transform.DOMoveX(5, 2f).SetLoops(-1, LoopType.Yoyo);
        // img.DOFade(0f, 2f);

        //Sequence seq = DOTween.Sequence();

        // seq.Append(transform.DOMoveZ(3f, 2f));

        // seq.Append(transform.DOMoveY(2f, 1f));

        // seq.Append(transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.Fast));

        // seq.Append(transform.DOScale(Vector3.one, 1f));

        // seq.OnComplete(() =>
        // {
        //     Debug.Log("모든 애니메이션 완료!");
        // });

        // seq.Append(transform.DOMoveZ(3f, 2f))
        //     .Append(transform.DOMoveY(2f, 1f))
        //     .Join(transform.DOScale(new Vector3(2, 2, 2), 1f))
        //     .Join(transform.DORotate(new Vector3(0, 180, 0), 1f));

        // seq.OnComplete(() =>
        // {
        //     Debug.Log("모든 애니메이션 완료!");
        // });
        
    }

    public void PlayAnimation()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMoveZ(3f, 2f))
            .Append(transform.DOMoveY(2f, 1f))
            .Join(transform.DOScale(new Vector3(2, 2, 2), 1f))
            .Join(transform.DORotate(new Vector3(0, 180, 0), 1f));

        seq.OnComplete(() =>
        {
            Debug.Log("모든 애니메이션 완료!");
        });
    }


    void Update()
    {
        
    }
}
