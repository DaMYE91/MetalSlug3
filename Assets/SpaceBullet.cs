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
    public int maxAmmo = 0; // 총알의 최대 수
    public int currentAmmo = 0; // 현재 총알 수

    public float speed = 10f; // 총알 이동 속도
    public int damage = 1; // 총알의 공격력
    public float lifetime = 3f; // 총알의 수명 (초)

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // 수명이 지난 후 총알을 삭제 // 적에게 닿으면 총알을 삭제
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //충돌한 대상에게 데미지를 입히기
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            //총알 삭제
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
