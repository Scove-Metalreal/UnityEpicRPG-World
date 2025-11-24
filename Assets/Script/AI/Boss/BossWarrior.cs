using UnityEngine;

public class BossWarrior : AbstractEnemy
{
    public float attackCooldown = 2f;
    private float lastAttackTime;

    public int phase = 1;
    public int maxHealthPhase2 = 50;
    protected override void Awake()
    {
        base.Awake();
        GetHealthSystem().SetHealth(300);
    }

    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        HandlePhase();
        HandleAI();
    }
    private void HandlePhase()
    {
        float healthPercent = GetHealthSystem();

        if (phase == 1 && healthPercent <= 0.5f)
        {
            phase = 2;
            moveSpeed *= 1.5f;
            anim.SetTrigger("Phase 2");
            Debug.Log("")
        }
    }
}
