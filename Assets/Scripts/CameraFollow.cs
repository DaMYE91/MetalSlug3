using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform을 할당할 변수

    public float smoothSpeed = 0.125f; // 카메라 이동 스무딩 정도를 조절할 변수
    public Vector3 offset; // 카메라와 플레이어 사이의 거리를 조절할 변수

    private bool isStopped = false; // 플레이어 이동 정지 여부를 판단할 변수
    public Transform stopZone; // 정지할 구간의 Transform을 할당할 변수

    //추가해야 할 것
    //1. 특정 구간에 들어서면 멈추기.
    //2. 카메라에 리지드바디를 추가?

    private void LateUpdate()
    {
        if (!isStopped)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == stopZone)
        {
            isStopped = true;
            // 플레이어가 나타나는 적들을 모두 없애는 로직을 추가
            // 예를 들어, 모든 Enemy 태그를 가진 오브젝트를 찾아서 삭제
            // DestroyEnemyObjects();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == stopZone)
        {
            isStopped = false;
        }
    }
}
