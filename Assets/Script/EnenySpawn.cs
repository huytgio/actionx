using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenySpawn : MonoBehaviour
{
    public List<GameObject> Enemy = new List<GameObject>();
    public float Spawnrate;
    private float x, y,z;
    private Vector3 spawnpos;

    private void Start()
    {
        StartCoroutine(SpawnTestEnemy());

    }

    IEnumerator SpawnTestEnemy()
    {
        x = Random.Range(-1,1);
        y = Random.Range(-1,1);
        
        spawnpos.x += x/5;
        spawnpos.y += y/5;
        spawnpos.z = 0;
        Instantiate(Enemy[0], transform.position + spawnpos, Quaternion.identity);
        yield return new WaitForSeconds(Spawnrate);
        StartCoroutine(SpawnTestEnemy());
    }
}
