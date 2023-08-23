using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceMove : MonoBehaviour
{
    public float moveSpeed = 5f; // ���ּ��� ������ �ӵ�
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �÷��̾� �Է��� �޾� ���ּ��� �����̴� ������ �����մϴ�.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        rb.velocity = moveDirection.normalized * moveSpeed;
    }
}
