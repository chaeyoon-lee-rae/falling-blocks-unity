using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    float widthHalfSize, heightHalfSize;
    float offsetX, offsetY;

    float lastSpawnTime;
    const float timeBetweenSpawns = 0.7f;

    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0.0f;

        heightHalfSize = Camera.main.orthographicSize;
        widthHalfSize = heightHalfSize * Camera.main.aspect;

        offsetX = transform.localScale.x / 2;
        offsetY = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime >= timeBetweenSpawns)
        {
            lastSpawnTime = Time.time;

            float x = Random.Range(-widthHalfSize + offsetX, widthHalfSize - offsetX);
            float y = heightHalfSize + offsetY;
            Vector2 pos = new Vector2(x, y);
            GameObject obj = Instantiate(obstaclePrefab, pos, Quaternion.identity);

            obj.transform.parent = transform;
        }
    }
}
