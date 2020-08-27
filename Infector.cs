using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infector : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] Material immune;

    [SerializeField] float maxSpeed = 5f;

    [SerializeField] float changeTime = 2f;

    [SerializeField] [Range(0f, 100f)] float chance;

    [SerializeField] int timeOfRecovery = 10;

    bool wasInfected = false;

    bool isSick = true;
    bool isImmune = false;

    Renderer rend;

    private float timeLeft;

    Rigidbody rb;

    Vector3 movement;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            movement = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

            timeLeft += changeTime;
        }

        rb.AddForce(movement * maxSpeed);

        if (isSick && !wasInfected)
        {
            StartCoroutine(Recovery());
        }

        if (isImmune)
        {
            rend.material = immune;
        }
    }


    IEnumerator Recovery()
    {
        wasInfected = true;

        yield return new WaitForSeconds(timeOfRecovery);

        float randomNumber = Random.Range(0f, 100f);

        if (randomNumber < chance)
        {
            Destroy(gameObject);
        }
        else
        {
            isImmune = true;
            isSick = false;

            gameObject.tag = "Immune";
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            movement = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        }
    }
}
