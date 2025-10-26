using UnityEngine;

public class FireWeapon : SampleEnemy
{
    public float skillCooldown = 2f;
    private float lastSkillTime = -999f;
    // public Animator skillAnimator;
    public Transform firePoint;
    public GameObject projectilePrefab;
    protected override void Awake()
    {
        base.Awake();
        //if (skillanimator == null)
        //   skillanimator = getcomponentinchildren<animator>();
    }
    public override void Attack()
    {
        Stop();
        anim.SetTrigger("Attack");
    }
    public override void PlaySkillEffect()
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
        GameObject skillFx = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Animator fxAnim = skillFx.GetComponent<Animator>();
        fxAnim.SetTrigger("Skill1");
    }
}

// Dau tien la state Attack trong EnemyAI 

// Khi vao state Attack thi goi ham Fire() trong class FireWeapon
// Bat dau goi anim cua FireWeapon
// Goi ham Fire() khi rigidbody cua FireWeapon den 1 vi tri nhu la Player neu dinh player thi set health player -5