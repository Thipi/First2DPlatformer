using UnityEngine;
using System.Collections;

public class projectilecontroller : MonoBehaviour
{

    Rigidbody2D myRB;
    public float tykkivauhti;

    // Awake käynnistyy objektin "herätessä"
    void Awake()
    {
        {
            myRB = GetComponent<Rigidbody2D>();
            if (transform.localRotation.z > 0)
                myRB.AddForce(new Vector2(-1, 0) * tykkivauhti, ForceMode2D.Impulse);
            else myRB.AddForce(new Vector2(1, 0) * tykkivauhti, ForceMode2D.Impulse);
        }
    }

    public void poistaliikkuvuus()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
