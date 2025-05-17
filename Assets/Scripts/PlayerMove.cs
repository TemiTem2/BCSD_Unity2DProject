using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 player_pos;
    public float bojung;
    public GameObject bulletPrefab;
    public GameObject ChargedbulletPrefab;
    public Transform spawnpoint;
    public float ChargeTimeRequired = 0.5f;
    public float dir_now;

    private float holdTimer = 0f;
    private bool ChargedBullet = false;

    void Start()
    {
        player_pos = new Vector2(0, 0);

    }

    private void FixedUpdate()
    {
        Player_Move();
       
        

    }

    private void Update()
    {
        Player_Fire();
        
        if (dir_now != Input.GetAxisRaw("Horizontal") && Input.GetAxisRaw("Horizontal") != 0)//보는 방향 조절
        {
            dir_now = Input.GetAxisRaw("Horizontal");
        }
    }


    public void Player_Move()
    {
        transform.Translate(player_pos);
        player_pos = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * bojung * Time.deltaTime;
        if (Input.GetButtonDown("Vertical")&&Input.GetAxisRaw("Vertical")==1)
        {
            player_pos = new Vector2(Input.GetAxisRaw("Horizontal"), 5) * bojung * Time.deltaTime;
        }

    }

    public void Player_Jump()
    {
        player_pos = new Vector2(0, 5) * bojung * Time.deltaTime;
        transform.Translate(player_pos);
    }

    public void Player_Fire()
    {
        if (Input.GetButton("Jump"))
        {
            holdTimer = holdTimer + Time.deltaTime;

            if (holdTimer >= ChargeTimeRequired)
            {
                ChargedBullet = true;

            }
            Debug.Log(holdTimer);
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (ChargedBullet)
            {
                Instantiate(ChargedbulletPrefab, spawnpoint.position, Quaternion.identity);
            }
            else
            {
                Instantiate(bulletPrefab, spawnpoint.position, Quaternion.identity);
            }
            holdTimer = 0f;
            ChargedBullet = false;
        }

    }
}
