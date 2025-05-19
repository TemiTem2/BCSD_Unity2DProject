using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool Is_Jumping;
    public float high_speed = 2.0f;
    public float Jump_height = 10.0f;
    public GameObject bulletPrefab;
    public GameObject ChargedbulletPrefab;
    public Transform spawnpoint;
    public float ChargeTimeRequired = 0.5f;
    private float dir_now=1;
    public float bulletSpeed;

    private float holdTimer = 0f;
    private bool ChargedBullet = false;

    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Player_Move();
        if (rigid.linearVelocityY < 0.0f)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0, 0));
            RaycastHit2D hit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Flatform"));
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                Is_Jumping = false;
            }

        }
    }

    private void Update()
    {
        Player_Fire();
        if (Input.GetButtonDown("Vertical")&&Is_Jumping==false)
        {
            rigid.AddForce(Vector2.up * Jump_height, ForceMode2D.Impulse);
            Is_Jumping=true;
        }

    }


    public void Player_Move()
    {
        

        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        if (rigid.linearVelocityX > high_speed) 
        { 
            rigid.linearVelocityX = high_speed;
        }
        if (rigid.linearVelocityX < high_speed*-1)
        {
            rigid.linearVelocityX = high_speed*-1;
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rigid.linearVelocityX = 0;
        }
    }

  
    public void Player_Fire()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            dir_now = Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetButton("Jump"))
        {
            holdTimer = holdTimer + Time.deltaTime;

            if (holdTimer >= ChargeTimeRequired)
            {
                ChargedBullet = true;

            }
            
            Debug.Log(holdTimer);
            Debug.Log(dir_now);
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (ChargedBullet)
            {
                GameObject Charged_Bullet = Instantiate(ChargedbulletPrefab, spawnpoint.position, Quaternion.identity);

                Rigidbody2D Cb = Charged_Bullet.GetComponent<Rigidbody2D>();
                Cb.linearVelocityX = bulletSpeed*dir_now;
            }
            else
            {
                GameObject Bullet = Instantiate(bulletPrefab, spawnpoint.position, Quaternion.identity);

                Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                rb.linearVelocityX = bulletSpeed * dir_now;
            }
            holdTimer = 0f;
            ChargedBullet = false;
        }

    }
}
