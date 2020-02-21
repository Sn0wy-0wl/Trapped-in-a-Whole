﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPortalManager : MonoBehaviour {



    //public static TutorialPortalManager Instance;


    public Transform[] p;



    GameObject portal1;
    GameObject portal2;
    GameObject portal3;
    GameObject portal4;

    //private void Awake() => Instance = this;
    void Start() {

        portal1 = GameObject.Find("Portal1");
        portal2 = GameObject.Find("Portal2");
        portal3 = GameObject.Find("Portal3");
        portal4 = GameObject.Find("Portal4");


        if (SceneManager.GetActiveScene().buildIndex < 1 || SceneManager.GetActiveScene().buildIndex > 20) {
            Destroy(portal1);
            Destroy(portal2);
            Destroy(portal3);
            Destroy(portal4);
        }

        PortalSetup();

    }



    public void ActivatePortals() {
        portal1.GetComponent<TutorialPortal>().ActivateMe();
        portal2.GetComponent<TutorialPortal>().ActivateMe();
        portal3.GetComponent<TutorialPortal>().ActivateMe();
        portal4.GetComponent<TutorialPortal>().ActivateMe();
    }





    void PortalSetup() {

            if (portal1 == null)
                return;

            if (p.Length >= 2) {
                portal1.transform.position = p[0].position;
                portal1.transform.rotation = p[0].rotation;

                portal2.transform.position = p[1].position;
                portal2.transform.rotation = p[1].rotation;

                portal3.transform.position = new Vector2(-10000, -10000);
                portal4.transform.position = new Vector2(-10000, -10000);

            }
            if (p.Length == 3) {

                portal3.transform.position = p[2].position;
                portal3.transform.rotation = p[2].rotation;

            }
            if (p.Length == 4) {

                portal4.transform.position = p[3].position;
                portal4.transform.rotation = p[3].rotation;

                portal3.transform.position = p[2].position;
                portal3.transform.rotation = p[2].rotation;

            }



        portal1.GetComponent<BoxCollider2D>().enabled = false;
        portal2.GetComponent<BoxCollider2D>().enabled = false;
        portal3.GetComponent<BoxCollider2D>().enabled = false;
        portal4.GetComponent<BoxCollider2D>().enabled = false;

    }







}