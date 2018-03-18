using UnityEngine;
using System.Collections;

public class checkpointHandler : MonoBehaviour {

    public enum Mode
    {
        Regular, Locked
    }

    public Mode mode;

    public GameObject[] checkPoints;

    public GameObject player;

    public GameObject spawn;

    public PelaajanTerveys pikkukaveri;

	// Use this for initialization
	void Start () {

        checkPoints = GameObject.FindGameObjectsWithTag("checkpoint");
        spawn = GameObject.Find("Spawn");
        pikkukaveri = GetComponent<PelaajanTerveys>();
	}
	
	// Update is called once per frame
	public void Update () {

        if(Input.GetAxis("R")>0)
            foreach (GameObject cp in checkPoints)
            {

                if (cp.GetComponent<Checkpoint>().status == Checkpoint.state.Active)
                { player.transform.position = cp.transform.position; }
            }
        }


    public void UpdateCheckpoints(GameObject curCheck)
    {
        if (mode == Mode.Regular) {
            foreach (GameObject cp in checkPoints)
            {

                if (cp.GetComponent<Checkpoint>().status != Checkpoint.state.Inactive)
                {
                    cp.GetComponent<Checkpoint>().status = Checkpoint.state.Used;
                }
            }
            curCheck.GetComponent<Checkpoint>().status = Checkpoint.state.Active;
        }
        }
    //else
}
