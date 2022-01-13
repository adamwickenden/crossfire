using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseWeapon : IWeapon
{
    private int maxBulletCount = 5;
    private int bulletsPerShot = 1;
    private float goalScaleFactor = 1.3f;
    private float bulletVelocity = 15f;

    public List<GameObject> Fire(Vector3 position, Vector3 direction)
    {
        GameObject load = Resources.Load("Prefabs/Ball") as GameObject;
        Vector3 spawn_pos = position + direction * 0.5f;
        GameObject ball = GameObject.Instantiate(load, spawn_pos, Quaternion.identity) as GameObject;

        Vector3 velocity = direction * bulletVelocity;

        ball.GetComponent<Rigidbody2D>().velocity = velocity;

        List<GameObject> balls = new List<GameObject>();
        balls.Add(ball);

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
