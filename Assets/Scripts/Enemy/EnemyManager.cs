using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    [SerializeField] GameObject enemy;
    float spawnTime = 5f;
    Transform[] spawnPoints;
    int n;

	// Use this for initialization
	void Start () {
        spawnPoints = GetComponentsInChildren<Transform>();
        n = spawnPoints.Length;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int idx = Random.Range(0, n);
        Instantiate(enemy, spawnPoints[idx].position, spawnPoints[idx].rotation);
    }
}
