using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class BossWarrior : AbstractEnemy
{
    public BossModelController model;
    public BossPhaseController phase;
    public BossCombatController combat;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("[BossWarrior] (4.1) Awake called.");

        phase.healthSystem = GetHealthSystem();
        combat.player = GameObject.FindWithTag("Player").transform;

        Debug.Log("[BossWarrior] (4.2) Linked components.");
    }
    protected override Animator GetAnimator()
    {
        return model.Animator;  // Lấy từ model controller
    }
    public override void Attack(Vector2 pos, float range)
    {
        // NOTE (4.3): Chỉ điều phối sang CombatController
        Debug.Log("[BossWarrior] (4.3) Attack() call forwarded to CombatController.");
        combat.Attack();
    }
    public override void PlaySkillEffect(Vector2 targetPos)
    {
        combat.PlaySkill();
    }
}
