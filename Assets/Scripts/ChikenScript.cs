using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenScript : MonoBehaviour
{
    public float speed = 20000;
    private SphereCollider sphereCollider;
    private GameObject player;
    private Rigidbody rb;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();

        Vector3 Direction = (transform.position - player.transform.position);
        float distancce = Direction.magnitude;
        rb.AddForce(Direction.normalized * speed * distancce);

    }

    private void OnTriggerExit(Collider other)
    {
        sphereCollider.isTrigger = false;
    }
}
