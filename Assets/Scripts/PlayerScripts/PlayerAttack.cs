using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private static PlayerAttack instance;

    public static PlayerAttack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerAttack>();
            }
            return instance;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        AmmoSystem.Instance.UseAmmo();
    }
}
