using UnityEngine;
using System.Collections;

public class tykkiosuma : MonoBehaviour {

    public float osumavahinko;
    projectilecontroller myPC;
    public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<projectilecontroller>();

	}
	
	// Update is called once per frame
	void Update () {
	
	} //when the  collider collides with other collider, the other collider will provide information
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == LayerMask.NameToLayer("ammuttava")) //layermask antaa tiedon,että objektia voi ampua. Muista lisätä layermask ammuttaviin objekteihin.
        {
            myPC.poistaliikkuvuus();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(osumavahinko);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ammuttava")) //layermask antaa tiedon,että objektia voi ampua. Muista lisätä layermask ammuttaviin objekteihin.
        {
            myPC.poistaliikkuvuus();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(osumavahinko);
            }
        }

    }
}
