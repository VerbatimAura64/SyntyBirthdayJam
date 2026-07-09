using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused = false;
    public bool isGameOver;
    public GameObject currZone;
    public GameObject nextZone;
    public ZoneMarker[] zones;
    public bool[] unlocked;
    public GameObject pauseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckZoneUnlock()
    {
        for (int i = 0; i < zones.Length; i++)
        {
            if (currZone.GetComponent<ZoneMarker>().resolved) 
            { 
                currZone = zones[i+1].gameObject;
                //nextZone = 
            }

        }
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
