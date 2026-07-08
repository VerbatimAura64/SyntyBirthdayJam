using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused = false;
    public GameObject pauseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
        } else
        {
            isPaused = true;
        }
        pauseScreen.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
}
