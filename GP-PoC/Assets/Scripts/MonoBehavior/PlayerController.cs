using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MoveMaster, IParasiteAttack
{
    private int health = 100;
    private int frameCount = 0;

    [HideInInspector]
    public List<ParasiteController> attackingParasites;
    [HideInInspector]
    public List<ParasiteController> GatheredParasites;

    new readonly float jumpForce = 500;
    Vector3 v3 = new Vector3(0, 200, 0);
    public Transform shootPoint;

    public void Attack() {
        //Do stuff
    }

    public void DrainHealth() {
        foreach (ParasiteController pc in attackingParasites) {
            health--;
        }
    }

    public void Fire() {

        if(GatheredParasites[0] != null) {
            GatheredParasites[0].enabled = true;
            GatheredParasites[0].gameObject.SetActive(true);
            GatheredParasites[0].transform.position = shootPoint.position;
            GatheredParasites[0].GetComponent<Rigidbody>().AddForce(v3);
            GatheredParasites[0].speed = 5f;
            GatheredParasites.Remove(GatheredParasites[0]);
        }
    }

    void Start() {
        attackingParasites = new List<ParasiteController>();
        GatheredParasites = new List<ParasiteController>();

    }

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.CompareTag("Par")) {
                    GatheredParasites.Add(hit.transform.GetComponent<ParasiteController>());
                    hit.transform.GetComponent<ParasiteController>().enabled = false;
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }

        if (health > 0) {
            if(frameCount % 60 == 0) {
                DrainHealth();
               // Debug.Log("Health : " + health);
            }
        } else {
           // Debug.Log("PlayerDead");
        }
        frameCount++;
    }
}
