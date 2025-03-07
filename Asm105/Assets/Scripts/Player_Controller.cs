using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] Transform firePoint;
    private Rigidbody2D rb;
    private Animator anim;
    private string currentAnim;
    public int countEnemy = 0;
    public int countCoin = 0;
    Vector3 originalScale;
    public int Coins = 0;
    public int HP = 3;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI HPText;
    AudioSource coin;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CoinText.SetText(Coins.ToString());
        HPText.SetText(HP.ToString());
        coin = GameObject.FindWithTag("player").GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Attack();
        if(countCoin == 3 && countEnemy == 6)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void CountEnemy()
    {
        countEnemy ++; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("box") && countCoin == 3)
        {
            SceneManager.LoadScene("Level 2");
        }
        if (other.gameObject.CompareTag("box2") && countEnemy == 1)
        {
            SceneManager.LoadScene("Level 3");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            HP--;
            HPText.SetText(HP.ToString());
            changrAnim("hurt");
            if (HP == 0)
            {
                SceneManager.LoadScene("Game over");
            }
        }
        if (other.gameObject.CompareTag("coin"))
        {
            Coins++;
            countCoin++;
            coin.Play();
            CoinText.SetText(Coins.ToString());
            Destroy(other.gameObject);
        }
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        if(MathF.Abs(horizontal) > 0.1f )
        {
            changrAnim("run");
            transform.rotation = Quaternion.Euler(new Vector3(0, (horizontal > 0.1f)? 0: -180,0));
            rb.velocity = movement * speed * Time.deltaTime;
        }
        else if ( Mathf.Abs(vertical) > 0.1f)
        {
            changrAnim("run");
            rb.velocity = movement * speed * Time.deltaTime;
        }
        else
        {
            changrAnim("idle");
            rb.velocity = Vector2.zero;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            changrAnim("combo");

            Instantiate(bullet, firePoint.position, transform.rotation);
        }
    }

    private void changrAnim(String AnimName)
    {
        if(currentAnim != AnimName)
        {
            anim.ResetTrigger(AnimName);
            currentAnim = AnimName;
            anim.SetTrigger(currentAnim);
        }
    }

}
