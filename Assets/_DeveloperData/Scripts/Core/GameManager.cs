using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;
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

        [Header("Particals List")]
        public List<GameObject> allTheParticals = new List<GameObject>();

        private void Awake() {
            instance = this;
            finalBowl.SetActive(false);
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
            if (string.Equals(stringSubCategory, "Chocolate Cake")) {
                totalNumberOfCollections = 9;
                allSubProducts[0].gameObject.SetActive(true);
            }
            if (string.Equals(stringSubCategory, "Chocolate Truffles")) {
                totalNumberOfCollections = 2;
                allSubProducts[1].gameObject.SetActive(true);
            }
            if (string.Equals(stringSubCategory, "Mawa Modak")) {
                totalNumberOfCollections = 5;
                allSubProducts[2].gameObject.SetActive(true);
            }
            if (string.Equals(stringSubCategory, "Rice Kheer")) {
                totalNumberOfCollections = 5;
                allSubProducts[3].gameObject.SetActive(true);
            }
            if (string.Equals(stringSubCategory, "Pancake")) {
                totalNumberOfCollections = 12;
                allSubProducts[4].gameObject.SetActive(true);
            }
            if (string.Equals(stringSubCategory, "Summer Fruit Delight")) {
                totalNumberOfCollections = 7;
                allSubProducts[5].gameObject.SetActive(true);
            }
            isGameStart = true;
            isGameEnd = false;
            finalBowl.SetActive(true);
        }

        public void SetDragableObjectIntoBowl() {
            currentCollections++;
            currentDragableObject = OVRGrabber.currentDragableObject;
            currentDragableObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            currentDragableObject.transform.parent = finalBowl.gameObject.transform;
            currentDragableObject.transform.localPosition = new Vector3(0, 0, 0);
            currentDragableObject.transform.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
        }


        public void OnGameEnd() {

            for (int i = 0; i < finalProducts.Count; i++) { finalProducts[i].gameObject.SetActive(false); }
            for (int i = 0; i < allSubProducts.Count; i++) { allSubProducts[i].gameObject.SetActive(false); }

            if (string.Equals(stringSubCategory, "Chocolate Cake")) { finalProducts[0].gameObject.SetActive(true); }
            if (string.Equals(stringSubCategory, "Chocolate Truffles")) { finalProducts[1].gameObject.SetActive(true); }
            if (string.Equals(stringSubCategory, "Mawa Modak")) { finalProducts[2].gameObject.SetActive(true); }
            if (string.Equals(stringSubCategory, "Rice Kheer")) { finalProducts[3].gameObject.SetActive(true); }
            if (string.Equals(stringSubCategory, "Pancake")) { finalProducts[4].gameObject.SetActive(true); }
            if (string.Equals(stringSubCategory, "Summer Fruit Delight")) { finalProducts[5].gameObject.SetActive(true); }

            
        }
    }
}