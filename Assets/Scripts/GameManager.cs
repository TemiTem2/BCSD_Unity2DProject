using UnityEngine;

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
            if (isPaused)
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
}
