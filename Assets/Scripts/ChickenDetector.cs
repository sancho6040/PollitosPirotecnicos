using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDetector : MonoBehaviour
{
    public bool bIsAChicken = false;
    public float sphereRadius = 0.5f;
    public LayerMask chickenMask;

    public bool isAChicken()
    {
        bIsAChicken = Physics.CheckSphere(transform.position, sphereRadius, chickenMask);
        Debug.Log("this is A chiken: " + bIsAChicken);
        return bIsAChicken;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
