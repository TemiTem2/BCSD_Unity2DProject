using UnityEngine;
using TMPro;

public class ResultVeiwer : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textEnemy;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCoin.text = "Coins : " + ScoreManager.CoinCount.ToString()+"X 100";
        textEnemy.text = "Enemy : " + ScoreManager.EnemyKills.ToString() + "X 100";
        textTime.text = "Time : " + ScoreManager.TimeScore.ToString() + "X 10";
        textScore.text = "Score:" + ScoreManager.totalscore.ToString();
        if (ScoreManager.IsHighScore)
        {
            textHighScore.text = "New High Score!";
        }
        else
        {
            textHighScore.text = "High Score: " + ScoreManager.HighScore.ToString();
        }
    }
}
