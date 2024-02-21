using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private const float playerDistanceSpawnPlatform = 10f;
    [SerializeField] private Transform levelPart_start;
    [SerializeField] private List<Transform> LevelPart_List;
    [SerializeField] private Transform player;
    private Vector2 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = levelPart_start.Find("EndPosition").position;
        spawnLevelpart();
        spawnLevelpart();
        spawnLevelpart();

    }

    private void Update()
    {
        if (Vector2.Distance(player.position, lastEndPosition) < playerDistanceSpawnPlatform)
        {
            spawnLevelpart();
        }
    }

    private void spawnLevelpart()
    {
        Transform ChosenLevelPart = LevelPart_List[Random.Range(0, LevelPart_List.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(ChosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

    }

    private Transform SpawnLevelPart(Transform LevelPart, Vector2 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
