using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player variables")]
    public int lives;
    public int score;

    [Header("movement variables")]
    public float movementSpeed = 1f;
    public float tentacleSpeed = 0.5f;
    
    // tentacle
    private GameObject target;
    private GameObject tentacle;
    public GameObject tip;
    
    //Scale values
    private float initialDistance;
    private float initialScale;

    private float newDistance;
    private float newScale;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Target");
        tentacle = GameObject.Find("Player/Tentacle");

        initialDistance = (transform.position - tip.transform.position).magnitude;
        initialScale = tentacle.transform.localScale.z;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            tip.transform.DOMove(target.transform.position, tentacleSpeed).SetEase(Ease.OutQuart).OnComplete(() => playerMove());
        }

        newDistance = (transform.position - tip.transform.position).magnitude;
        newScale = (newDistance * initialScale) / initialDistance;
        
        tentacle.transform.DOScaleZ(newScale, 0f);
        tentacle.transform.LookAt(tip.transform);
    }

    void playerMove()
    {
        Vector3 unitDirection = (target.transform.position - transform.position).normalized;
        Debug.Log(unitDirection);
        rb.velocity = Vector3.zero;
        rb.AddForce(unitDirection * movementSpeed);
    }
}
