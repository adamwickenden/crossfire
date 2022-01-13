using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RapidFireWeapon : IWeapon
{
    private int maxBulletCount = 10;
    private int bulletsPerShot = 5;
    private float goalScaleFactor = 1.3f;
    private float bulletVelocity = 15f;

    public List<GameObject> Fire(Vector3 position, Vector3 direction)
    {
        List<GameObject> balls = new List<GameObject>();
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject load = Resources.Load("Prefabs/Ball") as GameObject;
            Vector3 spawn_pos = position + (2 * direction/bulletsPerShot * (i+1));
            GameObject ball = GameObject.Instantiate(load, spawn_pos, Quaternion.identity) as GameObject;

            Vector3 velocity = direction * bulletVelocity;

            ball.GetComponent<Rigidbody2D>().velocity = velocity;
            balls.Add(ball);
        }

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
