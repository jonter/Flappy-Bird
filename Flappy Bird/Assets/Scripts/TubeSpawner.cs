using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject tubesPrefab;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        BirdController bird = FindObjectOfType<BirdController>();
        bird.OnPlay += Spawn;
        
    }

    void Spawn()
    {
        float distance = Tubes.gapBetween;
        for (int i = 0; i < 3; i++)
        {
            GameObject clone = Instantiate(tubesPrefab);
            clone.transform.position = cam.transform.position
                + new Vector3(distance, 0, 10);
            distance += Tubes.gapBetween;

        }

    }

    
}
