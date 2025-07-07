using System.Runtime.CompilerServices;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 3f; // 점프 힘
    public float rotateSpeed = 3f; // 회전 속도
    private Rigidbody2D rd; //rigidbody2D 컴포넌트
    private Animator animator; // 애니메이터 컴포넌트
    public bool isLive = true; // 생존 여부
    private bool isDeadRotating = false; //죽었을 때 회전 애니메이션 여부

    void Start()
    {
        rd = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        animator = GetComponent<Animator>();  // 애니메이터 컴포넌트 가져오기
    }


    void Update()
    {
        if (!isLive)
        {
            if (isDeadRotating)
            {
                //죽었을 때 아래로 회전
                transform.rotation = Quaternion.Lerp(
                    transform.rotation, Quaternion.Euler(0, 0, -90f),
                    Time.deltaTime * rotateSpeed);
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            rd.linearVelocity = Vector2.up * jumpForce;
        }

        float vy = rd.linearVelocity.y;
        float targetAngle = vy > 0.1f ? 45F : (vy < -0.1f ? -45F : 0F);
        transform.rotation = Quaternion.Lerp(
            transform.rotation, Quaternion.Euler(0, 0, targetAngle),
            Time.deltaTime * rotateSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLive) return;

        // 땅이나 파이프에 부딪히면 게임 오버 처리
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            isLive = false;
            isDeadRotating = true; // 회전 시작
            Debug.Log("Game Over");
            animator.SetBool("Dead", true); // 죽음 애니메이션 실행
            GameManager.Instance.GameOver(); // 게임 매니저에 게임 오버 알림
        }
    }
     
}


