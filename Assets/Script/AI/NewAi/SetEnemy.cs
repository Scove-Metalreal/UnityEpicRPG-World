using UnityEngine;

public class SetEnemy : AbstractEnemy
{

    [SerializeField] private MeleeHitBox meleeHitbox;
    public float skillCooldown = 2f;
    private float lastSkillTime = -999f;
    private int skill1Count = 0;
    // public Animator skillAnimator;
    public Transform firePoint;
    private Transform player;
    public GameObject projectilePrefab;
    protected override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
    }
    public override void Attack(Vector2 pos, float attackRange)
    {
        Stop();
        
        if (Vector2.Distance(pos, player.position) < attackRange - 1f)
        {
            anim.SetTrigger("Attack2");

            meleeHitbox.EnableHitBox();
            // EnableHitbox();
            // Invoke(nameof(DisableHitbox), 0.3f);
        }
        else
        {
            anim.SetTrigger("Attack");

            // EnableHitbox();
            // Invoke(nameof(DisableHitbox), 0.3f);
        }
            
    }
    public void EnableHitbox()
    {
        meleeHitbox.EnableHitBox();
    }
    public void DisableHitbox()
    {
        meleeHitbox.DisableHitBox();
    }
    public override void PlaySkillEffect(Vector2 targetPos)
    {
        if (Time.time < lastSkillTime + skillCooldown)
        {
            return;
        }
        lastSkillTime = Time.time;
        if (projectilePrefab == null)
        {
            Debug.LogError("projectilePrefab = NULL !!!");
            return;
        }
        GameObject skillFx = Instantiate(projectilePrefab, targetPos, Quaternion.identity);
        SkillEffect effect = projectilePrefab.GetComponent<SkillEffect>();

        effect.target = player;
        Animator fxAnim = skillFx.GetComponent<Animator>();
        if (skill1Count < 3)
        {
            fxAnim.SetTrigger("Skill1");
            skill1Count++;
        }
        else
        {
            fxAnim.SetTrigger("Skill2");
            skill1Count = 0;
        }
    }
}