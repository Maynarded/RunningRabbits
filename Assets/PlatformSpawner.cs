using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public PlatformPool platformPool;
    public Transform player;

    public float spawnInterval = 0.75f;

    public float stepXMin = 4.5f; // ← Adjust these as needed
    public float stepXMax = 4.5f;
    public float stepYRange = 1f;

    private float timer = 0f;
    private Vector3 lastPlatformPosition;
    private bool firstSpawn = true;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        GameObject platform = platformPool.GetPlatform();

        float spawnX, spawnY;

        if (firstSpawn)
        {
            spawnX = player.position.x + 4f;
            spawnY = -1f;
            firstSpawn = false;
        }
        else
        {
            float xStep = Random.Range(stepXMin, stepXMax);
            spawnX = lastPlatformPosition.x + xStep;

            float yStep = Random.Range(-stepYRange, stepYRange);
            spawnY = Mathf.Clamp(lastPlatformPosition.y + yStep, -2f, 2f); // prevent too high/low
        }

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        platform.transform.position = spawnPosition;

        lastPlatformPosition = spawnPosition;
    }
}
