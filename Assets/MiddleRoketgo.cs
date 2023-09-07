using UnityEngine;

public class MiddleRoketgo : MonoBehaviour
{
    private Vector2 currentPosition;
    private float moveSpeedX = 0.4f; // 오른쪽으로 이동하는 힘 (작게 설정)
    private float moveSpeedY = 1f; // 위로 올라가는 힘 (크게 설정)

    private void Start()
    {
        // 초기 위치 설정
        currentPosition = transform.position; // 현재 오브젝트의 위치로 설정
    }

    private void Update()
    {
        // 오른쪽으로 이동
        currentPosition.x += moveSpeedX * Time.deltaTime;

        // 위로 올라가기
        currentPosition.y += moveSpeedY * Time.deltaTime;

        // 현재 위치 출력 (디버깅용)
        Debug.Log($"현재 위치: x={currentPosition.x}, y={currentPosition.y}");

        // 원하는 위치에 도달하면 작업을 중지 (예: 오른쪽 위 꼭짓점)
        if (currentPosition.x >= 3.0f && currentPosition.y >= 5.0f)
        {
            Debug.Log("목표 위치에 도달했습니다.");
            enabled = false; // Update 함수를 더 이상 호출하지 않도록 중지
        }

        // 현재 위치를 오브젝트의 실제 위치로 설정
        transform.position = currentPosition;
    }
}
