using UnityEngine;
using System.Collections;

public class pudotetaanläpi : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("siltaStop"), LayerMask.NameToLayer("pikkukaveri"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
