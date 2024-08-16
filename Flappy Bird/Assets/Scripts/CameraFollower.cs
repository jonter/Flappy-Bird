using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform bird;

    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - bird.position.x;
        FindObjectOfType<BirdController>().OnDeath += DisableCamera;
        
    }


    void DisableCamera()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(bird.position.x + offsetX, 0, -10);
    }
}
