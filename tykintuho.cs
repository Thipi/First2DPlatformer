using UnityEngine;
using System.Collections;

public class tykintuho : MonoBehaviour {

    public float elinaika;

	// Use this for awake
	void Awake () {
        Destroy(gameObject, elinaika);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
