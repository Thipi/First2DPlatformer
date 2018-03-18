using UnityEngine;
using System.Collections;

public class kiviController : MonoBehaviour {

    public float kiviVauhtiHigh;
    public float kiviVauhtiLow;
    public float kivenKulma;
    public float kiviTorgueKulma;

    Rigidbody2D kiviRB;

	// Use this for initialization
	void Start () {
        kiviRB = GetComponent<Rigidbody2D>();
        kiviRB.AddForce(new Vector2(Random.Range(-kivenKulma, kivenKulma), Random.Range(kiviVauhtiLow, kiviVauhtiHigh)), ForceMode2D.Impulse); //kun loppuun lisätään Forcemode.Impulse (impulse on mode) kivi lähtee räjähtämällä liikkeelle
        kiviRB.AddTorque(Random.Range(-kiviTorgueKulma, kiviTorgueKulma));
    }
	
	// Update is called once per frame
	void Update () {
	}
}
