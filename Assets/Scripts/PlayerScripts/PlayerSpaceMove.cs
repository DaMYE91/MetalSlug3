using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 우주선의 움직임 속도
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 플레이어 입력을 받아 우주선을 움직이는 로직을 구현합니다.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        rb.velocity = moveDirection.normalized * moveSpeed;
    }
}
