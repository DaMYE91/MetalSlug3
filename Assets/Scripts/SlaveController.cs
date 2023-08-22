using UnityEngine;

public class SlaveController : MonoBehaviour
{
    // ����� �̵� ���� ����
    public float movementSpeed = 2f;
    private bool isMovingRight = true; // ó���� ���������� �̵��ϵ��� ����
    private bool isIdle = false;

    // ���� �ִϸ��̼� ���� ����
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
         //��� �̵�
        if (!isIdle)
        {
            if (isMovingRight)
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
        }
    }

    // �÷��̾ ��� Ǯ���ٶ� ȣ��Ǵ� �Լ�
    public void OnPlayerAttack()
    {
        // ���� �ִϸ��̼����� ��ȯ
        animator.SetBool("IsHostage", true);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = true;
    }

    // �÷��̾ ��� �ع��� �� ȣ��Ǵ� �Լ�
    public void OnPlayerRescue()
    {
        // �Ŵ޷��ִ� �ִϸ��̼����� ��ȯ
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", true);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = true;
    }

    // �������� ���� �Լ�
    public void LeftGo()
    {
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", true);
        animator.SetBool("IsRightJumping", false);
        isMovingRight = false;
        isIdle = false;
    }

    // ���������� ���� �Լ�
    public void RightGo()
    {
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", true);
        //isMovingRight = true;
        isIdle = false;
    }

    // �Ŵ޷��ִ� �ִϸ��̼ǿ��� �¿�� �Դٰ��� �ϴ� �Լ�
    public void HangSwing()
    {
        // �Ŵ޷��ִ� �ִϸ��̼����� ��ȯ
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", true);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = false;
    }

    // ���� �ִϸ��̼ǿ��� �¿�� �Դٰ��� �ϴ� �Լ�
    public void HostageSwing()
    {
        // ���� �ִϸ��̼����� ��ȯ
        animator.SetBool("IsHostage", true);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = false;
    }

    // ���� �ִϸ��̼ǿ��� �������� �پ�� �Լ�
    public void HostageLeftRun()
    {
        animator.SetBool("IsHostage", true);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", true);
        animator.SetBool("IsRightJumping", false);
        isMovingRight = false;
        isIdle = false;
    }

    // �Ŵ޷��ִ� �ִϸ��̼ǿ��� �������� �پ�� �Լ�
    public void HangLeftRun()
    {
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", true);
        animator.SetBool("IsLeftJumping", true);
        animator.SetBool("IsRightJumping", false);
        isMovingRight = false;
        isIdle = false;
    }

    // ��� �Ѿ� �������̳� ��ź�� �÷��̾�� �� �� �ִ� ��� �ִϸ��̼�
    public void DonateToPlayer()
    {

        // ��� �ִϸ��̼� ���� �ڵ� �߰�
    }

    // �÷��̾ ��� Ǯ���� �� ȣ��Ǵ� �Լ�
    public void OnPlayerRelease()
    {
        animator.SetBool("GiveItem", true);
        // �̵� ��ũ��Ʈ�� �ٽ� Ȱ��ȭ
        HangLeftRun(); //�������� �پ��
        isIdle = false;
    }

    public void TakeDamage(int damageAmount)
    {
        
    }
}
