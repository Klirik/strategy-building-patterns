using UnityEngine;

public class BuildController : MonoBehaviour
{
    public CursorController Cursor;
    public Building Prefab;

    Building selectedObject;

    private void Awake()
    {
        Cursor.OnClickSurface += Click;
    }


    private void Update()
    {
        if (selectedObject)
        {
            SetObjPosToCursorPos(selectedObject.gameObject);
        }
    }

    bool TryToSetBuilding()
    {
        if (selectedObject == null) return false;

        return !selectedObject.IsColliding;
    }

    private void Click(bool state)
    {
        if(state && selectedObject == null)
        {
            var obj = Instantiate(Prefab.gameObject);
            selectedObject = obj.GetComponent<Building>();            
        }
        else if(TryToSetBuilding())
        {
            selectedObject.Init();
            selectedObject = null;
        }
        else
        {
            //Animate 
        }
    }
    void SetObjPosToCursorPos(GameObject gameObject)
    {
        if (gameObject == null) return;
        
        gameObject.transform.position = Cursor.CalculateCurrentCursorPos();
    }

    private void OnDestroy()
    {
        Cursor.OnClickSurface -= Click;
    }
}
