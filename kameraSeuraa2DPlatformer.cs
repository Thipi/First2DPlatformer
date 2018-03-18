using UnityEngine;
using System.Collections;

public class kameraSeuraa2DPlatformer : MonoBehaviour {

    public Transform kohde; //mitä kamera seuraa
    public float smoothing; //kuinka nopeasti kamera seuraa yms. dampening-effect
    Vector3 offset; //kameran ja hahmon ero. Kameran on pysyttävä tietyllä etäisyydellä pelaajasta
    float lowY; // alin kohta johon kamera voi mennä


	// Use this for initialization
	void Start () {
        offset = transform.position - kohde.position;

        lowY = transform.position.y;
	}

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetCamPos = kohde.position + offset; //Antaa tiedon mihin kamera haluaa sijoittua
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); //jos deltaTimea ei olisi, liike olisi nopeaa
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z); //jos liike menee alle y:n, seuraa vain x:ää ja z:aa ja asetu alaY:hyn
    }
    }
    

