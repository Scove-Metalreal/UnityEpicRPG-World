using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MusicEvent : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip actionSound;



    private void Awake()
    {
        GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // audioManager.PauseMusic();
            AudioSource.PlayClipAtPoint(actionSound, transform.position);
            Debug.Log("Play action sound");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // audioManager.ResumeMusic();

        }
    }
}
