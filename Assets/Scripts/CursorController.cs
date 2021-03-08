using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private const float MAX_DIST_RAYCAST = 100f;

    public event Action<bool> OnClickSurface = delegate { };
    Vector3 currentCursorPoint;
    Ray ray;

    [SerializeField] int surfaceLayerNumber = 9;
    int layerMask;

    private void Awake()
    {
        layerMask = 1 << surfaceLayerNumber;        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, MAX_DIST_RAYCAST, layerMask))
            {
                OnClickSurface?.Invoke(true);
            }
        }
    }
        
    public Vector3 CalculateCurrentCursorPos()
    {
        currentCursorPoint = Input.mousePosition;
        currentCursorPoint.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(currentCursorPoint);
    }
}
