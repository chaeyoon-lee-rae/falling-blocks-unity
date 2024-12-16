using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    float screenHalf;
    float offset;

    void Start()
    {
        offset = transform.localScale.x / 2;
        screenHalf = Camera.main.aspect * Camera.main.orthographicSize - offset; // (height / 2)
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        float vel = dir * speed;
        transform.Translate(vel * Time.deltaTime * Vector3.right);

        if (transform.position.x >= screenHalf)
            transform.position = new Vector2(screenHalf, transform.position.y);
        else if (transform.position.x <= -screenHalf)
            transform.position = new Vector2(-screenHalf, transform.position.y);
    }
}
