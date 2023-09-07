using UnityEngine;

public class MeteoSpawner01 : MonoBehaviour
{
    public GameObject[] meteorPrefabs; // 메테오 프리팹 배열
    public Transform[] spawnPoints; // 메테오 생성 위치 배열
    public float minSpeed = 2.0f; // 최소 속도
    public float maxSpeed = 5.0f; // 최대 속도
    public float timeToDestroy = 2.0f; // 메테오 삭제 시간 (초)
    public int[] meteorSequence = { 0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2, }; // 메테오 생성 순서

    private int currentMeteorIndex = 0; // 현재 생성할 메테오 인덱스

    //Start MeteoSpawner00.cs23
    //public float minSpawnInterval = 0.3f; // 최소 생성 간격
    //public float maxSpawnInterval = 1.0f; // 최대 생성 간격

    private void Start()
    {
        // 일정 간격으로 메테오 생성
        InvokeRepeating("SpawnMeteor", 0, .5f);
        // 랜덤한 간격으로 메테오 생성 예약
        //Invoke("SpawnMeteor", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
    

    private void SpawnMeteor()
    {
        if (currentMeteorIndex < meteorSequence.Length)
        {
            // 현재 순서에 따라 메테오 프리팹 선택
            int sequence = meteorSequence[currentMeteorIndex];
            GameObject meteorPrefab = meteorPrefabs[sequence];

            // 랜덤한 스폰 포인트 선택
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

            // 메테오 생성
            GameObject meteor = Instantiate(meteorPrefab, spawnPoint.position, Quaternion.identity);



            //--------------------------------------------
            // 메테오 초기 속도 설정
            float speed = Random.Range(minSpeed, maxSpeed);
            Vector2 direction = -spawnPoint.position.normalized; // 방향은 스폰 포인트에서 원점으로 향하도록 설정
            //Vector2 direction = (Vector2)(spawnPoint.position - transform.position).normalized;
            //Vector2 direction = -Vector2.up; // 아래 방향으로 이동
            //--------------------------------------------



            // 메테오에 리지드바디 2D 컴포넌트 추가
            Rigidbody2D rb2D = meteor.GetComponent<Rigidbody2D>();
            if (rb2D == null)
            {
                rb2D = meteor.AddComponent<Rigidbody2D>();
            }

            // 리지드바디 설정
            rb2D.velocity = direction * speed;
            rb2D.gravityScale = 0; // 중력 영향 제거

            // 메테오 삭제 예약
            Destroy(meteor, timeToDestroy);

            // 다음 메테오 인덱스로 이동
            currentMeteorIndex++;
        }
        else
        {
            // 생성할 메테오가 없으면 중지
            CancelInvoke("SpawnMeteor");
        }
    }
}
