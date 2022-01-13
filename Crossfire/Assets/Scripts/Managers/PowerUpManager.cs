using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager
{
    private float spawnChance;
    private float xLim = 7f;
    private float yLim = 4f;
    private List<GameObject> activePowerUps = new List<GameObject>();

    public PowerUpManager(float spawnChance)
    {
        this.spawnChance = spawnChance;
    }

    // Update is called once per frame
    public void RespawnPowerUps()
    {
        // Whilst there are less than 2 active powerups, we have a % chance to spawn a new one
        if (activePowerUps.Count < 2)
        {
            SpawnPowerUp(spawnChance);
        }
    }

    private void SpawnPowerUp(float chance)
    {
        float rand = Random.Range(0f, 1f);

        if (rand <= chance)
        {
            float x = Random.Range(-xLim, xLim);
            float y = Random.Range(-yLim, yLim);

            Vector3 spawnPos = new Vector3(x, y, 0f);

            GameObject load = Resources.Load("Prefabs/PowerUp") as GameObject;
            GameObject powerUp = GameObject.Instantiate(load, spawnPos, Quaternion.identity) as GameObject;

            activePowerUps.Add(powerUp);
        }
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        activePowerUps.Remove(powerUp);
    }

}
