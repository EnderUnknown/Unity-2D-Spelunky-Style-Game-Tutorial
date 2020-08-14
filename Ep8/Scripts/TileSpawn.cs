using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] tileSpawns;

    void Start()
    {
        int r = Random.Range(0, tileSpawns.Length);
        if (tileSpawns[r] != null)
        {
            GameObject go = Instantiate(tileSpawns[r], transform);
            Generation.tileDict.Add(go.transform.position, go);
        }
    }
}
