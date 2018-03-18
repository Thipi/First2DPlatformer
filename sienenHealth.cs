using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sienenHealth : MonoBehaviour
{

    public float enemyMaxHealth;
    float currentHealth;

    public bool drops;
    public GameObject theDrop;

    public GameObject kuolemaFX;
    public AudioClip kiukkuSieni;
    public AudioClip kuolevaSieni;

    AudioSource sieniAudioS;

    //enemyhealthbar variables
    public Slider sieniSlider;


    // Use this for initialization
    void Start()
    {
        currentHealth = enemyMaxHealth;
        sieniSlider.maxValue = currentHealth;
        sieniSlider.value = currentHealth;

        sieniAudioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDamage(float damage)
    {
        sieniSlider.gameObject.SetActive(true); //asettaa Healthbarin näkyville. Poistettu näkyvistä Unityenginen puolella.
        currentHealth -= damage; //tämänhetkinen terveydentila miinus damage

        sieniSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
            sieniAudioS = GetComponent<AudioSource>();
            sieniAudioS.clip = kuolevaSieni;
            sieniAudioS.Play();
        }


        sieniAudioS.clip = kiukkuSieni;
        sieniAudioS.PlayOneShot(kiukkuSieni);

    }

    public void makeDead()
    {
        Destroy(gameObject);
        Instantiate(kuolemaFX, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
