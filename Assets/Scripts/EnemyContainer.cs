using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyContainer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float horizontalSpeed = 0.5f;
    [SerializeField] private float verticalSpeed = 0.05f;
    bool block = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = horizontalSpeed * Vector2.right + verticalSpeed * Vector2.down;
    }

    private async void BlockForAWhile()
    {
        block = true;
        await Task.Delay(300);
        block = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (block) return;
        horizontalSpeed = -horizontalSpeed;
        rb.velocity = horizontalSpeed * Vector2.right + verticalSpeed * Vector2.down;
        BlockForAWhile();
    }

}
