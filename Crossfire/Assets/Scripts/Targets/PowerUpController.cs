using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    public IWeapon weapon {get; set;}

    private List<IWeapon> weapons = new List<IWeapon>();

    void Awake(){
        weapons.Add(new BaseWeapon());
        weapons.Add(new FanWeapon());
        weapons.Add(new RapidFireWeapon());
    }

    // Start is called before the first frame update
    void Start()
    {
        weapon = weapons[Random.Range(0, weapons.Count)];   
    }
}
