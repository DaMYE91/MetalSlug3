using UnityEngine;

public class PlayerGunSpace : MonoBehaviour
{
    public GameObject[] bulletPrefabs; // 5개의 총알 프리팹
    private int currentBulletType = 0; // 현재 총알 종류

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
        // 현재 총알 종류에 맞는 프리팹을 사용하여 총알 발사 로직을 구현하세요.
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
