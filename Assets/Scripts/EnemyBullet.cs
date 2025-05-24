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

    private void FixedUpdate()
    {
        if (GameManager.isPaused)
        {
            bullet.linearVelocityX = 0;
            return;
        }
        bullet.linearVelocityX = bulletSpeed * -1;
        // 화면 밖으로 나가면 오브젝트 삭제
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerManager.PlayerAttacked();
            Destroy(gameObject);
        }
        
    }
}
