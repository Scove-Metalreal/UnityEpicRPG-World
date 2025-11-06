using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Collider2D))]
public class MeleeHitBox : MonoBehaviour
{
    [Header("Hitbox Settings")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform attackPoint;

    private bool active = false;

    public void EnableHitBox()
    {
        active = true;
        DealDamage();
    }

    public void DisableHitBox() => active = false;

    private void DealDamage()
    {
        if (!active) return;

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            playerLayer
        );

        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log($"Player Hit for {damage} damage by {gameObject.name}");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
