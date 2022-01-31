using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public bool humanControlled = true;
    [SerializeField]
    public GameObject player;

    private GameObject human;
    private GameObject ai;

    void Awake()
    {
        human = gameObject.transform.Find("Human").gameObject;
        ai = gameObject.transform.Find("AI").gameObject;

        if (humanControlled){
            human.SetActive(true);
            player.GetComponentInChildren<Player>().control = human.GetComponent<IControl>();
        }
        else{
            ai.SetActive(true);
            player.GetComponentInChildren<Player>().control = ai.GetComponent<IControl>();
        }
    }
}
