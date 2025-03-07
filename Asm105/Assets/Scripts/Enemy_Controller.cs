using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    //[SerializeField] float moveSpeed = 0.5f;
    public Transform player;
    public SpriteRenderer enmySR;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("player");
        if(playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.Log("Ko co player");
        }

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("bullet"))
    //    {
    //        transform.Rotate(0, 180, 0);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //if (player != null)
        //{
        //    Vector2 dir = (player.position - transform.position).normalized;
        //    Vector3 faceEnemy = dir * moveSpeed * Time.deltaTime;
        //    transform.Translate(faceEnemy);

        //    if (faceEnemy.x != 0)
        //    {
        //        if (faceEnemy.x < 0)
        //        {
        //            enmySR.transform.localScale = new Vector3(-1, 1, 1);
        //        }
        //        else
        //        {
        //            enmySR.transform.localScale = new Vector3(1, 1, 1);

        //        }
        //    }
        //}
    }
}
