using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public int EnemyKills = 0;
    public static int CoinCount=0;
    public static int TimeScore = 0;
    public static int totalscore = 0;
    public static int HighScore = 0;
    private float timer;
    public static bool IsHighScore = false;

    private void Awake()
    {
        totalscore = 0;
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f&&PlayerManager.IsGameOver==false)
        {
            TimeScore++;
            timer = 0;
        }


        totalscore = EnemyKills * 100 + CoinCount * 100 + TimeScore *10;
        if (totalscore > HighScore)
        {
            HighScore = totalscore;
            IsHighScore = true;
        }
    }
}
