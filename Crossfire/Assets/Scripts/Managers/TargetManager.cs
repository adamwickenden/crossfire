using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetManager
{

    public List<Vector3> spawnPositions = new List<Vector3>();
    public List<GameObject> spawnedTargets = new List<GameObject>();
    public Vector3 lastSpawnPosition;

    // Start is called before the first frame update
    public void InitialSpawn()
    {
        for (int i=-1; i <= 1; i++)
        {
            spawnPositions.Add(new Vector3(0f, i * 2f, -2f));

            Debug.Log(spawnPositions);

            InstantiateTarget(spawnPositions[i + 1]);
        }
    }

    // Update is called once per frame
    public void RespawnTargets()
    {
        if (spawnedTargets.Count < 3)
        {
            System.Random rnd = new System.Random();
            int idx = rnd.Next(0, 3);
            Vector3 position = spawnPositions[idx];

            InstantiateTarget(CheckPositionIntersection(position));
        }
    }

    public void InstantiateTarget(Vector3 position)
    {
        if (spawnedTargets.Count >= 3)
        {
            Debug.Log("Max Targets");
        }
        else
        {
            Debug.Log("Instantiating Target");
            GameObject load = Resources.Load("Prefabs/Target") as GameObject;
            GameObject target = GameObject.Instantiate(load, position, Quaternion.identity) as GameObject;
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
            int idx = rnd.Next(0, 3);
            Vector3 newPosition = spawnPositions[idx];

            // Recursively re-check
            position = CheckPositionIntersection(newPosition);
        }

        return position;
    }
}
