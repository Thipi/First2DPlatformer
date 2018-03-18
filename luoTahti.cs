using UnityEngine;
using System.Collections;

public class luoTahti : MonoBehaviour {

    bool activated = false;
    public Transform mihinLuodaan;
    public GameObject tahti;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "pikkukaveri" && !activated)
        {
            activated = true;
            Instantiate(tahti, mihinLuodaan.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
