//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{

//    // �÷��̾� �̵� ���� ����
//    public float movementSpeed = 5f;
//    public float jumpForce = 5f;
//    private bool isJumping = false;
//    private bool isCrouching = false;

//    // ���� ���� ����
//    public int meleeDamage = 1;
//    public float meleeAttackRate = 0.5f;
//    public float meleeAttackRange = 1.0f;
//    private float nextMeleeAttackTime = 0f;

//    // �Ѿ˰� ��ź �߻� ���� ����
//    public Transform firePoint;
//    public GameObject HeavyBulletPrefab;
//    public GameObject ShotBulletPrefab;
//    public GameObject FireBulletPrefab;
//    public GameObject bombPrefab;

//    // �Ѿ˰� ��ź ź�� ���� ����
//    public int maxHeavyMachineGunAmmo = 200;
//    public int maxLaserGunAmmo = 200;
//    public int maxShotGunAmmo = 30;
//    public int maxFireGunAmmo = 30;
//    public int maxRoketGunAmmo = 30;
//    public int maxEnemyChaser = 40;
//    public int maxIronGun = 30;
//    public int maxDropShot = 30;
//    public int maxSuperGrenadeGun = 30;
//    //public int maxBombAmmo = 10; ��ź�� � ������ ������� ������
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

//    // ī�޶��� ������ ������ ����
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
//        // Ű �Է� ����
//        float moveHorizontal = Input.GetAxis("Horizontal");
//        bool isJumpPressed = Input.GetButtonDown("Jump");
//        bool isCrouchPressed = Input.GetKeyDown(KeyCode.S);
//        bool isShootPressed = Input.GetKeyDown(KeyCode.J);
//        bool isThrowPressed = Input.GetKeyDown(KeyCode.K);


//        // �¿� �̵�
//        float targetX = transform.position.x + moveHorizontal * movementSpeed * Time.deltaTime;
//        targetX = Mathf.Clamp(targetX, cameraMinX, cameraMaxX); // �÷��̾� ��ġ�� ī�޶� ���� ������ ����
//        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);


//        // �¿� �̵�
//        transform.Translate(Vector2.right * moveHorizontal * movementSpeed * Time.deltaTime);

//        // �¿� �̵� �ִϸ��̼� ����
//        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

//        // �¿� ���� ����
//        if (moveHorizontal > 0)
//        {
//            transform.localScale = new Vector3(1f, 1f, 1f);
//        }
//        else if (moveHorizontal < 0)
//        {
//            transform.localScale = new Vector3(-1f, 1f, 1f);
//        }

//        // ����
//        if (isJumpPressed && !isJumping)
//        {
//            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//            isJumping = true;
//            animator.SetBool("IsJumping", true);
//        }

//        // ���̱�
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

//        // ���� ����
//        if (Time.time >= nextMeleeAttackTime)
//        {
//            if (isShootPressed)
//            {
//                MeleeAttack(); //��������
//                nextMeleeAttackTime = Time.time + 1f / meleeAttackRate;
//            }
//        }

//        // �Ѿ� �߻�
//        if (isShootPressed)
//        {
//            ShootHeavyBullet();
//        }

//        // ��ź ������
//        if (isThrowPressed)
//        {
//            //ThrowBomb(); ���������� ������
//        }

//        //�߰��ؾ��� �� (���Ϳ� �ִϸ��̼��� �־����)
//        //1. ���� ���¿��� �Ʒ�Ű�� ������ �Ʒ��� ���Ե� -> �� ���¿��� �Ѿ��� �߻��ϸ� �Ʒ��� �� �� ���� ****�⺻ ���¿����� �Ʒ��� ������ ����
//        //2. ���� �����̰ų� ���� ���°� �ƴϾ -> ���� �Ĵٺ��� �Ѿ��� �߻��ϸ� ���� �߻��
//        //3. �⺻ ���¿��� �Ʒ�Ű�� ���� ���·� -> �Ѿ��� �߻��ϸ� ���� ���·� �Ѿ��� �߻���
//        //4. ���� ���¿��� ��ź�� ���� �� ���� + �ѵ� �� �� ����
//        //5. �Ѿ��� �߻��Ҷ� ��ü�� �Ѿ˹߻� + ��ü�� ����

//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        // �ٴڰ��� �浹 ����
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isJumping = false;
//            animator.SetBool("IsJumping", false);
//        }
//    }

//    void PlayerDie() //�÷��̾ �װ� ���� ��Ÿ����
//    {
//        //��Ȳ�� ���� �÷��̾� �״� �ִϸ��̼�
//        //���ӿ��� �� ����
//    }

//    void MeleeAttack()
//    {
//        animator.SetTrigger("MeleeAttack"); // ���� ���� �ִϸ��̼� ���

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

//            //���࿡ ������ ������ �������� �Ĵ� �ϴ� �ִϸ��̼� ����
//        }
//    }

//    //void ThrowBomb() //��ź ������
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
//                // �Ϲ� �Ѿ��� ������
//                break;
//        }
//    }
//}
