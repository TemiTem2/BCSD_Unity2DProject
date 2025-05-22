using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    private Vector2 bullet_pos;
    private Rigidbody2D bullet;
    public PlayerMove player;
    private bool ischarged;

    public void Setup(float dir,bool charged)
    {
        bullet= GetComponent<Rigidbody2D>();
        bullet.linearVelocityX= bulletSpeed*dir;

        if (dir > 0)
        {
            transform.Rotate(0f, 0f, 0f);
        }

        if (dir < 0)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        ischarged = charged;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy01>().Onhit(bulletDamage);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            GameObject.Destroy(collision);
            if (!ischarged)
                Destroy(this.gameObject);
        }



    }
}
