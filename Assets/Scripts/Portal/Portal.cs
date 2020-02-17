﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public int lightYearChange = 2;


    [SerializeField]
    private int whereToGo;

    private Dictionary<int, int> pairs;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        pairs = new Dictionary<int, int>();
        CheckPortal();


    }

    void OnLevelWasLoaded(int level) {

        CheckPortal();
    }

    private void CheckPortal() {

        int tempIndex = SceneManager.GetActiveScene().buildIndex;
        if (pairs.ContainsKey(tempIndex)) {
            SetDestination(pairs[tempIndex]);
        } else {
            CreatePortal();
        }

    }

    private void CreatePortal() {

        int newWorld = -1;

        while (newWorld == -1 || (newWorld <= lightYearChange + 1 && newWorld > 0) || newWorld >= SceneManager.sceneCountInBuildSettings - lightYearChange) {


            if (gameObject.name == "Portal1") {
                newWorld = Random.Range(SceneManager.GetActiveScene().buildIndex - lightYearChange, SceneManager.GetActiveScene().buildIndex);
            } else if (gameObject.name == "Portal2") {
                newWorld = Random.Range(SceneManager.GetActiveScene().buildIndex + 1, SceneManager.GetActiveScene().buildIndex + lightYearChange + 1);
            } else {
                newWorld = Random.Range(SceneManager.GetActiveScene().buildIndex + 1, SceneManager.GetActiveScene().buildIndex + lightYearChange + 1);
            }

            if (newWorld >= SceneManager.sceneCountInBuildSettings - 2) {
                newWorld = SceneManager.GetActiveScene().buildIndex + 1;
                break;
            } else if (newWorld <= lightYearChange + 1) {
                newWorld = SceneManager.GetActiveScene().buildIndex - 1;
                break;
            }
        }


        SetDestination(newWorld);

        pairs.Add(SceneManager.GetActiveScene().buildIndex, newWorld);

    }




    private void SetDestination(int i) {
        whereToGo = i;
    }



    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(whereToGo);
        }
    }


}