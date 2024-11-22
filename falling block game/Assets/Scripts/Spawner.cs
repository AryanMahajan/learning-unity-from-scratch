using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector2 secondsBeforeSpawnMinMax;
    float nextSpawnTime;

    public Vector2 spawnSizeMinMax;

    public float spawnAngleMax;

    public GameObject fallingBlockPrefab;

    Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime){

            float secondsBetweenSpawns = Mathf.Lerp(secondsBeforeSpawnMinMax.y, secondsBeforeSpawnMinMax.x,Difficulty.getDifficultyPercent ());

            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnSize = Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax,spawnAngleMax);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + (spawnSize / 2));
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            newBlock.transform.localScale = Vector2.one * spawnSize;

        }


    }
}
