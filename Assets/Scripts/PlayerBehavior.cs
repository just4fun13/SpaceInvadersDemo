using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject bulletPrefab;
    
    Quaternion ShotUp() => Quaternion.Euler(0f, 0f, 0f);


    public void MoveHorizontal(float dir)
    {
        transform.Translate(Vector2.right * dir * 0.01f * speed);
    }

    public void MoveVertical(float dir)
    {
        transform.Translate(Vector2.up * dir * 0.01f * speed);
    }

    public void Shot()
    {
        Instantiate(bulletPrefab, transform.position, ShotUp() );
    }

    public void Damaged()
    {
        Debug.Log("Player Damaged");
    }
}
