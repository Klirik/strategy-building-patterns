using System;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public event Action<bool> IsCollide;
    int colisionsCount = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        colisionsCount++;
        IsCollide?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        colisionsCount--;
        if(colisionsCount <= 0)
        {
            colisionsCount = 0;
            IsCollide?.Invoke(false);
        }
    }
}
