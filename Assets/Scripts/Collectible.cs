using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        FindFirstObjectByType<GameManager>().CollectGem();

        Destroy(gameObject);
    }
}
