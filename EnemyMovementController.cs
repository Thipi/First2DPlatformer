using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {

    public float vihollisenNopeus;
    Animator vihollisenAnimator;

    //suunta 
    public GameObject vihollisenGrafiikka;
    bool voiKaantya = true;
    bool facingRight = false;
    float kaantymisAika = 3f; //joka kolmas sekunti tuhma liisko voi kääntyä ja katsoa toiseen suuntaan.
    float seuraavaKaantyminen = 0f;

    //hyökkäystä varten
    public float hyokkaysAika; //jotta Pikkukaverilla on hetki aikaa pelastautua yms
    float aloitusHyokkaysAika;
    bool hyokkaa; //bool on aina true tai false. Eli kun bool on true, lisko hyökkää
    Rigidbody2D vihollisRB;

    // Use this for initialization
    void Start() {
        vihollisenAnimator = GetComponentInChildren<Animator>(); //Animaattori on ala-sarakkeessa hierarkiassa, joten tällä komennolla kutsutaan animaattoria.
        vihollisRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > seuraavaKaantyminen){
            if(Random.Range (0,10)>= 3) flipFacing();
            seuraavaKaantyminen = Time.time + kaantymisAika;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "pikkukaveri"){
            if (facingRight && other.transform.position.x <= transform.position.x){
                flipFacing();
            } else if(!facingRight && other.transform.position.x >= transform.position.x) {
                flipFacing();
            }
            voiKaantya = false;
            hyokkaa = true;
            aloitusHyokkaysAika = Time.time + hyokkaysAika; //tämä antaa pikkukaverilla pienen hetken reagoida

    }
}



    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "pikkukaveri")
        {
            if (aloitusHyokkaysAika < Time.time)
            {
                if (!facingRight) vihollisRB.AddForce(new Vector2(-1, 0) * vihollisenNopeus);
                else vihollisRB.AddForce(new Vector2(1, 0) * vihollisenNopeus); }
            vihollisenAnimator.SetBool("isCharging", hyokkaa);

        
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "pikkukaveri"){
            voiKaantya = true;
            hyokkaa = false;
            vihollisRB.velocity = new Vector2(0f, 0f);
            vihollisenAnimator.SetBool("isCharging", hyokkaa);
        }
    }

    void flipFacing() //eli  nyt käännetään liskoa
    {
        if (!voiKaantya) return;
        float facingX = vihollisenGrafiikka.transform.localScale.x; //mihin suuntaan on kääntynyt
        facingX *= -1f; //kääntää automaattisesti päinvastaiseen suuntaan
        vihollisenGrafiikka.transform.localScale = new Vector3(facingX, vihollisenGrafiikka.transform.localScale.y, vihollisenGrafiikka.transform.localScale.z);
        facingRight = !facingRight;
    }
}
