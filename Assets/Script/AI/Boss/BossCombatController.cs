using UnityEngine;

public class BossCombatController : MonoBehaviour
{
    public BossModelController model;
    public Transform player;
    public Collider2D bossCollider;   // gán collider của boss
    public Collider2D playerCollider; // gán collider của player

    public float attackCooldown = 2f;
    public float attackRange = 1f;
    private float lastAttack;

    public void Attack()
    {
        // Tính khoảng cách chính xác dựa trên center của collider
        float dist = Vector2.Distance(
            bossCollider.bounds.center,
            playerCollider.bounds.center
        );
        Debug.Log($"[Combat] Distance to player (corrected): {dist}");

        if (dist < attackRange)
        {
            if (Time.time >= lastAttack + attackCooldown)
            {
                model.Animator.SetTrigger("Attack2");
                Debug.Log("[Combat] Triggered Attack2.");
                lastAttack = Time.time;
            }
            else
            {
                Debug.Log("[Combat] Attack2 on cooldown.");
            }
        }
        else
        {
            if (Time.time >= lastAttack + attackCooldown)
            {
                model.Animator.SetTrigger("Attack");
                Debug.Log("[Combat] Triggered Attack (skill shot).");
                PlaySkill();
                lastAttack = Time.time;
            }
            else
            {
                Debug.Log("[Combat] Attack (skill shot) on cooldown.");
            }
        }
    }

    public void PlaySkill()
    {
        
    }
}
