using UnityEngine;

public class MeteoAndAsteroidSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefabs; // 메테오 프리팹 배열
    public GameObject[] asteroidPrefabs; // 소행성 프리팹 배열
    public Transform[] spawnPoints; // 오브젝트 생성 위치 배열
    public float minMeteorSpeed = 2.0f; // 메테오 최소 속도
    public float maxMeteorSpeed = 5.0f; // 메테오 최대 속도
    public float minAsteroidSpeed = 1.0f; // 소행성 최소 속도
    public float maxAsteroidSpeed = 3.0f; // 소행성 최대 속도
    public float timeToDestroy = 2.0f; // 메테오 및 소행성 삭제 시간 (초)
    public int[] meteorSequence = { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }; // 메테오 생성 순서
    private int currentMeteorIndex = 0; // 현재 생성할 메테오 인덱스

    public float minMeteorSpawnInterval = 0.3f; // 메테오 최소 생성 간격
    public float maxMeteorSpawnInterval = 1.0f; // 메테오 최대 생성 간격
    public float minAsteroidSpawnInterval = 0.5f; // 소행성 최소 생성 간격
    public float maxAsteroidSpawnInterval = 2.0f; // 소행성 최대 생성 간격

    private bool spawningEnabled = true; // 소행성 생성 허용 여부

    private void Start()
    {
        // 일정 간격으로 메테오 및 소행성 생성
        InvokeRepeating("SpawnObject", 0, Random.Range(minMeteorSpawnInterval, maxMeteorSpawnInterval));
        InvokeRepeating("SpawnAsteroid", 0, Random.Range(minAsteroidSpawnInterval, maxAsteroidSpawnInterval));
    }

    private void SpawnObject()
    {
        if (currentMeteorIndex < meteorSequence.Length)
        {
            // 현재 순서에 따라 메테오 또는 소행성 프리팹 선택
            int sequence = meteorSequence[currentMeteorIndex];
            GameObject objectPrefab = (sequence == 0) ? meteorPrefabs[Random.Range(0, meteorPrefabs.Length)] : asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

            // 랜덤한 스폰 포인트 선택
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

            // 오브젝트 생성
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);

            // 초기 속도 설정
            float speed = 0;
            if (sequence == 0) // 메테오인 경우
            {
                speed = Random.Range(minMeteorSpeed, maxMeteorSpeed);
            }
            else // 소행성인 경우
            {
                speed = Random.Range(minAsteroidSpeed, maxAsteroidSpeed);
            }

            Vector2 direction = -spawnPoint.position.normalized;

            // 리지드바디 2D 컴포넌트 추가
            Rigidbody2D rb2D = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb2D == null)
            {
                rb2D = spawnedObject.AddComponent<Rigidbody2D>();
            }

            // 리지드바디 설정
            rb2D.velocity = direction * speed;
            rb2D.gravityScale = 0; // 중력 영향 제거

            // 오브젝트 삭제 예약
            Destroy(spawnedObject, timeToDestroy);

            // 다음 메테오 인덱스로 이동
            currentMeteorIndex++;
        }
        else if (spawningEnabled)
        {
            // 생성할 메테오가 없고 소행성 생성이 허용된 경우 중지
            spawningEnabled = false;
            CancelInvoke("SpawnObject");
        }
    }

    private void SpawnAsteroid()
    {
        // 랜덤한 스폰 포인트 선택
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

        // 소행성 생성 위치 설정
        Vector2 asteroidSpawnPosition = new Vector2(Random.Range(-6f, 6f), 6f);

        // 소행성 생성
        GameObject spawnedAsteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], asteroidSpawnPosition, Quaternion.identity);

        // 초기 속도 설정
        float speed = Random.Range(minAsteroidSpeed, maxAsteroidSpeed);
        Vector2 direction = new Vector2(Random.Range(-6f, 6f), -6f); // x축 -6 ~ 6, y축 -6으로 랜덤 이동

        // 리지드바디 2D 컴포넌트 추가
        Rigidbody2D rb2D = spawnedAsteroid.GetComponent<Rigidbody2D>();
        if (rb2D == null)
        {
            rb2D = spawnedAsteroid.AddComponent<Rigidbody2D>();
        }
        // 리지드바디 설정
        rb2D.velocity = direction.normalized * speed;
        rb2D.gravityScale = 0; // 중력 영향 제거

        // 소행성 삭제 예약
        Destroy(spawnedAsteroid, timeToDestroy);
    }
}


       
