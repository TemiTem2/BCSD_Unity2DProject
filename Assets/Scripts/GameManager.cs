using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject pausemenu;
    public static bool isPaused = false;
    public Animator result_Anim;
    private bool resultActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused||PlayerManager.IsGameOver==true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (PlayerManager.IsGameOver&&resultActive==false)
        {
            result_Anim.SetTrigger("GameEnd");
            resultActive = true;
        }
        
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        isPaused = false;
    }
    public void Pause()
    {
        pausemenu.SetActive(true);
        isPaused = true;
    }

    public void MainMenuButton()
    {
        pausemenu.SetActive(false);
        isPaused = false;
        PlayerManager.IsGameOver = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerManager.IsGameOver = false;
        ScoreManager.EnemyKills = 0;
        ScoreManager.CoinCount = 0;
        ScoreManager.TimeScore = 0;
        ScoreManager.totalscore = 0;
        ScoreManager.IsHighScore = false;
    }
    public void Menu()
    {
        PlayerManager.IsGameOver = false;
        ScoreManager.EnemyKills = 0;
        ScoreManager.CoinCount = 0;
        ScoreManager.TimeScore = 0;
        ScoreManager.totalscore = 0;
        ScoreManager.IsHighScore = false;
        if (SceneManager.GetActiveScene().name == "Testing")
        {
            ScoreManager.HighScore = 0;
        }
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
