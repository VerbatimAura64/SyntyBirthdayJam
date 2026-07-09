using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused = false;
    public bool isGameOver;
    public GameObject currZone;
    //public GameObject nextZone;
    public ZoneMarker[] zones;
    public bool[] unlocked;
    public GameObject pauseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        unlocked = new bool[zones.Length];
        pauseScreen.SetActive(false);
        CheckZoneUnlock();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckZoneUnlock();
        IsGameOver();
    }

    void CheckZoneUnlock()
    {
        if (currZone == null)
        {
            currZone = zones[0].gameObject;
        }
        
            for (int i = 0; i < zones.Length; i++)
            {
                if (zones[i].resolved)
                {
                    if (i +1 >= zones.Length)
                        currZone = zones[i].gameObject;
                    else
                        currZone = zones[i + 1].gameObject;
                    unlocked[i] = true;
                    
                }
            }
        
    }

    void IsGameOver()
    {
        //If all zones unlocked, game is over
        //for (int i = 0; i < unlocked.Length; i++)
        //{
        isGameOver = unlocked.All(unlocked => true);
            
                //isGameOver = true;
            
                
             
                
        //}
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
