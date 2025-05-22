using System.Collections;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public float EnemyHP = 100.0f;
    public float CurrentHP;
    public GameObject EnemybulletPrefab;
    public Transform spawnpoint;
    void Start()
    {
        CurrentHP = EnemyHP;
        StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onhit(float dmg)
    {
        
        if (CurrentHP <= dmg) 
        {
            Destroy(this.gameObject);
            ScoreManager.EnemyKills++;
        }
        else
        {
            CurrentHP = CurrentHP - dmg;
        }
    }
    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject clone = Instantiate(EnemybulletPrefab, spawnpoint.position, Quaternion.identity);
            clone.GetComponent<EnemyBullet>().Setup();
            yield return new WaitForSeconds(2);
        }
    }
}
