using UnityEngine;

public class AmmoSystem : MonoBehaviour
{
    private static AmmoSystem instance;

    public static AmmoSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AmmoSystem>();
            }
            return instance;
        }
    }

    public int[] ammoCounts; // 각 탄약 종류별 개수를 저장하는 배열
    public GameObject bulletPrefab; // 발사할 총알 프리팹
    public Transform bulletSpawnPoint; // 총알이 발사되는 위치
    public float bulletSpeed = 10f; // 총알 속도

    private int selectedAmmoType = 0; // 현재 선택된 탄약 종류

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UseAmmo();
        }
    }

    public bool UseAmmo()
    {
        if (ammoCounts[selectedAmmoType] > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.up * bulletSpeed;

            ammoCounts[selectedAmmoType]--;

            // 총알이 카메라 화면 밖에 나가면 삭제
            Destroy(bullet, 2f); // 적절한 시간 설정

            return true;
        }
        return false;
    }

    public void CollectAmmo(int ammoType, int amount)
    {
        ammoCounts[ammoType] += amount;
        // UI 업데이트 및 탄약 수집 관련 작업 수행
    }

    public void ChangeAmmoType(int newAmmoType)
    {
        selectedAmmoType = newAmmoType;
        // UI 업데이트 및 탄약 변경 관련 작업 수행
    }
}
