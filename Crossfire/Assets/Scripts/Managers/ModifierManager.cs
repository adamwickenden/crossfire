using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager
{
    private float xLim = 7f;
    private float yLim = 4f;
    private List<GameObject> activeModifiers = new List<GameObject>();

    public int modifierCount = 2;
    public float spawnChance = 0.0005f;

    public void RespawnModifiers()
    {
        // Whilst there are less than 2 active powerups, we have a % chance to spawn a new one
        if (activeModifiers.Count < modifierCount)
        {
            int x = Random.Range(0, 2);
            switch (x)
            {
                case 0:
                    SpawnModifier(spawnChance, "Prefabs/PowerUp");
                    break;
                case 1:
                    SpawnModifier(spawnChance, "Prefabs/Modifier");
                    break;
            }
        }
    }

    private void SpawnModifier(float chance, string prefabPath)
    {
        float rand = Random.Range(0f, 1f);

        if (rand <= chance)
        {
            float x = Random.Range(-xLim, xLim);
            float y = Random.Range(-yLim, yLim);

            Vector3 spawnPos = new Vector3(x, y, 0f);

            GameObject load = Resources.Load(prefabPath) as GameObject;
            GameObject modifierObject = Object.Instantiate(load, spawnPos, Quaternion.identity);

            activeModifiers.Add(modifierObject);
        }
    }

    public void RemoveModifier(GameObject modifierObject)
    {
        activeModifiers.Remove(modifierObject);
    }
    
    public void DestroyVisibleModifiers()
    {
        foreach (GameObject modifierObject in activeModifiers)
        {
            if (modifierObject.GetComponent<SpriteRenderer>().isVisible)
            {
                Object.Destroy(modifierObject);
            }
        }
        activeModifiers.Clear();
    }
}
