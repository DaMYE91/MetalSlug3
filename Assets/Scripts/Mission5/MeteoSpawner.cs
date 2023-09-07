using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefabs; // 메테오 프리팹 배열
    public float minSpeed = 2.0f; // 최소 속도
    public float maxSpeed = 5.0f; // 최대 속도
    public Transform[] spawnPoints; // 메테오 생성 위치 배열
    public Transform[] deletePoints; // 메테오 삭제 위치 배열
    public int[] meteorSequence = { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }; // 메테오 생성 순서
    private int currentMeteorIndex = 0; // 현재 생성할 메테오 인덱스

    private Vector3[] moveDirections; // 각 메테오의 이동 방향
    private float[] speeds; // 각 메테오의 이동 속도

    void Start()
    {
        // 초기화
        moveDirections = new Vector3[meteorSequence.Length];
        speeds = new float[meteorSequence.Length];

        // 일정 간격으로 메테오 생성
        InvokeRepeating("SpawnMeteor", 0, 0.3f);
    }

    void SpawnMeteor()
    {
        if (currentMeteorIndex < meteorSequence.Length)
        {
            // 현재 순서에 따라 메테오 프리팹 선택
            int sequence = meteorSequence[currentMeteorIndex];
            GameObject meteorPrefab = (sequence == 0) ? meteorPrefabs[0] : meteorPrefabs[1];

            // 랜덤한 스폰 포인트와 딜리트 포인트 선택
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            int randomDeletePointIndex = Random.Range(0, deletePoints.Length);

            // 메테오 생성
            Vector3 spawnPosition = spawnPoints[randomSpawnPointIndex].position;
            Vector3 deletePosition = deletePoints[randomDeletePointIndex].position;

            speeds[currentMeteorIndex] = Random.Range(minSpeed, maxSpeed);
            moveDirections[currentMeteorIndex] = (deletePosition - spawnPosition).normalized;

            GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

            // 다음 메테오 인덱스로 이동
            currentMeteorIndex++;
        }
        else
        {
            // 생성할 메테오가 없으면 중지
            CancelInvoke("SpawnMeteor");
        }
    }

    void Update()
    {
        // 메테오 이동
        for (int i = 0; i < currentMeteorIndex; i++)
        {
            transform.position += moveDirections[i] * speeds[i] * Time.deltaTime;
        }
    }
}
