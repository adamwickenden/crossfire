using UnityEngine;
using System.Collections.Generic;

public class BaseWeapon : IWeapon
{
    private int maxBulletCount = 5;
    private int bulletsPerShot = 1;
    private float goalScaleFactor = 1.3f;
    private float bulletVelocity = 15f;

    public List<GameObject> Fire(Vector3 position, Vector3 direction, float bulletScale)
    {
        GameObject load = Resources.Load("Prefabs/Ball") as GameObject;
        Vector3 spawn_pos = position + direction * 0.5f;
        GameObject ball = Object.Instantiate(load, spawn_pos, Quaternion.identity); 

        Vector3 velocity = direction * bulletVelocity;

        ball.GetComponent<Rigidbody2D>().velocity = velocity;

        if (bulletScale != 1) 
        {
            ball.transform.localScale = new Vector3(1,1,1) * bulletScale;
            ball.GetComponent<Rigidbody2D>().mass = bulletScale;
        }

        List<GameObject> balls = new() { ball };
        
        return balls;
    }

    public int GetTotalBullets()
    {
        return maxBulletCount;
    }

    public int GetBulletsPerShot()
    {
        return bulletsPerShot;
    }

    public float GetGoalScaleFactor()
    {
        return goalScaleFactor;
    }

}
