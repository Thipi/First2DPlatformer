using UnityEngine;
using System.Collections;

public class kahvanKaanto : MonoBehaviour {

    bool kaantynyt = false;
    Animator kahvaKaantyy;

	// Use this for initialization
	void Start () {

        kahvaKaantyy = GetComponentInChildren<Animator>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "pikkukaveri")
        {
                kahvaKaantyy.SetTrigger("vaannetaan");
                kaantynyt = true;
                if (kaantynyt)
                {
                    kahvaKaantyy.SetTrigger("vaannetty");
                }
            }
        }

}
