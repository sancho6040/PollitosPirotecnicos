using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player variables")]
    public int lives = 5;
    public int score;
    private bool bIsAttacking;
    public float coolDown;

    [Header("movement variables")]
    public float movementSpeed = 1f;
    public float tentacleSpeed = 0.5f;

    // tentacle
    private GameObject target;
    private GameObject tentacle;
    public GameObject tip;
    private ChickenDetector chikenDetector;

    //Scale values
    private float initialDistance;
    private float initialScale;

    private float newDistance;
    private float newScale;

    private Rigidbody rb;

    [Header("partiles")]

    public GameObject crashParticles;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Target");
        tentacle = GameObject.Find("Player/Tentacle");
        chikenDetector = tip.GetComponent<ChickenDetector>();

        initialDistance = (transform.position - tip.transform.position).magnitude;
        initialScale = tentacle.transform.localScale.x;

        coolDown = 0f;
    }

    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && coolDown <= 0)
        {
            Debug.Log("ola");
            tip.transform.DOMove(target.transform.position, tentacleSpeed).SetEase(Ease.InQuart).OnComplete(() => playerMove());
            coolDown = tentacleSpeed;
            bIsAttacking = true;
        }

        if (!bIsAttacking)
        {
            tip.transform.DOMove(transform.position, tentacleSpeed).SetEase(Ease.OutQuart);
        }

        newDistance = (transform.position - tip.transform.position).magnitude;
        newScale = (newDistance * initialScale) / initialDistance;

        if (newDistance <= 0.2f && coolDown <= 0f)
        {
            bIsAttacking = false;
        }

        tentacle.transform.DOScaleZ(newScale, 0f);
        tentacle.transform.LookAt(tip.transform);
    }

    void playerMove()
    {
        Vector3 unitDirection = (target.transform.position - transform.position).normalized;
        float distance = (target.transform.position - transform.position).magnitude;
        rb.velocity = Vector3.zero;

        if (chikenDetector.isAChicken())
        {
            rb.AddForce(unitDirection * movementSpeed * distance);
        }
        else
        {
            bIsAttacking = false;
            rb.AddForce(-unitDirection * (movementSpeed / 3));
        }
    }

    void TakeDamage()
    {
        lives -= 1;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            if (bIsAttacking)
            {
                bIsAttacking = false;
                //particles ????
                // Instantiate(crashParticles, transform.position, Quaternion.identity);
                //sound
                score += 10;
                other.gameObject.GetComponent<ChickenScript>().die();
            }
            else
            {
                TakeDamage();
            }

        }
    }

}
