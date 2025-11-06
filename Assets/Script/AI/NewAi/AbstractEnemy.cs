using CodeMonkey.HealthSystemCM;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, IGetHealthSystem
{
    public float moveSpeed = 5f;

    protected Rigidbody2D rb;
    protected Animator anim;
    protected SpriteRenderer sr;

    private Vector2 lastPosition;
    private HealthSystem healthSystem;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastPosition = rb.position;

        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;
    }
    protected virtual void Start()
    {

    }
    protected virtual void FixedUpdate()
    {
        bool isWalking = Vector2.Distance(rb.position, lastPosition) > 0.001f;
        anim.SetBool("isWalking", isWalking);

        lastPosition = rb.position;
    }
    public virtual void MoveTo(Vector2 targetPos)
    {
        Vector2 direction = (targetPos - rb.position).normalized;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(2.07f, 2.07f, 2.07f);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-2.07f, 2.07f, 2.07f);
        }
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    public virtual void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
    public void Damage(int damage)
    {
        healthSystem.Damage(damage);
    }
    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        anim.SetBool("Dead", true);
        Stop();
        Destroy(gameObject, 1f);
    }
    public HealthSystem GetHealthSystem() => healthSystem;
    public abstract void Attack(Vector2 pos, float attackRange);
    public abstract void PlaySkillEffect(Vector2 targetPos);
}
