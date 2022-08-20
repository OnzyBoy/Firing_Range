using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;

    private float xSpawnPos = 16f;
    private float zSpawnRangeMin = 8f;
    private float zSpawnRangeMax = 24f;
    private float ySpawnPos = -0.74f;
    private float startTime = 1.0f;

    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("SpawnTargetPrefab", startTime, Random.Range(1,3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomSpawnPos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xSpawnPos, -xSpawnPos), ySpawnPos, Random.Range(zSpawnRangeMin, zSpawnRangeMax));
        return spawnPos;
        
    }
    void SpawnTargetPrefab()
    {
        Instantiate(targetPrefab, RandomSpawnPos(), targetPrefab.transform.rotation);
    }
}
