using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour, IControl
{
    private bool fire = false;
    private float move = 0f;
    private Vector3 aim = Vector3.zero;
    private bool shield = false;
    private string aimType;

    private Transform body;

    public void Start()
    {
        body = gameObject.GetComponentInParent<PlayerManager>().player.gameObject.transform.Find("Body").gameObject.transform;
    }
    public bool Fire()
    {

        float val = Mathf.Sin(Time.time * 2);

        if (val > -0.02 && val < 0.02){
            fire = true;
        }
        else{
            fire = false;
        }
        return fire;
    }

    public bool Shield()
    {
        Vector3 targetPos = Vector3.zero;

        List<GameObject> t = SceneManager.Instance.targets.spawnedTargets;
        if (t.Count > 0){
            targetPos = t[0].gameObject.transform.position;
        }
        
        Vector3 myPos = gameObject.GetComponentInParent<PlayerManager>().player.gameObject.transform.Find("Body").gameObject.transform.position;

        if ((targetPos - myPos).magnitude < 1){
            shield = true;
        }
        else{
            shield = false;
        }
        return false;
    }

    public float Move()
    {
        List<GameObject> t = SceneManager.Instance.targets.spawnedTargets;
        if (t.Count > 0){
            move = t[0].gameObject.transform.position.y;
        }
        float pos = body.position.y;

        move = move - pos;

        return move;
    }

    public Vector3 Look()
    {

        List<GameObject> t = SceneManager.Instance.targets.spawnedTargets;
        if (t.Count > 0){
            aim = t[0].gameObject.transform.position;
            Vector2 temp = t[0].gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
            Vector3 pred = new Vector3(temp.x, temp.y, 0f) * 2f;
            aim = aim + pred;
        }

        return aim;
    }

    public bool AimType()
    {
        // Always return false because the AI can return a unit vector with which to aim the reticle
        return true;
    }

    public void KillFire()
    {
        fire = false;
    }
}
