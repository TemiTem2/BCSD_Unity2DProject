using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 player_pos;
    public float bojung;
    public GameObject bulletPrefab;
    public GameObject ChargedbulletPrefab;
    public Transform spawnpoint;
    public bool Charge;

    void Start()
    {
         player_pos = new Vector2 (0,0);
        
    }

    private void FixedUpdate()
    {
        Player_Move();
       
    }

    private void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            Player_Fire(Charge);
        }
    }
    public void Player_Move()
    {
        transform.Translate(player_pos);
        player_pos = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * bojung * Time.deltaTime;
    }

    public void Player_Jump()
    {
        player_pos = new Vector2(0,5)* bojung * Time.deltaTime;
        transform.Translate(player_pos);
    }

    public void Player_Fire(bool Ischarge)
    {
        if (Ischarge)
        {
            Instantiate(ChargedbulletPrefab, spawnpoint.position, Quaternion.identity);
        }
        else 
        {
            Instantiate(bulletPrefab, spawnpoint.position, Quaternion.identity);
        }
    }

    //private void FIre()
    //{
    //    Instantiate(bulletPrefab, spawnpoint.position, Quaternion.identity);
    //}
}
