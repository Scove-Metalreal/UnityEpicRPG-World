using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class BossPhaseController : MonoBehaviour
{
    public BossModelController model;
    public AbstractEnemy enemy;
    public HealthSystem healthSystem;

    public int phase = 1;

    void Update()
    {
        // NOTE (2.1): Kiểm tra xem boss đã cần vào Phase 2 chưa
        if (phase == 1 && healthSystem.GetHealthNormalized() <= 0.5f)
        {
            Debug.Log("[PhaseController] (2.1) HP <= 50%, initiating phase transition.");
            EnterPhase2();
        }
    }

    private void EnterPhase2()
    {
        phase = 2;

        // NOTE (2.2): Chuyển model
        model.SwitchToPhase2();

        // NOTE (2.3): Gọi animation Phase2
        model.Animator.SetTrigger("Phase2");

        // NOTE (2.4): Buff speed
        enemy.moveSpeed *= 1.5f;

        Debug.Log("[PhaseController] (2.4) Entered Phase 2. Speed boosted.");
    }
}
