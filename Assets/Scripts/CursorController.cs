using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject prefab;

    GameObject selectedObject;
    Vector3 currentCursorPoint;
    Ray ray;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var canSelectObject = Physics.Raycast(ray) && selectedObject == null;

            selectedObject = canSelectObject ? Instantiate(prefab) : null;
        }

        SetObjPosToCursorPos(selectedObject);
    }

    void SetObjPosToCursorPos(GameObject gameObject)
    {
        if (gameObject == null) return;

        currentCursorPoint = CalculateCurrentCursorPos();
        gameObject.transform.position = currentCursorPoint;
    }

    Vector3 CalculateCurrentCursorPos()
    {
        currentCursorPoint = Input.mousePosition;
        currentCursorPoint.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(currentCursorPoint);
    }
}
