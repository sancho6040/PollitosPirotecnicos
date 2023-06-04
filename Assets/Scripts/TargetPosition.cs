using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    private void Update()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = 10f;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
        
    }

}
