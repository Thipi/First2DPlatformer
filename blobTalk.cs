using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class blobTalk : MonoBehaviour {

    Animator talkingBlob;
    public Canvas talkText;



	// Use this for initialization
	void Start () {
        talkingBlob = GetComponent<Animator>();
        talkText.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pikkukaveri")
        {
            talkingBlob.SetBool("triggerTalk", true);
            talkText.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "pikkukaveri")
        {
            talkingBlob.SetBool("triggerTalk", false);
                talkText.enabled = false;
        }
    }
}
