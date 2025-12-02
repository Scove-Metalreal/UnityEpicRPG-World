using UnityEngine;

public class TensionZone : MonoBehaviour
{
    public AudioClip tensionClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.FadeToTensionClip(tensionClip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.FadeToBackground();
        }
    }
}
