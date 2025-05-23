using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int MaxHP=5;
    public static int currentHP;
    public GameObject player;
    public static bool IsGameOver;
    public static float mujukTime;
    


    void Awake()
    {
        currentHP = MaxHP;
        IsGameOver = false;
    }
    void Update()
    {
        if (mujukTime > 0f)
        {
            mujukTime = mujukTime - Time.deltaTime;
        }
        if (IsGameOver)
        {
            currentHP = 0;
            Destroy(player);
        }
        if (player != null && player.transform.position.y <= -10f)
        {
            IsGameOver = true;
        }
    }

    public static  void PlayerAttacked() 
    {
        if (mujukTime <= 0f)
        {
            currentHP--;
            if (currentHP <= 0)
            {
                IsGameOver = true;
            }
            mujukTime = 1.5f;
        }
        return;
    }
}
