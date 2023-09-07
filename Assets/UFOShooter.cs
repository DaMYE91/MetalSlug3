using UnityEngine;

public class UFOShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2.0f; // 발사 속도 (초당 총알 수)
    public float bulletLifetime = 2.0f; // 총알의 수명 (초)

    private float nextFireTime = 0.0f;

    void Update()
    {
        // 일정한 간격으로 총알 발사
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1.0f / fireRate;
        }
    }

    void Shoot()
    {
        // 총알 발사 로직을 여기에 추가
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 총알에 수명 제한을 둡니다.
        Destroy(bullet, bulletLifetime);
    }
}
