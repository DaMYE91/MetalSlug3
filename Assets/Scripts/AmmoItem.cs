using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    public int ammoType; // ÃÑ¾Ë Á¾·ù
    public int ammoAmount; // ÃÑ¾Ë ¾ç

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AmmoSystem.Instance.CollectAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
