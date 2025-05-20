using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    private Vector2 bullet_pos;
    private GameObject bullet;
    public PlayerMove player;

    private void Start()
    {
        bullet= GetComponent<GameObject>();
    }
    private void Update()
    {
        transform.Translate(bullet_pos*Time.deltaTime);
    }

}
