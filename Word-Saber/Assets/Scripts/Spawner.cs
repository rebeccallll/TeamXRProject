using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPoints;
    [SerializeField] GameObject[] Letters;
    [SerializeField] GameObject Obstacle;
    public float beat;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {

            GameObject SpawnedLetter = Instantiate(Letters[Random.Range(0, 31)], SpawnPoints[Random.Range(0, 5)]);
            SpawnedLetter.transform.localPosition = Vector3.zero;
            timer -= beat;
        }

        timer += Time.deltaTime;


    }
}
