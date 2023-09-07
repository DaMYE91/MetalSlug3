using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject[] bulletItemPrefabs = new GameObject[5]; // 다른 총알 아이템 프리팹 배열
    public GameObject[] bulletPrefabs = new GameObject[5]; // 다른 총알 프리팹 배열
    private int[] bulletCounts = new int[6]; // 총알 종류별 보유량 배열
    private int currentBulletType = 0; // 현재 선택된 총알 종류

    public Transform firePoint; // 총알 발사 지점

    private void Start()
    {
        // 기본 총알 프리팹을 초기화
        bulletPrefabs[0] = Resources.Load<GameObject>("BasicBulletPrefab"); // "BasicBulletPrefab"은 실제 프리팹 이름에 맞게 수정

        // 기본 총알은 무제한으로 초기화
        bulletCounts[0] = int.MaxValue;

        // 다른 총알 아이템 초기화
        bulletCounts[1] = 50;
        bulletCounts[2] = 50;
        bulletCounts[3] = 200;
        bulletCounts[4] = 50;
        bulletCounts[5] = 50;
    }

    // 다른 총알 아이템을 획득할 때 호출되는 함수
    public void PickupBullet(int bulletType, int bulletCount)
    {
        bulletCounts[bulletType] += bulletCount;
    }

    // 총알을 발사할 때 호출되는 함수
    public bool ShootBullet()
    {
        if (currentBulletType == 0 || bulletCounts[currentBulletType] == 0)
        {
            // 현재 선택된 총알이 기본 총알이거나 해당 총알의 보유량이 0인 경우
            return false; // 총알 발사 실패
        }

        bulletCounts[currentBulletType]--;
        // 여기에서 총알 프리팹을 사용하여 발사하도록 프리팹을 생성하고 처리합니다.
        GameObject bullet = Instantiate(bulletPrefabs[currentBulletType], firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 1); // 총알을 y축 방향으로 발사 (원하는 속도로 수정)

        return true; // 총알 발사 성공
    }

    // 총알 아이템을 먹으면 호출되는 함수
    public void ChangeToBullet(int newBulletType)
    {
        if (newBulletType != currentBulletType)
        {
            if (bulletCounts[newBulletType] > 0)
            {
                // 해당 종류의 총알 아이템을 가지고 있을 때만 변경 가능
                currentBulletType = newBulletType;
            }
        }
        else
        {
            // 이미 같은 총알 아이템을 먹었으므로 해당 아이템의 총알 갯수만 증가시킴
            bulletCounts[newBulletType]++;
        }
    }
}
