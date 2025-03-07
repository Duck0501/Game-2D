using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject effect_bullet;
    Rigidbody2D rb;
    private Animator anim;
    private string currentAnim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        rb.velocity = transform.right * speed *Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
            var name = other.attachedRigidbody.name;
            Destroy(GameObject.Find(name));

            FindObjectOfType<Player_Controller>().CountEnemy();
            GameObject effectbullet = Instantiate(effect_bullet, transform.position, Quaternion.identity);
            Destroy(effectbullet, 0.1f);
        }
    }

    private void changrAnim(String AnimName)
    {
        if (currentAnim != AnimName)
        {
            anim.ResetTrigger(AnimName);
            currentAnim = AnimName;
            anim.SetTrigger(currentAnim);
        }
    }
}
