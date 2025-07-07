using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float destroyX = -15f;


    void Update()
    {
        if (!GameManager.Instance.bird.isLive)
            return;

        float moveSpeed = FindAnyObjectByType<PipeSpawner>().pipeMoveSpeed;
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if(transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
        
    }
}
