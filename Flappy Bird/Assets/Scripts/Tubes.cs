using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubes : MonoBehaviour
{
    Transform tubeUp;
    public static float gapBetween = 5;
    Camera cam;
    public static float tubeDistance = 6.5f;
    public static float randomY = 2.5f;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        tubeUp = transform.GetChild(0);
        SetGap(tubeDistance);
    }

    public void SetGap(float distance)
    {
        tubeUp.localPosition = new Vector3(0, distance, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToCamera = cam.transform.position.x - transform.position.x;
        if(distanceToCamera > 4)
        {
            transform.position += new Vector3(gapBetween * 3, 0, 0);
            SetGap(tubeDistance);
            float r = Random.Range(-randomY, randomY);
            transform.position = new Vector3(transform.position.x, r, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreManager>().IncreaseScore();
    }
}
