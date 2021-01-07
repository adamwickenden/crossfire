using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public int maxBulletCount;

    public float goalScaleFactor;

    public List<GameObject> activeBullets;

    public goalScale goal;

    public IWeapon currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = new BaseWeapon();
        activeBullets = new List<GameObject>();
        maxBulletCount = currentWeapon.GetTotalBullets();
        goalScaleFactor = currentWeapon.GetGoalScaleFactor();
    }

    // Update is called once per frame
    public void Fire(Vector3 position, Vector3 direction)
    {
        if (activeBullets.Count < maxBulletCount)
        {
            GameObject bullet = currentWeapon.Fire(position, direction);
            bullet.GetComponent<BallController>().parentManager = this.GetComponent<WeaponManager>();

            goal.ScaleUp(goalScaleFactor);

            activeBullets.Add(bullet);
        }
        else
        {
            Debug.Log("MaxBullets");
        }
    }
}
