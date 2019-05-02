using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public Collider triggerBox;
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    private GameObject spawnedEnemy;

    private void OnTriggerEnter( Collider other ) {

        if ( spawnedEnemy == null ) {
            if ( other.CompareTag( "Player" ) ) {
                spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}