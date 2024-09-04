using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
namespace OculusSampleFramework {
    [Serializable]
    public class RecipeCoreClass {
        public string recipeName;
        public List<string> CorrectIngridiants = new List<string>();
    }

    public class GameManager : MonoBehaviour {

        public static GameManager instance;

        [Header("CoreVariables")]
        public string stringCategory;
        public string stringSubCategory;

        [Header("Recipe Object")]
        public List<RecipeCoreClass> RecipeName = new List<RecipeCoreClass>();

        [Header("FinalProduct")]
        public List<GameObject> finalProducts = new List<GameObject>();

        [Header("AllSubProduct")]
        public List<GameObject> allSubProducts = new List<GameObject>();

        [Header("FinalBowl")]
        public GameObject finalBowl;

        [Header("CollectionCounter")]
        public int totalNumberOfCollections;
        public int currentCollections;

        [Header("CoreObject")]
        public bool isGameStart;
        public bool isGameEnd;

        [Header("CurrentDragableObject")]
        public GameObject currentDragableObject;

        private void Awake() {
            instance = this;
            finalBowl.SetActive(false);
            totalNumberOfCollections = 10;
            for (int i = 0; i < finalProducts.Count; i++) {
                finalProducts[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < allSubProducts.Count; i++) {
                allSubProducts[i].gameObject.SetActive(false);
            }
        }


        private void Update() {
            if (OVRGrabber.isdrop) {
                SetDragableObjectIntoBowl();
                OVRGrabber.isdrop = false;
            }
            if (isGameStart && !isGameEnd) {
                if (currentCollections >= totalNumberOfCollections) {
                    UIController.instance.OnGameEnd();
                }
            }
        }

        public void OnGameStart() {
            isGameStart = true;
            isGameEnd = false;
            finalBowl.SetActive(true);
            allSubProducts[0].gameObject.SetActive(true);
        }

        public void SetDragableObjectIntoBowl() {
            currentCollections++;
            currentDragableObject = OVRGrabber.currentDragableObject;
            //obj = currentDragableObject;
            currentDragableObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            currentDragableObject.transform.parent = finalBowl.gameObject.transform;
            currentDragableObject.transform.localPosition = new Vector3(0, 0, 0);
            currentDragableObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        }


        public void OnGameEnd() {
            for (int i = 0; i < finalProducts.Count; i++) {
                finalProducts[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < allSubProducts.Count; i++) {
                allSubProducts[i].gameObject.SetActive(false);
            }
        }
    }
}