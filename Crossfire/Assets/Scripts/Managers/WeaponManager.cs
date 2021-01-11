using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public int maxBulletCount { get; set; }
    public float goalScaleFactor { get; set; }

    public bool canFire { get; set; }

    public List<GameObject> activeBullets { get; set; }

    public GoalScale goal { get; set; }

    public IWeapon currentWeapon { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        currentWeapon = new BaseWeapon();
        activeBullets = new List<GameObject>();
        maxBulletCount = currentWeapon.GetTotalBullets();
        goalScaleFactor = currentWeapon.GetGoalScaleFactor();
    }

    // Update is called once per frame
    public void Fire(Vector3 position, Vector3 direction)
    {
        if (activeBullets.Count >= maxBulletCount)
        {
            Debug.Log("MaxBullets");
            return;
        }

        if (canFire)
        {
            GameObject bullet = currentWeapon.Fire(position, direction);
            bullet.GetComponent<BallController>().parentManager = this.GetComponent<WeaponManager>();

            goal.ScaleUp(goalScaleFactor);

            activeBullets.Add(bullet);
        }
    }
}
