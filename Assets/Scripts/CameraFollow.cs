using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �÷��̾��� Transform�� �Ҵ��� ����

    public float smoothSpeed = 0.125f; // ī�޶� �̵� ������ ������ ������ ����
    public Vector3 offset; // ī�޶�� �÷��̾� ������ �Ÿ��� ������ ����

    private bool isStopped = false; // �÷��̾� �̵� ���� ���θ� �Ǵ��� ����
    public Transform stopZone; // ������ ������ Transform�� �Ҵ��� ����

    //�߰��ؾ� �� ��
    //1. Ư�� ������ ���� ���߱�.
    //2. ī�޶� ������ٵ� �߰�?

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
            // �÷��̾ ��Ÿ���� ������ ��� ���ִ� ������ �߰�
            // ���� ���, ��� Enemy �±׸� ���� ������Ʈ�� ã�Ƽ� ����
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
