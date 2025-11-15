using UnityEngine;

public class KillEnemyQuestStep : QuestStep
{
    private int enemiesKilled = 0;

    private int enemiesToKill = 5;

    public override void EnterStep() { }
    public override void UpdateStep() { }
    public override bool IsCompleted() { return true; }
    public override void ExitStep() { }
}