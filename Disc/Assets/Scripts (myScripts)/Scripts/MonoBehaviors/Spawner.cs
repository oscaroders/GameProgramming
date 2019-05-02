using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemySpawnerPrefab;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0 ; i < 2 * GameManager.INSTANCE.difficultyMultipier ; i++ ) {
            Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.Euler(0, Random.Range(0, 359), 0));
        }
    }
}