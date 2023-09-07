using UnityEngine;

public class Meteo : MonoBehaviour
{
    public float speed = 5f; // 메테오 이동 속도
    [Range(-0.7f, 0.7f)]
    public float minX = 0.01f;
    [Range(-1f, 1f)]
    public float maxY = 1f;
    public float minZ = 0f;
    public float maxZ = 0f;

    private Vector3 direction;

    private void Start()
    {
        // 랜덤한 이동 방향 설정
        direction = new Vector3(Random.Range(minX, 0.7f), Random.Range(-0.01f, maxY), Random.Range(minZ, maxZ)).normalized;
    }

    private void Update()
    {
        // 메테오를 주어진 방향과 속도로 이동
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
