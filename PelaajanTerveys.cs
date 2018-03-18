using UnityEngine;
using System.Collections;
using UnityEngine.UI; //JOS KÄYTÄT GUIta muista lisätä tämä!

public class PelaajanTerveys : MonoBehaviour {

    //restart
    public checkpointHandler cpH;


    public float fullHealth;
    float currentHealth;
    pikkukavericontroller controlMovement;
    public GameObject kuolemaEfekti;
    public AudioClip kunSattuu;
    public AudioClip kunSattuuKaksi;

    AudioSource pelaajanAudioSource;

    //HUDvariables
    public Slider terveysSlider;
    public Image damageScreen; //veriroiskeframe
    public Text gameOverScreen;
    public Text winGameScreen;

    bool damaged = false; //luodaan vahingoittumisbool ja asetetaan se epätodeksi, sillä pelaaja ei ole alkuun vahingoittunut
    Color damageColor = new Color(1f, 0f, 0f, 0.5f); //tästä voi säätää damage-imagen puna, viher, sini ja Alpha-määrät.
    float smoothColor = 5f;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<pikkukavericontroller>();

        //HUD kaynnistys.Varmistetaan, että healthbarilla on se arvo, joka halutaan.
        terveysSlider.maxValue = fullHealth;
        terveysSlider.value = fullHealth;

        pelaajanAudioSource = GetComponent<AudioSource>(); //Kun haetaan komponenttia niin GetComponent<komponentti>() jne. esim ks rivi 25
        cpH = GetComponent<checkpointHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (damaged){
            damageScreen.color = damageColor; //käskee vaihtamaan damage-kuvaan (tai siis säätämään Alphan) heti kun on damagea.
        }
    	else        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime); //kun ei ole damagea siirtää takaisin smoothisti ks.deltaTime
        }
        damaged = false;
	}
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        pelaajanAudioSource.clip = kunSattuu;
        pelaajanAudioSource.clip = kunSattuuKaksi;
        pelaajanAudioSource.PlayOneShot(kunSattuu);
        

        terveysSlider.value = currentHealth; //näkyy nyt myös healthbarissa
        damaged = true;


        if (currentHealth<=0){
            makeDead();
        } 
    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount; //lisätään terveyttä
        if (currentHealth > fullHealth) currentHealth = fullHealth; //ei päästä lisättyä terveyttä yli maksimiterveyden
        terveysSlider.value = currentHealth;
    }
    public void makeDead()
    {
        Instantiate(kuolemaEfekti, transform.position, transform.rotation);
        damageScreen.color = damageColor;
        Debug.Log("IsDead");
    }

    public void winGame()
    {
        Destroy(gameObject);
        Animator winGameAnimator = winGameScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
    }
}
