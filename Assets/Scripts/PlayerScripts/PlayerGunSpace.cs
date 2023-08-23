using UnityEngine;

public class PlayerGunSpace : MonoBehaviour
{
    public GameObject[] bulletPrefabs; // 5���� �Ѿ� ������
    private int currentBulletType = 0; // ���� �Ѿ� ����

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
        }
    }

    public void ChangeBulletType(int newType)
    {
        if (newType >= 0 && newType < bulletPrefabs.Length)
        {
            currentBulletType = newType;
        }
    }

    public void Fire()
    {
        GameObject bulletPrefab = bulletPrefabs[currentBulletType];
        // ���� �Ѿ� ������ �´� �������� ����Ͽ� �Ѿ� �߻� ������ �����ϼ���.
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
