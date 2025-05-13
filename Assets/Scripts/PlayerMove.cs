using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 player_pos;
    public float bojung;

    void Start()
    {
         player_pos = new Vector2 (0,0);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(player_pos);
        player_pos = new Vector2(Input.GetAxisRaw("Horizontal")*bojung*Time.deltaTime, Input.GetAxisRaw("Vertical") * bojung * Time.deltaTime);
    }


    void Update()
    {
        
    }
}
