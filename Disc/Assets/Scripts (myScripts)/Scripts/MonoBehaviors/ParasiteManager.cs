using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class ParasiteManager : MonoBehaviour {

    int sizeOfParasitePool = 30;
    List<GameObject> parasitePool = new List<GameObject>();
    GameObject parasitePrefab;
    ParasiteController[] parasiteControllers;
    Transform[] parasiteSpawnPoints; // TO DO when time...


    private void Start() {
        parasiteControllers = new ParasiteController[sizeOfParasitePool];
        parasitePrefab = FindObjectOfType<ParasiteController>().gameObject;
        for ( int i = 0 ; i < sizeOfParasitePool ; i++ ) {
            GameObject temp = Instantiate( parasitePrefab , Vector3.up * 3 , Quaternion.identity );
            temp.SetActive(true);
            temp.transform.parent = transform;
            parasiteControllers[i] = temp.GetComponent<ParasiteController>();
            parasitePool.Add( temp );
        }
    }

    private void Update() {
        for ( int i = 0 ; i < sizeOfParasitePool ; i++ ) {
            parasiteControllers[i].thisUpdate();
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