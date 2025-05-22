using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public int EnemyKills = 0;
    static public int CoinTaking = 0;
    private int score;

    private void Awake()
    {
        score = 0;
    }
    private void Update()
    {
        score = EnemyKills * 100 + CoinTaking * 100;
    }
}
