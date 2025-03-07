using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;  
    public Transform player;  
    public Vector3 offset;   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.position = Camera.main.WorldToScreenPoint(player.position + offset);
    }

    public void SetHealth(int health, int maxHealth)
    {
        healthBar.gameObject.SetActive(health < maxHealth);
        healthBar.value = health;
        healthBar.maxValue = maxHealth;
    }
}
