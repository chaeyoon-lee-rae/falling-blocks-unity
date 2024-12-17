using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveObstacle : MonoBehaviour
{
    float offsetY;

    public Vector2 speedMinMax;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        offsetY = transform.localScale.y;

        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDiffPct());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down, Space.World);
        if (transform.position.y + offsetY < -Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
