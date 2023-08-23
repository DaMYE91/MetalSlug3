using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    public int ammoType; // �Ѿ� ����
    public int ammoAmount; // �Ѿ� ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AmmoSystem.Instance.CollectAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
