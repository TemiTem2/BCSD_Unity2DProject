using UnityEngine;
using TMPro;

public class CoinCountVeiwer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCoinCount;
    // Update is called once per frame
    void Update()
    {
        textCoinCount.text = "X" + ScoreManager.CoinCount;
    }
}
