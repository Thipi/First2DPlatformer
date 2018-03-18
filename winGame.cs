using UnityEngine;
using System.Collections;

public class winGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pikkukaveri")
        {
            PelaajanTerveys kaveriVoittaa = other.gameObject.GetComponent<PelaajanTerveys>();
            kaveriVoittaa.winGame();
            Application.LoadLevel("sieniseikkailutaso2");
        }
    }
    }
