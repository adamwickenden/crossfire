using System.Collections.Generic;
using UnityEngine;

public class TargetManager
{

    public List<Vector3> spawnPositions = new List<Vector3>();
    public List<GameObject> spawnedTargets = new List<GameObject>();
    public Vector3 lastSpawnPosition;
    public int targetLimit;

    public TargetManager(int limit)
    {
        this.targetLimit = limit;
    }

    // Initial spawn for start of game, called in awake
    public void InitialSpawn()
    {
        for (int i=0; i < targetLimit; i++)
        {
            int centreOffset = Mathf.FloorToInt(targetLimit / 2);

            spawnPositions.Add(new Vector3(0f, (i - centreOffset) * 2 , 0f));

            InstantiateTarget(spawnPositions[i]);
        }
    }

    // Respawns targets when they are less than the targetLimit
    public void RespawnTargets()
    {
        if (spawnedTargets.Count < targetLimit)
        {
            System.Random rnd = new System.Random();
            int idx = rnd.Next(0, targetLimit);
            Vector3 position = spawnPositions[idx];

            InstantiateTarget(CheckPositionIntersection(position));
        }
    }

    public void InstantiateTarget(Vector3 position)
    {
        if (spawnedTargets.Count >= targetLimit)
        {
            Debug.Log("Max Targets");
        }
        else
        {
            GameObject load = Resources.Load("Prefabs/Target") as GameObject;
            GameObject target = Object.Instantiate(load, position, Quaternion.identity) as GameObject;
            spawnedTargets.Add(target);
        }
    }

    public void RemoveTarget(GameObject target)
    {
        spawnedTargets.Remove(target);
    }

    private Vector3 CheckPositionIntersection(Vector3 position)
    {
        bool intersects = false;

        // Loop through all currently spawned objects and check if there is intersection
        for (int i = 0; i < spawnedTargets.Count; i++)
        {
            if (spawnedTargets[i].GetComponent<Collider2D>().bounds.Contains(position))
            {
                intersects = true;
            }
        }

        // If there is an intersection select new random position from list 
        if (intersects)
        {
            System.Random rnd = new System.Random();
            int idx = rnd.Next(0, targetLimit);
            Vector3 newPosition = spawnPositions[idx];

            // Recursively re-check
            position = CheckPositionIntersection(newPosition);
        }
        return position;
    }
}
