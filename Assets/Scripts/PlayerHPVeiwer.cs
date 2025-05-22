using UnityEngine;
using TMPro;

public class PlayerHPVeiwer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textplayerHP;
    // Update is called once per frame
    void Update()
    {
        textplayerHP.text = PlayerManager.currentHP + "/" + PlayerManager.MaxHP;
    }
}
