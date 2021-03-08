using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Building : MonoBehaviour, IPlaceable
{
    public MeshRenderer SuggestedArea;
    public CollisionChecker CollisionChecker;

    public Material SuggestedMaterial;
    public Material NotSuggestedMaterial;

    public bool IsColliding { get; private set; }

    Collider myCollider;


    private void Awake()
    {
        WaitInit();
        CollisionChecker.IsCollide += ChangeAreaHiglight;
    }

    void WaitInit()
    {
        myCollider = GetComponent<Collider>();

        myCollider.enabled = false;
    }

    public void Init()
    {
        myCollider.enabled = true;
        SuggestedArea.gameObject.SetActive(false);
    }

    public void ChangeAreaHiglight(bool IsCollide)
    {
        IsColliding = IsCollide;
        SuggestedArea.material = !IsCollide ? SuggestedMaterial : NotSuggestedMaterial;
    }

    private void OnDestroy()
    {
        CollisionChecker.IsCollide -= ChangeAreaHiglight;
    }
}