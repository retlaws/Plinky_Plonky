using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject itemToSpawn;
    [SerializeField] int numberOfSpawnLocations = 10;
    [SerializeField] float spawnMultiplier = 3f;
    [SerializeField] int levelAtWhichToStartASpawning = 1; 

    PlayerLevelController playerLevelController;
    List<Vector2> spawnPos = new List<Vector2>();

    float spawnerWidth;
    float counter = 0;
    int playerLevel = 1; 

    private void Awake()
    {
        spawnerWidth = transform.localScale.x;
    }

    private void Start()
    {
        CalculateSpawnLocations();
        playerLevelController = FindObjectOfType<PlayerLevelController>();
        playerLevelController.updatePlayerLevel += UpdateScoreTracker;
    }

    private void OnDisable()
    {
        playerLevelController.updatePlayerLevel -= UpdateScoreTracker;
    }


    bool randomCalculated = false;
    float duration; 

    void Update()
    {
        if(playerLevel < levelAtWhichToStartASpawning) { return; }
        counter += Random.Range(1f * (playerLevel * spawnMultiplier), 10f * (playerLevel * spawnMultiplier)) * Time.deltaTime;

        if(randomCalculated == false)
        {
            duration = Random.Range(10f, 100f);
            randomCalculated = true; 
        }

        if(counter > duration)
        {
            randomCalculated = false; 
            counter = 0; 
            Spawn(); 
        }
    }

    private void Spawn()
    {
        int spawnLocation = Random.Range(0, numberOfSpawnLocations -1);
        Instantiate(itemToSpawn, spawnPos[spawnLocation], Quaternion.identity);
    }

    private void CalculateSpawnLocations()
    {
        float bayWidth = spawnerWidth / numberOfSpawnLocations;
        Vector2 start = new Vector2((transform.position.x - spawnerWidth / 2) + (bayWidth / 2), transform.position.y);

        for (int i = 0; i < numberOfSpawnLocations; i++)
        {
            spawnPos.Add(start + new Vector2(i * bayWidth, 0));
        }
    }

    public void UpdateScoreTracker(int level)
    {
        print(level);
        playerLevel = level; 
    }
}
