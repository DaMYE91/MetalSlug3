using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _target;

    //�Ѹ°�
    // �װ�
    // ������ �����۶�����
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // �� ĳ���Ͱ� ���� ���� ó���� �����մϴ�. ���� ���, �ִϸ��̼� ��� �� ���� ���� �� �� �ֽ��ϴ�.
        Destroy(gameObject);
    }


    //�ڱ� ȥ�� ���ƴٴϴٰ� or ������ �ִϸ��̼��� �����߿�  �÷��̾ Ư�� �Ÿ� ������ ���� �Ѿƿ��� �� �����ϱ�
    

    void Update()
    {
        
    }
}


public class Tank : EnemyController
{
    private void Update()
    {
        // ���� �ִϸ��̼��������Ѵ�.
        // ��ũ �̵�
        // ������ �߻�(������
    }
}
public class Shooter : EnemyController
{
    private void Update()
    {
        //���� ���� 3
        //�⺻ ���� => ��Ÿ� - ��ź ������ // �ܰŸ� - �ܰ�
        //����� ���� => ��Ÿ�, �ܰŸ� - �Ѿ˹߻�

    }
}

public class ManZombie : EnemyController 
{
    private void Update()
    {
        
    }
}

public class WomanZombie : EnemyController 
{
    private void Update()
    {
        
    }
}

public class DoctorZombie : EnemyController
{
    private void Update()
    {
        
    }
}

public class SoldierZombie : EnemyController
{
    private void Update()
    {
        
    }
}

public class MisterZombie : EnemyController
{
    private void Update()
    {
        
    }
}

public class NomalZombie : EnemyController
{
    private void Update()
    {
        
    }
}
public class FaceZombie : EnemyController
{
    private void Update()
    {
        
    }
}

public class GroupHelicopter : EnemyController
{
    private void Update()
    {
        
    }
}
public class Helicopter : EnemyController
{
    private void Update()
    {

    }
}

