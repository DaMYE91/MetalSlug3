using UnityEngine;

public class DiagonalMeteor : MonoBehaviour
{
    public float speed = 5f; // 메테오 이동 속도
    public Vector3 direction = new Vector3(1f, -1f, 0f); // 이동 방향 (대각선 아래로)

    private void Update()
    {
        // 메테오를 주어진 방향과 속도로 이동
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
