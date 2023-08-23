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

    public int[] ammoCounts; // �� ź�� ������ ������ �����ϴ� �迭
    public GameObject bulletPrefab; // �߻��� �Ѿ� ������
    public Transform bulletSpawnPoint; // �Ѿ��� �߻�Ǵ� ��ġ
    public float bulletSpeed = 10f; // �Ѿ� �ӵ�

    private int selectedAmmoType = 0; // ���� ���õ� ź�� ����

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

            // �Ѿ��� ī�޶� ȭ�� �ۿ� ������ ����
            Destroy(bullet, 2f); // ������ �ð� ����

            return true;
        }
        return false;
    }

    public void CollectAmmo(int ammoType, int amount)
    {
        ammoCounts[ammoType] += amount;
        // UI ������Ʈ �� ź�� ���� ���� �۾� ����
    }

    public void ChangeAmmoType(int newAmmoType)
    {
        selectedAmmoType = newAmmoType;
        // UI ������Ʈ �� ź�� ���� ���� �۾� ����
    }
}
