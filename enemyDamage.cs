using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {

    public float damage;
    public float damageAjastus;
    public float pushBackForce; //vihollinen työntää pelaajaa kauemmas

    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "pikkukaveri" && nextDamage < Time.time)
        {
            PelaajanTerveys playerHealth = other.gameObject.GetComponent<PelaajanTerveys>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageAjastus;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized; //työntää pelaajaa päinvastaiseen suuntaan.
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>(); //asetettiin keho 0-asetuksille ettei painovoima vaikuta.
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse); //lähetetään tyyppi matkaan
    }
}
