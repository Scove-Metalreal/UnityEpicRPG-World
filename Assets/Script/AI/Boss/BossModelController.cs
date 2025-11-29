using UnityEngine;

public class BossModelController : MonoBehaviour
{
    public GameObject phase1Model;
    public GameObject phase2Model;

    private GameObject currentModel;
    public Animator Animator { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }

    void Awake()
    {
        // NOTE (1.1): Setup phase mặc định
        currentModel = phase1Model;
        phase1Model.SetActive(true);
        phase2Model.SetActive(false);
        CacheComponents();
        Debug.Log("[ModelController] (1.1) Initialized with Phase 1 model.");
    }
    private void CacheComponents()
    {   
        // NOTE (1.2): Lưu Animator & Renderer để các script khác dùng
        Animator = currentModel.GetComponent<Animator>();
        SpriteRenderer = currentModel.GetComponent<SpriteRenderer>();
        Debug.Log("[ModelController] (1.2) Cached Animator & SpriteRenderer.");
    }
    public void SwitchToPhase2()
    {
        // NOTE (1.3): Chuyển sang model phase 2
        Vector3 pos = currentModel.transform.localPosition;
        Vector3 scale = currentModel.transform.localScale;

        phase1Model.SetActive(false);
        phase2Model.SetActive(true);

        currentModel = phase2Model;
        currentModel.transform.localPosition = pos;
        currentModel.transform.localScale = scale;

        CacheComponents();
        Debug.Log("[ModelController] (1.3) Switched to Phase 2 model.");
    }
}
