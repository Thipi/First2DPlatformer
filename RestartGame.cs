using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour
{

    public float restartTime;
    bool restartNow = false;
    float resetTime = 0f;

    public GameObject currentCheckPoint;

    private pikkukavericontroller player;


    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<pikkukavericontroller>();
    }
    void Update()
    {
        if (restartNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);

        }
    }


    public void RespawnPlayer()
    {
        Debug.Log("respawn");
        player.transform.position = currentCheckPoint.transform.position;
    }
}
