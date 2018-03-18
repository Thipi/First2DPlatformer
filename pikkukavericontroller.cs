using UnityEngine;
using System.Collections;

public class pikkukavericontroller : MonoBehaviour
{

    //liikkumisvariablet
    public float maxSpeed; //nopeus
    Rigidbody2D myRB;   //kroppa eli pikkukaverin rigidbody
    Animator myAnim;    //Animaattorin määritys
    bool facingRight;   //katse oikeaan

    //hyppyvariablet
    bool maassa = false;
    float maassaRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform maassako;
    public float jumpHeight;

    //ampumista varten. 1.paikka, josta luodin lähtö. 2.luoti eli pikkutykki.3.koska saa ampua.4.koska saa ampua uudestaan.
    public Transform Nelio;
    public GameObject luoti;
    public float tulitusaika = 0.5f;
    public float seuraavatulitus = 0f;

    //kamera ZoomOut ja ZoomIn
    public float camSize;
    public float camSizeLimit;
    public float increment;
    public float timeLerp;
    public float timeLerpValue;

    public bool shouldZoomIm = false;
    public bool shouldZoomOut = false;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); //kutsutaan kroppaa
        myAnim = GetComponent<Animator>();  //Kutsutaan animaattoria ja animointia

        facingRight = true; //katse oikeaan on aluksi totta
    }

    // Update is called once per frame.Seuraavissa riveissä määritetään onko hyppy alkamassa.
    void Update()
    {
        if (maassa && Input.GetAxis("Jump") > 0)
        {
            maassa = false;
            myAnim.SetBool("onmaassa", maassa); //kutsutaan videota
            myRB.AddForce(new Vector2(0, jumpHeight)); //lisätään hyppyyn voimaa ja määritetään hypyn vektori

        }
            //pikkukaveri ampuu! PUFF!
            if(Input.GetAxisRaw("Fire1") > 0) Ammu();

        if (shouldZoomIm)
        {
            ZoomIn();
        }
        else if (shouldZoomOut)
        {
            ZoomOut();
        }

        camSize = Camera.main.fieldOfView;
        timeLerpValue = timeLerp * Time.deltaTime;
    }

    void FixedUpdate()
    {

        //Tarkistetaan ollaanko maassa. Jos ei niin pikkukaveri putoaa.
        maassa = Physics2D.OverlapCircle(maassako.position, maassaRadius, groundLayer);
        myAnim.SetBool("onmaassa", maassa);

        myAnim.SetFloat("verticalspeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal"); //liikkuminen tapahtuu horisontaalisesti
        myAnim.SetFloat("vauhti", Mathf.Abs(move)); //kun vauhtia tulee niin animaattori siirtyy seuraavaan animointiin. Vauhti määritetty
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); //lähtö eteenpäin

        if (move > 0 && !facingRight)
        { //jos katse on oikeaan niin...
            flip(); //kääntyy oikeaan
        }
        else if (move < 0 && facingRight)
        { //jos katse ei ole oikeaan
            flip(); //käänny
        }
    }

    void flip()
    { //luodaan funktio kääntymiselle
        facingRight = !facingRight; //katse oikeaan ei olekaan katse oikeaan
        Vector3 theScale = transform.localScale; //muutetaan suuntaa
        theScale.x *= -1;   //tapahtuu... jotain?
        transform.localScale = theScale; //muutetaan
    }

    //Ampumisen määrittely, eli  mistä ampuu. Suunta oikea ja ei oikeassa käännetään vector3:ssa syvyyttä 180 astetta.
    void Ammu(){
        if(Time.time > seuraavatulitus){
            seuraavatulitus = Time.time+tulitusaika;
            Debug.Log("amputulee");
            if (facingRight){ //mihin suuntaan pikkukaveri katsoo, sinne ammutaan. Instantiate asettaa suunnan ja lähtösijainnin.
                Instantiate(luoti, Nelio.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
            }else if(!facingRight){
                Instantiate(luoti, Nelio.position, Quaternion.Euler (new Vector3 (0, 0, 180f))); //kääntää rakettia 180 astetta.
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) //kun kohtaa tietyn asian, käyttäytyy seuraavasti. Tämä koodi on nyt ettei putoa liikkuvalta alustalta.
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform; //muuttaa hetkeksi liikkuvan alustan pikkukaverin "vanhemmaksi".
        }
    }

    void OnCollisionExit2D(Collision2D other) //kun poistuu liikkuvalta alustalta, MovingPlatform ei ole enää parent.
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "zoomInTrigger")
        {
            shouldZoomIm = true;
        }
        else if(col.gameObject.tag == "zoomOutTrigger")
        {
            shouldZoomOut = true;
        }
    }

    void ZoomOut()
    {
        if(Camera.main.fieldOfView < camSizeLimit)
        {
            Camera.main.fieldOfView =
                Mathf.Lerp(
                Camera.main.fieldOfView, 
                Camera.main.fieldOfView + increment, 
                timeLerp * Time.deltaTime);
        }
        else if(Camera.main.fieldOfView > camSizeLimit)
        {
            shouldZoomOut = false;
        }
    }

    void ZoomIn()
    {
        if (Camera.main.fieldOfView > 60)
        {
            Camera.main.fieldOfView =
                Mathf.Lerp(
                Camera.main.fieldOfView,
                Camera.main.fieldOfView + -increment,
                timeLerp * Time.deltaTime);
        }
        else if (Camera.main.fieldOfView < 60)
        {
            shouldZoomIm = false;
        }
    }
}