using UnityEngine;

public class PlayerInMenu : MonoBehaviour
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
    private Animator Anim;
    private bool facingRight;
    private readonly int playerSpeedID = Animator.StringToHash("PlayerSpeed");
    private readonly int onGroundID = Animator.StringToHash("OnGround");
    private readonly int shootingOnAirID = Animator.StringToHash("ShootOnAir");
    private readonly int isShootingID = Animator.StringToHash("IsShooting");
    private float holdTimer = 0f;
    private bool ChargedBullet = false;

    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        facingRight = true;
    }

    private void FixedUpdate()
    {
        Player_Move();
        if (rigid.linearVelocityY == 0f) 
        { 
            Is_Jumping = false;
        }

        if (rigid.linearVelocityY != 0f)
        {
            Is_Jumping = true;
        }
        
    }

    private void Update()
    {
        
        Player_Fire();
        if (Input.GetButtonDown("Vertical")&&Is_Jumping==false)
        {
            rigid.AddForce(Vector2.up * Jump_height, ForceMode2D.Impulse);
        }

        AnimatorStateInfo stateInfo = Anim.GetCurrentAnimatorStateInfo(0);
        // Always checking if player on Ground or not
        Anim.SetBool(onGroundID, !Is_Jumping);
        // Always setting the Player Speed to the Animator - Idle if Horizontal PlayerSpeed < 0.05f
        Anim.SetFloat(playerSpeedID, Mathf.Abs(rigid.linearVelocity.x));
        
    }


    public void Player_Move()
    {
        

        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if (!facingRight)
                {
                    FlipPlayer();
                }
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if (facingRight)
                {
                    FlipPlayer();
                }
            }
        }
        
        //spawnpoint.position = transform.position + new Vector3(0.6f*dir_now, 0, 0);
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
       
        if (Input.GetButton("Jump"))
        {
            
            holdTimer = holdTimer + Time.deltaTime;
            Anim.SetBool(isShootingID, true);
            if (Is_Jumping)
            {
                Anim.SetTrigger(shootingOnAirID);
            }
            if (holdTimer >= ChargeTimeRequired)
            {
                ChargedBullet = true;

            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (ChargedBullet)
            {
                GameObject Charged_Bullet = Instantiate(ChargedbulletPrefab, spawnpoint.position, Quaternion.identity);
                Charged_Bullet.GetComponent<Bullets>().Setup(dir_now, ChargedBullet);
            }
            else
            {
                GameObject Bullet = Instantiate(bulletPrefab, spawnpoint.position, Quaternion.identity);
                Bullet.GetComponent<Bullets>().Setup(dir_now, ChargedBullet);
            }
            holdTimer = 0f;
            ChargedBullet = false;
            Anim.SetBool(isShootingID, false);
        }

    }
    private void FlipPlayer()
    {
        facingRight = !facingRight; // FacingRight becomes the opposite of the current value.
        transform.Rotate(0f, 180f, 0f);
        dir_now = dir_now * -1;
    }
}
