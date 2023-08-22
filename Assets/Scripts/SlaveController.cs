using UnityEngine;

public class SlaveController : MonoBehaviour
{
    // 노비의 이동 관련 변수
    public float movementSpeed = 2f;
    private bool isMovingRight = true; // 처음에 오른쪽으로 이동하도록 설정
    private bool isIdle = false;

    // 인질 애니메이션 관련 변수
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
         //노비 이동
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

    // 플레이어가 노비를 풀어줄때 호출되는 함수
    public void OnPlayerAttack()
    {
        // 인질 애니메이션으로 전환
        animator.SetBool("IsHostage", true);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = true;
    }

    // 플레이어가 노비를 해방할 때 호출되는 함수
    public void OnPlayerRescue()
    {
        // 매달려있는 애니메이션으로 전환
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", true);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = true;
    }

    // 왼쪽으로 가는 함수
    public void LeftGo()
    {
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", true);
        animator.SetBool("IsRightJumping", false);
        isMovingRight = false;
        isIdle = false;
    }

    // 오른쪽으로 가는 함수
    public void RightGo()
    {
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", true);
        //isMovingRight = true;
        isIdle = false;
    }

    // 매달려있는 애니메이션에서 좌우로 왔다갔다 하는 함수
    public void HangSwing()
    {
        // 매달려있는 애니메이션으로 전환
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", true);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = false;
    }

    // 인질 애니메이션에서 좌우로 왔다갔다 하는 함수
    public void HostageSwing()
    {
        // 인질 애니메이션으로 전환
        animator.SetBool("IsHostage", true);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", false);
        animator.SetBool("IsRightJumping", false);
        isIdle = false;
    }

    // 인질 애니메이션에서 좌측으로 뛰어가는 함수
    public void HostageLeftRun()
    {
        animator.SetBool("IsHostage", true);
        animator.SetBool("IsHanging", false);
        animator.SetBool("IsLeftJumping", true);
        animator.SetBool("IsRightJumping", false);
        isMovingRight = false;
        isIdle = false;
    }

    // 매달려있는 애니메이션에서 좌측으로 뛰어가는 함수
    public void HangLeftRun()
    {
        animator.SetBool("IsHostage", false);
        animator.SetBool("IsHanging", true);
        animator.SetBool("IsLeftJumping", true);
        animator.SetBool("IsRightJumping", false);
        isMovingRight = false;
        isIdle = false;
    }

    // 노비가 총알 아이템이나 폭탄을 플레이어에게 줄 수 있는 기부 애니메이션
    public void DonateToPlayer()
    {

        // 기부 애니메이션 실행 코드 추가
    }

    // 플레이어가 노비를 풀어준 후 호출되는 함수
    public void OnPlayerRelease()
    {
        animator.SetBool("GiveItem", true);
        // 이동 스크립트를 다시 활성화
        HangLeftRun(); //좌측으로 뛰어가는
        isIdle = false;
    }

    public void TakeDamage(int damageAmount)
    {
        
    }
}
