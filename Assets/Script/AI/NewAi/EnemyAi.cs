using CodeMonkey.HealthSystemCM;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Thiet lap State Machine
    private enum State
    {
        Roaming,
        Chasing,
        Attack,
        Dead

    }
    private State state;
    private AbstractEnemy motor;

    // Khai bao vi tri
    private Vector2 startPos;
    private Vector2 roamPos;

    // Tam trang thai
    public Transform player;
    public float detectRange = 5f;
    public float loseRange = 8f;
    public float attackRange = 3f;
    [SerializeField] private bool isMage = false;
    private void Awake()
    {
        motor = GetComponent<AbstractEnemy>();
        state = State.Roaming;
    }
    private void Start()
    {
        // Vi tri bat dau di chuyen quanh do
        startPos = transform.position;
        roamPos = GetRoamPosition();
    }
    private void Update()
    {
        switch (state)
        {
            case State.Roaming:
                motor.MoveTo(roamPos);

                if (Vector2.Distance(transform.position, roamPos) < 0.5f)
                    roamPos = GetRoamPosition();
                
                if (Vector2.Distance(transform.position, player.position) < detectRange)
                {
                    state = State.Chasing;
                }
                break;

            case State.Chasing:
                motor.MoveTo(new Vector2(player.position.x + 0.5f, player.position.y + 0.45f));

                if (Vector2.Distance(transform.position, player.position) > loseRange)
                {
                    state = State.Roaming;
                    roamPos = GetRoamPosition();
                }

                if (isMage)
                {
                    if (Vector2.Distance(transform.position, player.position) < attackRange)
                    {
                        state = State.Attack;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, player.position) < attackRange - 2f)
                    {
                        state = State.Attack;
                    }
                }

                break;
            case State.Attack:
                Vector2 targetPos = new Vector2(player.position.x, player.position.y + 0.45f);

                motor.Attack(transform.position, attackRange);
                if (Vector2.Distance(transform.position, player.position) > attackRange)
                {
                    state = State.Chasing;
                }
                break;
        }
    }
    private Vector2 GetRoamPosition()
    {
        return startPos + Random.insideUnitCircle * 3f;
    }
}

// Neu khoang cach nguoi choi gan float attackRang thi thuc hien tan cong
