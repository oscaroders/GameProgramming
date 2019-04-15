using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MoveMaster, IParasiteAttack {

    private int health = 100;
    private int frameCount = 0;

    public Transform shootPoint;


    public List<ParasiteController> attackingParasites;
    public List<ParasiteController> GatheredParasites;
    public List<ParasiteController> shootParasites;


    public GameObject parasite;
    public Collider ignore;

    new readonly float jumpForce = 500;
    Vector3 v3 = new Vector3(0, 100, 0);

    public void Attack() {
        //Do stuff
    }

    public void DrainHealth() {
        foreach (ParasiteController pc in attackingParasites) {
            health--;
        }
    }

    public void Fire() {

        if (GatheredParasites[0] != null) {
            GatheredParasites[0].enabled = true;
            GatheredParasites[0].gameObject.SetActive(true);
            GatheredParasites[0].transform.position = shootPoint.position;
            GatheredParasites[0].GetComponent<Rigidbody>().AddForce(v3);
            GatheredParasites[0].speed = -5f;
            GatheredParasites[0].direction= -1f;
            shootParasites.Add(GatheredParasites[0]);
            GatheredParasites.Remove(GatheredParasites[0]);
        }
    }
    
    void Start() {
        attackingParasites = new List<ParasiteController>();
        GatheredParasites = new List<ParasiteController>();
        shootParasites = new List<ParasiteController>();

        for (int i = 0; i < 10; i++) {
            GatheredParasites.Add(Instantiate(parasite, transform.position, transform.rotation).GetComponent<ParasiteController>());
            GatheredParasites[i].gameObject.SetActive(false);
        }

    }

    private void Update() {

        this.MoveRound(-1f * 0.2f);

        if (health > 0) {
            if (frameCount % 60 == 0) {
                DrainHealth();
                //Debug.Log("EnemyHealth : " + health);
            }
        } else {

           //Debug.Log("EnemyDead");
            Destroy(this);
        }

        foreach (ParasiteController pc in shootParasites) {
            if (pc.enabled)
                pc.MoveRound(pc.direction * pc.speed);
        }

        frameCount++;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(TurnTriggerOff());
        }
    }

    IEnumerator TurnTriggerOff() {
        ignore.enabled = false;
        Fire();
        yield return new WaitForSeconds(3);
        ignore.enabled = true;
    }
}
