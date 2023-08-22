using System.Collections;
using UnityEngine;

public class HeavyMachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;     // 총알 프리팹
    public Transform firePoint;        // 총알 발사 위치

    public float fireRate = 0.1f;      // 총알 발사 간격 (초 단위)
    private float nextFireTime = 0f;   // 다음 총알 발사 시간

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼이나 스페이스바 키로 총알 발사
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // 다음 총알 발사 가능 시간 이후에만 총알을 발사
        if (Time.time >= nextFireTime)
        {
            // 총알 발사 지점과 방향 설정
            Vector3 bulletSpawnPosition = firePoint.position;
            Quaternion bulletSpawnRotation = firePoint.rotation;

            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, bulletSpawnRotation);

            // 총알을 일정 시간 후에 파괴 (설정한 시간이 짧아야 발사 속도가 빨라짐)
            Destroy(bullet, 2f);

            // 다음 총알 발사 가능 시간 업데이트
            nextFireTime = Time.time + fireRate;
        }
    }
}