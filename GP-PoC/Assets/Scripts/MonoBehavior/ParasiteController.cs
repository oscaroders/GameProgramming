using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteController : MoveMaster, IParasiteAttack
{   
    internal float direction =  -1;
    internal float speed = 0.4f;

    private void Start() {

        //direction = Mathf.Sign(Random.Range(-1, 1));
        //speed = Random.Range(1, 4);
        
    }

    public void Attack() {

    }

    public void DrainHealth() {

    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerController>().attackingParasites.Add(this);
            enabled = false;
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyController>().attackingParasites.Add(this);
            enabled = false;
            gameObject.SetActive(false);
        }
    }
}
