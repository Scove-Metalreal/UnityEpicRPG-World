using UnityEngine;

public class InteriorScript : MonoBehaviour
{
    private bool isOpen = false;
    public Animator cabinTop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = !isOpen;
            cabinTop.SetBool("isOpen", isOpen);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = !isOpen;
            cabinTop.SetBool("isOpen", isOpen);
        }
    }
}
