using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public float lifeTime = 1.5f;
    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
