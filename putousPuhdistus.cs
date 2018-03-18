using UnityEngine;
using System.Collections;

public class putousPuhdistus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "pikkukaveri")
        {
            PelaajanTerveys kaveriPutosi = other.GetComponent<PelaajanTerveys>();
            kaveriPutosi.makeDead(); //kutsutaan PelaajanTerveys Scriptistä makeDead komentoa. Box Colliderissa Trigger päällä. 
        }
        else Destroy(other.gameObject);
    }
}
