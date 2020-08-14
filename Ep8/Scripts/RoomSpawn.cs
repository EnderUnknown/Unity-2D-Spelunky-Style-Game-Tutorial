using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public GameObject[] rooms;
    bool flag = false;

    void Update()
    {
        if (Generation.firstStageDone && !flag)
        {
            flag = true;
            //Generate Room
            int r = Random.Range(0, rooms.Length);
            Instantiate(rooms[r], transform);
        }
    }
}
