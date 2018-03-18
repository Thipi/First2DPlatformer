using UnityEngine;
using System.Collections;

public class siltaAlas : MonoBehaviour {
    Rigidbody2D siltaRB;
    bool korissa = false;

    // Use this for initialization
    void Start () {
        siltaRB = GetComponent<Rigidbody2D>();
        siltaRB.isKinematic = true;
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("mansikka"))
        {
            korissa = true;
            Debug.Log("mansikkaBongattu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (korissa)
        {
            siltaRB.isKinematic = false;
        }
        }
    }


