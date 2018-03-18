using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public Sprite[] sprites; //neliöt
    public enum state { Inactive, Active, Used, Locked };
    public state status;

    public checkpointHandler ch;

    // Use this for initialization
    void Start () {
        ch = GameObject.Find("CheckpointHandler").GetComponent<checkpointHandler>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Changecolor()
    {
        if(status == state.Inactive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0]; //ollessaan inactiivinen, hakee ekan värin/kuvan.
        }
        else if(status == state.Active){
            GetComponent<SpriteRenderer>().sprite = sprites[1]; //ollessaan aktiivinen, hakee tokan värin.
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "pikkukaveri")
        {
            ch.UpdateCheckpoints(this.gameObject);
            Changecolor();
        }
    }
}
