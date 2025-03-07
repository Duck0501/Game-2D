using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Player : MonoBehaviour
{
    public float speed = 3;
    public float chasingDistance = 5.0f;

    private Transform playerTransform;
    private Rigidbody2D rb;

    [SerializeField] private GameObject bullet;
    [SerializeField] public Transform firePoint;
    public float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < chasingDistance)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            rb.MovePosition(position);

            transform.LookAt(playerTransform.position);
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
        }

        //if (distanceToPlayer < chasingDistance)
        //{
        //    count++;
        //    if(count > 300)
        //    {
        //        Instantiate(bullet, firePoint.position, transform.rotation);
        //        count = 0;
        //    }
            
        //}
    }
}
