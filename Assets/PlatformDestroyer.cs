using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
