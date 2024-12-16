using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        offsetY = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(7 * Time.deltaTime * Vector3.down);
        if (transform.position.y + offsetY < -Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
