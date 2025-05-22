using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D bullet;
    public float bulletSpeed;
    public void Setup()
    {
        
        bullet = GetComponent<Rigidbody2D>();
        bullet.linearVelocityX = bulletSpeed*-1;
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerManager.PlayerAttacked();
        }
        Destroy(gameObject);
    }
}
