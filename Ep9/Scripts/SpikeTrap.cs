using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float downwardForce;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<LivingBase>() && col.gameObject.GetComponent<PlayerController>().GetVelocity().y < downwardForce)
        {
            col.GetComponent<LivingBase>().OnDeath();
        }
    }
}
