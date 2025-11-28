using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class BossWarrior : AbstractEnemy
{
    [Header("Combat Settings")]
    [SerializeField] private MeleeHitBox meleeHitBox;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float skillCooldown = 2f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    public Transform player;
    private float lastAttackTime = -999f;
    private float lastSkillTime = -999f;
    public int phase = 1;
    public int maxHealthPhase2 = 50;

    public GameObject phase1Model;
    public GameObject phase2Model;

    private GameObject currentModel;
    protected override void Awake()
    {
        base.Awake();
        healthSystem = new HealthSystem(200);

        healthSystem.OnDead += HealthSystem_OnDead;

        phase1Model.SetActive(true);
        phase2Model.SetActive(false);

        SetAnimator(phase1Model.GetComponent<Animator>());
        SetSpriteRenderer(phase1Model.GetComponent<SpriteRenderer>());
    }

    
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player")?.transform;
        currentModel = Instantiate(phase1Model, transform);
    }
    public void Update()
    {
        HandlePhase();
    }

    private void HandlePhase()
    {
        float hpPercent = GetHealthSystem().GetHealthNormalized();

        if (phase == 1 && hpPercent <= 0.5f )
        {
            phase = 2;
            Vector3 oldPos = currentModel.transform.localPosition;
            Vector3 oldScale = currentModel.transform.localScale;

            // Destroy(currentModel);

            currentModel = Instantiate(phase2Model, transform);
            currentModel.transform.localPosition = oldPos;
            currentModel.transform.localScale = oldScale;

            anim = currentModel.GetComponent<Animator>();
            sr = currentModel.GetComponent<SpriteRenderer>();

            anim.SetTrigger("Phase2");
            moveSpeed *= 1.5f;
            anim.SetTrigger("Phase2");
            Debug.Log("Phase2 triggered.");
        }
    }
    public override void Attack(Vector2 pos, float attackRange)
    {
        if (player == null) return;

        if (Time.time < lastAttackTime + attackCooldown) return;

        Stop();
        lastAttackTime = Time.time;

        float distance = Vector2.Distance(pos, player.position);

        if (distance < attackRange - 1f)
        {
            anim.SetTrigger("Attack2");
            Stop();
        }
        else
        {
            anim.SetTrigger("Attack");
            Stop();
            PlaySkillEffect(player.position);
        }
    }

    public override void PlaySkillEffect(Vector2 targetPos)
    {
        if (Time.time < lastSkillTime + skillCooldown) return;
        lastSkillTime = Time.time;

        if (projectilePrefab == null)
        {
            Debug.LogError("projectilePrefab is missing!");
            return;
        }

        GameObject skillFx = Instantiate(projectilePrefab, targetPos + new Vector2(0, 0.45f), Quaternion.identity);
        SkillEffect effect = projectilePrefab.GetComponent<SkillEffect>();

        if (effect != null)
        {
            effect.target = player;
        }

        Animator fxAnim = skillFx.GetComponent<Animator>();
        fxAnim.SetTrigger("Skill");
    }
}
