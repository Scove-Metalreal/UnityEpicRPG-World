using UnityEngine;

public class CabinScript : MonoBehaviour
{
    private bool isOpen = false;
    public Animator doorAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = !isOpen;
            doorAnim.SetBool("doorOpen", isOpen);
            Debug.Log(isOpen ? "Cabin door opened." : "Cabin door closed.");
        }
    }
}
