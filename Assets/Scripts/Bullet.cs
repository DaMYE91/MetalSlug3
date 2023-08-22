using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType
    {
        HeavyMachineGun,
        LaserGun,
        ShotGun,
        FireGun,
        RoketGun,
        HandGun,
        DropShotGun,
        IronGun,
        EnemyChaser,
        SuperGrenadeGun,
    }

    public BulletType bulletType;
    public int maxAmmo = 0; // �Ѿ��� �ִ� ��
    public int currentAmmo = 0; // ���� �Ѿ� ��

    public float speed = 10f; // �Ѿ� �̵� �ӵ�
    public int damage = 1; // �Ѿ��� ���ݷ�
    public float lifetime = 3f; // �Ѿ��� ���� (��)

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // ������ ���� �� �Ѿ��� �����մϴ�. // ������ ������ �Ѿ��� ����
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        // �Ѿ��� �̵���ŵ�ϴ�.
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //�浹�� ��󿡰� �������� ������
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            //�Ѿ� ����
            Destroy(gameObject);
        }
    }

    public void SetMaxAmmo(int maxAmmo)
    {
        this.maxAmmo = maxAmmo;
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
    }

    public void ResetAmmo()
    {
        currentAmmo = maxAmmo;
    }
}
