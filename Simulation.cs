using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{

    [Header("Subjects")]
    [SerializeField] GameObject subjectPrefab;
    [SerializeField] GameObject infectorPrefab;
    [SerializeField] int subjectNumber = 50;
    [SerializeField] int infectorNumber = 1;


    void Start()
    {
        GenerateSubjects();
    }

    void GenerateSubjects()
    {
        for (int i = 0; i < subjectNumber; i++)
        {
            GameObject subject = Instantiate(subjectPrefab);

            subject.transform.position = getRandomPosition();
        }

        for (int i = 0; i < infectorNumber; i++)
        {
            GameObject infector = Instantiate(infectorPrefab);

            infector.transform.position = getRandomPosition();
        }

        Vector3 getRandomPosition()
        {
            float x = Random.Range(-49, 49);
            float z = Random.Range(49, -49);

            return new Vector3(x, 0.5f, z);
        }

    }
}
