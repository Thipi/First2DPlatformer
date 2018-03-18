using UnityEngine;
using System.Collections;

public class ammuKivi : MonoBehaviour {

    public GameObject Kivi;
    public float ampumisAika;
    public Transform shootFrom; //paikka, josta haluamme ampua. Sama ku pikkukaverin tykki.
    public int chanceShoot;
    public GameObject lehti;

    float nextShootTime;
    Animator tykkiAnim; 

	// Use this for initialization
	void Start () {
        tykkiAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "pikkukaveri" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + ampumisAika;
            if(Random.Range(0,10)<= chanceShoot)
            {
                Instantiate(Kivi, shootFrom.position, Quaternion.identity); //lopussa quaternion.identity = no rotation
                tykkiAnim.SetTrigger("cannonShoot");
                Instantiate(lehti, shootFrom.position, transform.rotation);
            }
        }
    }
}
