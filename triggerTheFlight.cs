using UnityEngine;
using System.Collections;

public class triggerTheFlight : MonoBehaviour {

    public GameObject platform;
    public float moveSpeed;
    Transform currentPoint;
    public Transform[] points; //neliöhakasilla saadaan käyttöön pointArray Unity editorin puolella
    public int pointSelection;

    bool kyydissa = false;

    // Use this for initialization
    void Start () {

        currentPoint = points[pointSelection];

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pikkukaveri")

        {
            Debug.Log("kyydissa");
            kyydissa = true;
        }
    }

    // Update is called once per frame
    void Update () {

        if (kyydissa) { 
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed); //liikuttaa platformia

            if (platform.transform.position == currentPoint.position)
            {
                pointSelection++;

                if (pointSelection == points.Length) //mikäli menee yli point-määrän (ks. pointArray) Tsekkaa siis ollaanko menty yli annetun PointArray-määrän.
                {
                    pointSelection = 0; //kun menee numeroon 2, huomaa et apua meni yli ja loikkaa takas nollaan
                }

                currentPoint = points[pointSelection];
            }
        }

    }
}




