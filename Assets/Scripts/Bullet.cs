using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    private Vector2 bullet_pos;
    private Bullet bullet;

    private void Start()
    {
        bullet_pos = new Vector2(bulletSpeed, 0);
        bullet= GetComponent<Bullet>();
    }
    private void Update()
    {
        transform.Translate(bullet_pos*Time.deltaTime);
    }

}
