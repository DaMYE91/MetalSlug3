using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefabs; // 메테오 프리팹 배열
    public Transform spawnPoint; // 메테오 생성 위치
    public float minSpawnInterval = 1f; // 최소 생성 간격
    public float maxSpawnInterval = 5f; // 최대 생성 간격

    private float nextSpawnTime;

    private void Start()
    {
        // 초기 생성 시간 설정
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        // 현재 시간이 다음 생성 시간보다 큰 경우 메테오 생성
        if (Time.time >= nextSpawnTime)
        {
            SpawnMeteor();
            // 다음 생성 시간을 랜덤하게 설정
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnMeteor()
    {
        // 랜덤하게 메테오 프리팹 선택
        int randomIndex = Random.Range(0, meteorPrefabs.Length);
        GameObject selectedMeteorPrefab = meteorPrefabs[randomIndex];

        // 메테오 생성
        Instantiate(selectedMeteorPrefab, spawnPoint.position, Quaternion.identity);
    }
}
