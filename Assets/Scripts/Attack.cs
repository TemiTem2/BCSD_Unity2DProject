using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnpoint;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }
    }


    void Fire()
    {
        Instantiate(bulletPrefab,spawnpoint.position,Quaternion.identity);
    }
}
