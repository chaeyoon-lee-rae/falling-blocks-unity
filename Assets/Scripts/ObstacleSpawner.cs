using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    float widthHalfSize, heightHalfSize;
    float offsetX, offsetY;

    float lastSpawnTime;
    
    public GameObject obstaclePrefab; // SerializeField?
    public Vector2 spawnSizeMinMax;
    public Vector2 timeBetweenSpawns;
    public float rotationMaxAngle;

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
        if (Time.time >= lastSpawnTime)
        {
            float secondsBtSpawns = Mathf.Lerp(timeBetweenSpawns.y, timeBetweenSpawns.x, Difficulty.GetDiffPct());
            lastSpawnTime = Time.time + secondsBtSpawns;

            float xScale = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float yScale = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            offsetX = xScale * 0.5f; 
            offsetY = yScale;

            float spawnAngle = Random.Range(-rotationMaxAngle, rotationMaxAngle);
            float posX = Random.Range(-widthHalfSize + offsetX, widthHalfSize - offsetX);
            float posY = heightHalfSize + offsetY;

            Vector2 pos = new Vector2(posX, posY);
            Quaternion rot = Quaternion.Euler(Vector3.forward * spawnAngle);
            GameObject obj = Instantiate(obstaclePrefab, pos, rot);

            obj.transform.localScale = new Vector2(xScale, yScale);

            obj.transform.parent = transform;
        }
    }
}
