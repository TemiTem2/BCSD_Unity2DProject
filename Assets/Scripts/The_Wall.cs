using Unity.VisualScripting;
using UnityEngine;

public class The_Wall : MonoBehaviour
{
    private float Speed;
    public float beasu;
    void Start()
    {
        Speed = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManager.isPaused)
        {
            return;
        }
        Speed = Speed + Time.deltaTime*beasu;
        if (PlayerManager.IsGameOver)
        {
            Speed = 1;
        }
        transform.Translate(new Vector2(Speed, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.IsGameOver = true;
        }
    }
    
        
    
}

