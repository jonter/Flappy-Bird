using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform bird;

    float offsetX;
    float scrollSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - bird.position.x;
        FindObjectOfType<BirdController>().OnDeath += DisableBack;
    }

    void DisableBack()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        offsetX -= Time.deltaTime * scrollSpeed;
        transform.position = new Vector3(bird.position.x + offsetX, 0, 10);

        if (offsetX <= -21.5f)
        {
            offsetX = 24.5f;
        }
    }
}
