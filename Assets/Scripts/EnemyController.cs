using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _target;

    //총맞고
    // 죽고
    // 죽을때 아이템떨구고
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
        // 적 캐릭터가 죽을 때의 처리를 구현합니다. 예를 들어, 애니메이션 재생 및 삭제 등을 할 수 있습니다.
        Destroy(gameObject);
    }


    //자기 혼자 돌아다니다가 or 가만히 애니메이션을 실행중에  플레이어가 특정 거리 가까이 가면 쫓아오기 와 공격하기
    

    void Update()
    {
        
    }
}


public class Tank : EnemyController
{
    private void Update()
    {
        // 대포 애니메이션을실행한다.
        // 탱크 이동
        // 대포알 발사(포물선
    }
}
public class Shooter : EnemyController
{
    private void Update()
    {
        //슈터 종류 3
        //기본 슈터 => 장거리 - 폭탄 던지기 // 단거리 - 단검
        //기관총 슈터 => 장거리, 단거리 - 총알발사

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

