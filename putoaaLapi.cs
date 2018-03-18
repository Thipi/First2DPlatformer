using UnityEngine;
using System.Collections;

public class putoaaLapi : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("ammuttava"), LayerMask.NameToLayer("ammuttava"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
