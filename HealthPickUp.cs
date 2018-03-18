using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
    public float healthAmount;

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
            PelaajanTerveys theHealth = other.gameObject.GetComponent<PelaajanTerveys>(); //reference to PelaajanTerveys-script
            theHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
