using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkillTrigger : MonoBehaviour
{
    public GameObject childPrefab;   
    public float activeTime = 2f;    

    bool isActive = false;
    public void OnBuff(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (!isActive)
            StartCoroutine(SkillRoutine());
    }
    IEnumerator SkillRoutine()
    {
        isActive = true;

        
        childPrefab.SetActive(true);

        
        yield return new WaitForSeconds(activeTime);

       
        childPrefab.SetActive(false);

        isActive = false;
    }
}
