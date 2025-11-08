using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpearmanEnemy : AbstractEnemy
{
    [Header("Combat Settings")]
    [SerializeField] private MeleeHitBox meleeHitbox;
    [SerializeField] private float attackCooldown = 1.2f;
    [SerializeField] private float skillCooldown = 6f;

    public Collider2D spinHitBox;
    private Transform player;
    private float lastAttackTime = -999f;
    private float lastSkillTime = -999f;
    private int skill1Count = 0;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player")?.transform;
    }
    public override void Attack(Vector2 pos, float attackRange)
    {
        float distance = Vector2.Distance(pos, player.position);

        if (Time.time < lastAttackTime + attackCooldown) { return; }
        else if (Time.time >= lastSkillTime + skillCooldown && skill1Count < 2)
        {
            anim.SetTrigger("Attack");
            // Stop
            lastAttackTime = Time.time;
        }
        else
        {
            Debug.Log("1");
            if (distance < attackRange)
            {
                Debug.Log("2");
                anim.SetTrigger("Attack2");
            }
        }
    }
    public override void PlaySkillEffect(Vector2 targetPos) { }
    private IEnumerator SpinAttack()
    {
        spinHitBox.enabled = true;
        yield return new WaitForSeconds(attackCooldown);
        spinHitBox.enabled = false;
    }
}