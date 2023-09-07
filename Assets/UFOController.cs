using UnityEngine;
using System.Collections;


public class UFOController : MonoBehaviour
{
    public float moveDistance = 0.3f; // 이동 거리
    public float moveSpeed = 2.0f; // 이동 속도
    public float attackDelay = 0.3f; // 공격 딜레이 (총알을 발사한 후 대기 시간)
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 총알 발사 위치

    private bool isMovingRight = true;
    private bool isAttacking = false;
    private float attackTimer = 0.0f;

    public float minX = -5.0f; // UFO가 이동할 최소 X 위치
    public float maxX = 5.0f; // UFO가 이동할 최소 X 위치


    void Update()
    {
        if (!isAttacking)
        {
            // UFO를 좌우로 이동
            float moveDirection = isMovingRight ? 1.0f : -1.0f;
            transform.Translate(Vector3.right * moveDirection * moveDistance * Time.deltaTime);

            // UFO가 최대 또는 최소 X 위치에 도달하면 방향을 바꿈
            if (transform.position.x >= maxX || transform.position.x <= minX)
            {
                isMovingRight = !isMovingRight;
            }

            // 이동 후 공격 시작
            StartCoroutine(Attack());
        }
        else
        {
            // 공격 중인 경우 타이머를 업데이트
            attackTimer += Time.deltaTime;

            // 타이머가 attackDelay보다 크면 공격이 끝난 것으로 처리
            if (attackTimer >= attackDelay)
            {
                isAttacking = false;
                attackTimer = 0.0f;
            }
        }
    }

    IEnumerator Attack()
    {
        // 공격 상태로 전환하고 총알 발사
        isAttacking = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 공격 딜레이 후에 이동 상태로 전환
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
}
