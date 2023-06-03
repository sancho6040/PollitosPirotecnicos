using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform targetPoint;
    public GameObject tentacle;
    public float initScale;
    public float tentacleSize;

    void Start()
    {
        targetPoint = GameObject.Find("Target").transform;
        tentacle = GameObject.Find("Player/Tentacle");
        initScale = tentacle.transform.localScale.z;
        tentacleSize = tentacle.transform.GetChild(0).gameObject.transform.localScale.z;
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Fire");
            float finalScale = targetPoint.transform.position.z * .3f;
            tentacle.transform.localScale = new Vector3(tentacle.transform.localScale.x, tentacle.transform.localScale.y, Mathf.Lerp(tentacle.transform.localScale.z, finalScale, 0.2f));
        }

        float angle = Mathf.Atan(targetPoint.position.x / targetPoint.position.y);
        tentacle.transform.Rotate(new Vector3(0, angle, 0));
    }
}
