using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("파이프 생성 설정")]
    public GameObject pipePairPrefab; // 파이프 프리팹
    public float spawnInterval = 2f; // 파이프 생성 간격
    public float xSpawnPosition = 10f; // 파이프 이동 속도

    [Header("파이프 갭 설정")]
    public float minGapHeight = 2f; // 최소 갭 높이
    public float maxGapHeight = 4f; // 최대 갭 높이

    [Header("속도 증가 설정")]
    public float pipeMoveSpeed = 2f; // 파이프 이동 속도
    public float speedUpInterval = 5f; // 속도 증가 간격
    public float speedUpAmount = 1.5f; // 속도 증가량
    public float maxSpeed = 8f;

    [Header("생성 간격 설정")]
    public float minSpawnInterval = 0.8f; // 최소 생성 간격
    public float lastSpeedUpTime = 0f; // 최대 생성 간격


    void Start()
    {

    }


    void Update()
    {
        if (Time.time - lastSpeedUpTime > speedUpInterval && pipeMoveSpeed < maxSpeed)
        {
            pipeMoveSpeed = Mathf.Min(pipeMoveSpeed + speedUpAmount, maxSpeed);
            lastSpeedUpTime = Time.time;

            spawnInterval = Mathf.Max(spawnInterval * 0.9f, minSpawnInterval);

            CancelInvoke(nameof(SpawnPipes));
            InvokeRepeating(nameof(SpawnPipes), spawnInterval, spawnInterval);
        }
    }

    void SpawnPipes()
    {
        float gap = Random.Range(minGapHeight, maxGapHeight);
        float helfGap = gap / 2f;

        float camHalfHeight = Camera.main.orthographicSize;

        Transform pipeSprite = pipePairPrefab.transform.Find("PipeTop");
        float pipeHalfHeight = 0f;
        if (pipeSprite != null && pipeSprite.GetComponent<SpriteRenderer>() != null)
            pipeHalfHeight = pipeSprite.GetComponent<SpriteRenderer>().bounds.size.y / 2f;

        float maxCenterY = camHalfHeight - helfGap - pipeHalfHeight;
        float minCenterY = -camHalfHeight + helfGap + pipeHalfHeight;
        float centerY = Random.Range(minCenterY, maxCenterY);
        Debug.Log($"파이프 중앙 y 위치: {centerY}");

        GameObject pipePair = Instantiate(pipePairPrefab, new Vector3(xSpawnPosition, 0f, 0f), Quaternion.identity);

        Transform PipeTop = pipePair.transform.Find("PipeTop");
        Transform PipeBottom = pipePair.transform.Find("PipeBottom");
        if (PipeTop != null && PipeBottom != null)
        {
            PipeTop.position = new Vector3(0, centerY + helfGap, 0f);
            PipeBottom.position = new Vector3(0, centerY - helfGap, 0f);
        }
    }
}
