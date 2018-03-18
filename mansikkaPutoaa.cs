using UnityEngine;
using System.Collections;

public class mansikkaPutoaa : MonoBehaviour {
    Rigidbody2D mansikkaRB;
    public float putoamisAika = 0.5f;
    bool steppedOn = false;
    float timer = 0f;
    public Canvas activateZ;

	// Use this for initialization
	void Start () {
        mansikkaRB = GetComponent<Rigidbody2D>();
        mansikkaRB.isKinematic = true;
        activateZ.enabled = false;

	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pikkukaveri")
        {
            steppedOn = true;
            activateZ.enabled = true;
        }

    }

    // Update is called once per frame
    void Update () {

        if (steppedOn && Input.GetAxis("Interact")>0)
        {
            activateZ.enabled = false;
            timer += Time.deltaTime;
            if(timer > putoamisAika)
            {
                mansikkaRB.isKinematic = false;
            }
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "pikkukaveri")
        {
            activateZ.enabled = false;
        }
    }
}
