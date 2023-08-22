using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    public enum BulletType
    {
        HeavyMachineGun,
        LaserGun,
        ShotGun,
        FireGun,
        RoketGun,
        HandGun,
        DropShotGun,
        IronGun,
        EnemyChaser,
        SuperGrenadeGun,
    }

    public BulletType bulletType;
    public int additionalAmmo = 0; // Ãß°¡·Î È¹µæÇÒ ÃÑ¾Ë ¼ö

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                switch (bulletType)
                {
                    case BulletType.HeavyMachineGun:
                        player.AddAmmo(BulletType.HeavyMachineGun, additionalAmmo);
                        break;
                    case BulletType.LaserGun:
                        player.AddAmmo(BulletType.LaserGun, additionalAmmo);
                        break;
                    case BulletType.ShotGun:
                        player.AddAmmo(BulletType.ShotGun, additionalAmmo);
                        break;
                    case BulletType.HandGun:
                        player.AddAmmo(BulletType.HandGun, additionalAmmo);
                        break;
                    case BulletType.FireGun:
                        player.AddAmmo(BulletType.FireGun, additionalAmmo);
                        break;
                    case BulletType.RoketGun:
                        player.AddAmmo(BulletType.RoketGun, additionalAmmo);
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}
