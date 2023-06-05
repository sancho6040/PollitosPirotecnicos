using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    public float speed = 20000;
    private GameObject player;
    private Rigidbody rb;

    public GameObject explosionParticles;

    private void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();

        Vector3 Direction = (player.transform.position - transform.position);
        float distance = Direction.magnitude;
        rb.AddForce(Direction.normalized * speed * distance);
    }

    private void Update()
    {
        float distanceToPlayer = (player.transform.position - transform.position).magnitude;
        if (distanceToPlayer >= 25f)
        {
            Destroy(gameObject);
        }
    }


    public void die()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
