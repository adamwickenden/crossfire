using UnityEngine;
using System.Collections;

public class BaseWeapon : IWeapon
{

    private int maxBulletCount = 5;
    private float goalScaleFactor = 1.3f;
    private float bulletVelocity = 15f;

    public GameObject Fire(Vector3 position, Vector3 direction)
    {
        GameObject load = Resources.Load("Prefabs/Ball") as GameObject;
        Vector3 spawn_pos = position + direction * 0.5f;
        GameObject ball = GameObject.Instantiate(load, spawn_pos, Quaternion.identity) as GameObject;

        Vector3 velocity = direction * bulletVelocity;

        ball.GetComponent<Rigidbody2D>().velocity = velocity;

        return ball;
    }

    public int GetTotalBullets()
    {
        return maxBulletCount;
    }

    public float GetGoalScaleFactor()
    {
        return goalScaleFactor;
    }

}
