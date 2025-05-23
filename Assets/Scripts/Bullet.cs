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
    private float dir_now;

    public void Setup(float dir,bool charged)
    {
        bullet= GetComponent<Rigidbody2D>();
        bullet.linearVelocityX= bulletSpeed*dir;
        dir_now = dir;

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

    private void FixedUpdate()
    {
        if (GameManager.isPaused)
        {
            bullet.linearVelocityX = 0;
            return;
        }
        bullet.linearVelocityX = bulletSpeed * dir_now;
        // 화면 밖으로 나가면 오브젝트 삭제
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            Destroy(gameObject);
        }
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
