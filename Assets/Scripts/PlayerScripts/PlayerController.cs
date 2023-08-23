//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{

//    // 플레이어 이동 관련 변수
//    public float movementSpeed = 5f;
//    public float jumpForce = 5f;
//    private bool isJumping = false;
//    private bool isCrouching = false;

//    // 공격 관련 변수
//    public int meleeDamage = 1;
//    public float meleeAttackRate = 0.5f;
//    public float meleeAttackRange = 1.0f;
//    private float nextMeleeAttackTime = 0f;

//    // 총알과 폭탄 발사 관련 변수
//    public Transform firePoint;
//    public GameObject HeavyBulletPrefab;
//    public GameObject ShotBulletPrefab;
//    public GameObject FireBulletPrefab;
//    public GameObject bombPrefab;

//    // 총알과 폭탄 탄약 관련 변수
//    public int maxHeavyMachineGunAmmo = 200;
//    public int maxLaserGunAmmo = 200;
//    public int maxShotGunAmmo = 30;
//    public int maxFireGunAmmo = 30;
//    public int maxRoketGunAmmo = 30;
//    public int maxEnemyChaser = 40;
//    public int maxIronGun = 30;
//    public int maxDropShot = 30;
//    public int maxSuperGrenadeGun = 30;
//    //public int maxBombAmmo = 10; 폭탄을 어떤 식으로 등록할지 고민중
//    private int currentHeavyMachineGunAmmo;
//    private int currentLaserGunAmmo;
//    private int currentShotGunAmmo;
//    private int currentFireGunAmmo;
//    private int currentRoketGunAmmo;
//    private int currentEnemyChaser;
//    private int currentIronGun;
//    private int currentDropShot;
//    private int currentSuperGun;
//    //private int currentBombAmmo; //////

//    // 카메라의 범위를 정의할 변수
//    public float cameraMinX;
//    public float cameraMaxX;

//    private Animator animator;

//    void Start()
//    {
//        currentHeavyMachineGunAmmo = maxHeavyMachineGunAmmo;
//        currentLaserGunAmmo = maxLaserGunAmmo;
//        currentShotGunAmmo = maxShotGunAmmo;
//        currentFireGunAmmo = maxFireGunAmmo;
//        currentRoketGunAmmo = maxRoketGunAmmo;
        
//        animator = GetComponent<Animator>();

//    }

//    void Update()
//    {
//        // 키 입력 감지
//        float moveHorizontal = Input.GetAxis("Horizontal");
//        bool isJumpPressed = Input.GetButtonDown("Jump");
//        bool isCrouchPressed = Input.GetKeyDown(KeyCode.S);
//        bool isShootPressed = Input.GetKeyDown(KeyCode.J);
//        bool isThrowPressed = Input.GetKeyDown(KeyCode.K);


//        // 좌우 이동
//        float targetX = transform.position.x + moveHorizontal * movementSpeed * Time.deltaTime;
//        targetX = Mathf.Clamp(targetX, cameraMinX, cameraMaxX); // 플레이어 위치를 카메라 범위 내에서 제한
//        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);


//        // 좌우 이동
//        transform.Translate(Vector2.right * moveHorizontal * movementSpeed * Time.deltaTime);

//        // 좌우 이동 애니메이션 설정
//        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

//        // 좌우 방향 설정
//        if (moveHorizontal > 0)
//        {
//            transform.localScale = new Vector3(1f, 1f, 1f);
//        }
//        else if (moveHorizontal < 0)
//        {
//            transform.localScale = new Vector3(-1f, 1f, 1f);
//        }

//        // 점프
//        if (isJumpPressed && !isJumping)
//        {
//            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//            isJumping = true;
//            animator.SetBool("IsJumping", true);
//        }

//        // 숙이기
//        if (isCrouchPressed)
//        {
//            isCrouching = true;
//            animator.SetBool("IsCrouching", true);
//        }
//        else
//        {
//            isCrouching = false;
//            animator.SetBool("IsCrouching", false);
//        }

//        // 근접 공격
//        if (Time.time >= nextMeleeAttackTime)
//        {
//            if (isShootPressed)
//            {
//                MeleeAttack(); //근접공격
//                nextMeleeAttackTime = Time.time + 1f / meleeAttackRate;
//            }
//        }

