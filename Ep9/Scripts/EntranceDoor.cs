using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    public GameObject player;
    public bool hasPlayerSpawned = false;
    public Transform spawnPos;
    void Update()
    {
        if(Generation.readyForPlayer && !hasPlayerSpawned)
        {
            //Spawn in player gameobject.
            Instantiate(player, spawnPos);
            hasPlayerSpawned = true;
        }
    }
}
