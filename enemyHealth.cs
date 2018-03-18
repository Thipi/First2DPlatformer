using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    float currentHealth;

    public bool drops;
    public GameObject theDrop;

    public GameObject enemykuolemaEfekti;
    public AudioClip vihainenSieni;
    public AudioClip dyingEnemy;

    AudioSource sienenAudioSource;

    //enemyhealthbar variables
    public Slider enemySlider;


    // Use this for initialization
    void Start () {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;

        sienenAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true); //asettaa Healthbarin näkyville. Poistettu näkyvistä Unityenginen puolella.
        currentHealth -= damage; //tämänhetkinen terveydentila miinus damage

        enemySlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
            sienenAudioSource = GetComponent<AudioSource>();
            sienenAudioSource.clip = dyingEnemy;
            sienenAudioSource.Play();
        }


            sienenAudioSource.clip = vihainenSieni;
        sienenAudioSource.PlayOneShot(vihainenSieni);

    }

   public void makeDead()
    {
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(enemykuolemaEfekti, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
