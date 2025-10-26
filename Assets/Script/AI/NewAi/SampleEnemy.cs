using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 lastPosition;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastPosition = rb.position;
    }
    void FixedUpdate()
    {
        // Set bool if isWalking based on actual movement speed
        if (Vector2.Distance(rb.position, lastPosition) > 0.001f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        // Co le nen de animation o trong class EnemyAI phan switch state

        lastPosition = rb.position;
    }
    public void MoveTo(Vector2 targetPos)
    {
        Vector2 direction = (targetPos - rb.position).normalized;
        if (direction.x > 0)
        {
            sr.flipX = false;
        }
        else if (direction.x < 0)
        {
            sr.flipX = true;
        }
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    public void AttackPlayer()
    {
        rb.linearVelocity = Vector2.zero;
        anim.SetTrigger("Attack");
    }
    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
