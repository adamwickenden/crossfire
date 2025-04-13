using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWeapon : IWeapon
{
    private int maxBulletCount = 6;
    private int bulletsPerShot = 5;
    private float goalScaleFactor = 1.3f;
    private float bulletVelocity = 15f;
    private float rotOffset = 20f;

    public List<GameObject> Fire(Vector3 position, Vector3 direction, float bulletScale)
    {
        List<GameObject> balls = new();
        // Rotate start dir in the negative direction by (offset * n_bullets / 2) 
        Vector3 start_dir = Quaternion.Euler(0,0, -rotOffset * (bulletsPerShot / 2f)) * direction * 1.5f;

        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject load = Resources.Load("Prefabs/Ball") as GameObject;

            // For each bullet, rotate in the positive direction by 1 unit of offset per bullet
            Vector3 spawn_dir = Quaternion.Euler(0,0, rotOffset*(i+1)) * start_dir;
            Vector3 spawn_pos = position + spawn_dir;

            GameObject ball = Object.Instantiate(load, spawn_pos, Quaternion.identity) as GameObject;

            Vector3 velocity = direction * bulletVelocity;

            ball.GetComponent<Rigidbody2D>().velocity = velocity;
            
            if (bulletScale != 1) 
            {
                ball.transform.localScale = new Vector3(1,1,1) * bulletScale;
                ball.GetComponent<Rigidbody2D>().mass = bulletScale;
            }
            
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