//        // 총알 발사
//        if (isShootPressed)
//        {
//            ShootHeavyBullet();
//        }

//        // 폭탄 던지기
//        if (isThrowPressed)
//        {
//            //ThrowBomb(); 포물선으로 던지기
//        }

//        //추가해야할 것 (모든것에 애니메이션을 넣어야함)
//        //1. 점프 상태에서 아래키를 누르면 아래를 보게됨 -> 그 상태에서 총알을 발사하면 아래를 쏠 수 있음 ****기본 상태에서는 아래로 쏴지지 않음
//        //2. 점프 상태이거나 점프 상태가 아니어도 -> 위를 쳐다보고 총알을 발사하면 위로 발사됨
//        //3. 기본 상태에서 아래키를 누른 상태로 -> 총알을 발사하면 숙인 상태로 총알을 발사함
//        //4. 점프 상태에서 폭탄을 던질 수 있음 + 총도 쏠 수 있음
//        //5. 총알을 발사할때 상체는 총알발사 + 하체는 점프

//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        // 바닥과의 충돌 감지
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isJumping = false;
//            animator.SetBool("IsJumping", false);
//        }
//    }

//    void PlayerDie() //플레이어가 죽고 나서 나타나는
//    {
//        //상황에 따른 플레이어 죽는 애니메이션
//        //게임오버 씬 변경
//    }

//    void MeleeAttack()
//    {
//        animator.SetTrigger("MeleeAttack"); // 근접 공격 애니메이션 재생

//        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeAttackRange);
//        foreach (Collider2D collider in hitEnemies)
//        {
//            if (collider.CompareTag("Enemy"))
//            {
//                NomalZombie enemy = collider.GetComponent<NomalZombie>();
//                if (enemy != null)
//                {
//                    enemy.TakeDamage(meleeDamage);
//                }
//            }
//            else if (collider.CompareTag("Slave"))
//            {
//                SlaveController slave = collider.GetComponent<SlaveController>();
//                if (slave != null)
//                {
//                    slave.TakeDamage(meleeDamage);
//                }
//            }
//        }
//    }

//    void ShootHeavyBullet()
//    {
//        if (currentHeavyMachineGunAmmo > 0)
//        {
//            Instantiate(HeavyBulletPrefab, firePoint.position, firePoint.rotation);
//            currentHeavyMachineGunAmmo--;

//            //만약에 적에게 닿으면 닿은곳에 파닷 하는 애니메이션 실행
//        }
//    }

//    //void ThrowBomb() //폭탄 던지기
//    //{
//    //    if (currentBombAmmo > 0)
//    //    {
//    //        Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
//    //        currentBombAmmo--;
//    //    }
//    //}

//    public void AddAmmo(AmmoItem.BulletType bulletType, int amount)
//    {
//        switch (bulletType)
//        {
//            case AmmoItem.BulletType.HeavyMachineGun:
//                currentHeavyMachineGunAmmo += amount;
//                currentHeavyMachineGunAmmo = Mathf.Clamp(currentHeavyMachineGunAmmo, 0, maxHeavyMachineGunAmmo);
//                break;
//            case AmmoItem.BulletType.LaserGun:
//                currentLaserGunAmmo += amount;
//                currentLaserGunAmmo = Mathf.Clamp(currentLaserGunAmmo, 0, maxLaserGunAmmo);
//                break;
//            case AmmoItem.BulletType.ShotGun:
//                currentShotGunAmmo += amount;
//                currentShotGunAmmo = Mathf.Clamp(currentShotGunAmmo, 0, maxShotGunAmmo);
//                break;
//            case AmmoItem.BulletType.FireGun:
//                currentFireGunAmmo += amount;
//                currentFireGunAmmo = Mathf.Clamp(currentFireGunAmmo, 0, maxFireGunAmmo);
//                break;
//            case AmmoItem.BulletType.RoketGun:
//                currentRoketGunAmmo += amount;
//                currentRoketGunAmmo = Mathf.Clamp(currentRoketGunAmmo, 0, maxRoketGunAmmo);
//                break;
//            case AmmoItem.BulletType.HandGun:
//                // 일반 총알은 무제한
//                break;
//        }
//    }
//}
