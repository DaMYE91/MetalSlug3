using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBullet : MonoBehaviour
{
    public enum SpaceBulletType
    {
        Laser,
        Shot,
        Roket,
        Heavy,
        Normal,
        chaser,
    }

    public SpaceBulletType bulletType;
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
        // ������ ���� �� �Ѿ��� ���� // ������ ������ �Ѿ��� ����
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
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


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;

        if (pos.x > 1f) pos.x = 1f;

        if (pos.y < 0f) pos.y = 0f;

        if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
