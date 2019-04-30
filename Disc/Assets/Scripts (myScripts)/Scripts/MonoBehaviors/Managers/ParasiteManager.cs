using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

//AI if using navmesh? But make sure to use Pooling. ánd make it work...

public class ParasiteManager : MonoBehaviour {

    public GameObject parasitePrefab;
    public Transform[] spawnPoints;

    private List<GameObject> parasitePool = new List<GameObject>();
    private ParasiteController[] parasiteControllers;
    private PlayerController playerController;

    private int sizeOfParasitePool = 5;

    private void Start() {

        playerController = GameManager.INSTANCE.playerController;
        parasiteControllers = new ParasiteController[sizeOfParasitePool];

        for ( int i = 0 ; i < sizeOfParasitePool ; i++ ) {

            GameObject temp = Instantiate( parasitePrefab , spawnPoints[Random.Range(0, spawnPoints.Length)].position , Quaternion.identity );

            temp.SetActive(true);
            temp.transform.parent = transform;

            parasiteControllers[i] = temp.GetComponent<ParasiteController>();
            parasitePool.Add( temp );
        }
    }

    private void Update() {

        for ( int i = 0 ; i < sizeOfParasitePool ; i++ ) {
            if( parasiteControllers[i].isActiveAndEnabled )
            parasiteControllers[i].thisUpdate( playerController.transform.position );
     
        }
    }

    public void ActivateParasite() {
        for ( int i = 0 ; i < sizeOfParasitePool ; i++ ) {

            GameObject temp = parasitePool[i];
            if ( !temp.activeInHierarchy ) {

                temp.SetActive( true );

            }
        }
    }

    public GameObject GetParasiteAtPosition(Vector3 position) {

        for (int i = 0 ;  i < sizeOfParasitePool ; i++ ) {

            GameObject temp = parasitePool[i];
            if ( !temp.activeInHierarchy ) {

                temp.SetActive(true);
                temp.transform.position = position;
                return temp;
            }
        }
        return null;
    }
}