using System.Linq;
using UnityEngine;
using Harborview.GameTools;
public class GameManager : MonoBehaviour, IGameState
{
    public GameObject player;
    public bool IsPaused { get; set; } = false;
    public bool isGameOver;
    public GameObject currZone;
    //public GameObject nextZone;
    public ZoneMarker[] zones;
    public bool[] unlocked;
    public GameObject pauseScreen;
    public GameObject zoneTwoDoor;
    public GameObject zoneThreeDoor;


    public void PauseGame()
    {
        if (IsPaused)
        {
            IsPaused = false;
        } else
        {
            IsPaused = true;
        }
        pauseScreen.SetActive(IsPaused);
        Time.timeScale = IsPaused ? 0 : 1;
    }
    bool IGameState.IsPaused => IsPaused;

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
        if (zones[0].resolved) 
        {
            zoneTwoDoor.GetComponent<OpenDoor>().Open();
        }
        if (zones[1].resolved)
        {
            zoneThreeDoor.GetComponent<OpenDoor>().Open();
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

    

    void IGameState.PauseGame()
    {
        PauseGame();
    }
}
