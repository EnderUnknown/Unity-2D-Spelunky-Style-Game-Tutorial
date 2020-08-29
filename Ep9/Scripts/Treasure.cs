using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int value;

    public void OnCollide(bool isPlayer)
    {
        if (isPlayer)
        {
            PlayerData.gold += value;
            Destroy(gameObject);
        }
    }
}
