using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed = 20;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collider.transform.GetComponent<Enemy>();
            enemy.Damaged();
        }
        else if (collider.gameObject.CompareTag("Player"))
        {
            GameLogic.gameLogic.PlayerGotDamage();            
        }
        Destroy(gameObject);
    }

}
