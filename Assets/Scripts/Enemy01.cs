using System.Collections;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public float EnemyHP = 100.0f;
    public float CurrentHP;
    public GameObject EnemybulletPrefab;
    public Transform spawnpoint;
    public float AttackTime = 2.0f;
    void Start()
    {
        CurrentHP = EnemyHP;
        StartCoroutine("Fire");
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
            if (GameManager.isPaused)
            {
                yield return null;
            }
            GameObject clone = Instantiate(EnemybulletPrefab, spawnpoint.position, Quaternion.identity);
            clone.GetComponent<EnemyBullet>().Setup();
            yield return new WaitForSeconds(AttackTime);
        }
    }
}
