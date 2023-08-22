using System.Collections;
using UnityEngine;

public class HeavyMachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;     // �Ѿ� ������
    public Transform firePoint;        // �Ѿ� �߻� ��ġ

    public float fireRate = 0.1f;      // �Ѿ� �߻� ���� (�� ����)
    private float nextFireTime = 0f;   // ���� �Ѿ� �߻� �ð�

    // Update is called once per frame
    void Update()
    {
        // ���콺 ���� ��ư�̳� �����̽��� Ű�� �Ѿ� �߻�
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // ���� �Ѿ� �߻� ���� �ð� ���Ŀ��� �Ѿ��� �߻�
        if (Time.time >= nextFireTime)
        {
            // �Ѿ� �߻� ������ ���� ����
            Vector3 bulletSpawnPosition = firePoint.position;
            Quaternion bulletSpawnRotation = firePoint.rotation;

            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);

            // �Ѿ��� ���� �ð� �Ŀ� �ı� (������ �ð��� ª�ƾ� �߻� �ӵ��� ������)
            Destroy(bullet, 2f);

            // ���� �Ѿ� �߻� ���� �ð� ������Ʈ
            nextFireTime = Time.time + fireRate;
        }
    }
}