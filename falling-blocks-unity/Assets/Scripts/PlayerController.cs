using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float screenHalfX;
    float offsetX;

    public float speed;

    void Start()
    {
        offsetX = transform.localScale.x / 2;
        screenHalfX = Camera.main.aspect * Camera.main.orthographicSize - offsetX;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        float vel = dir * speed;
        transform.Translate(vel * Time.deltaTime * Vector3.right);

        if (transform.position.x >= screenHalfX)
            transform.position = new Vector2(screenHalfX, transform.position.y);
        else if (transform.position.x <= -screenHalfX)
            transform.position = new Vector2(-screenHalfX, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
