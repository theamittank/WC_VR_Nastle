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
            if (stringSubCategory == "Chocolate Cake") {
                allSubProducts[0].gameObject.SetActive(true);
                totalNumberOfCollections = 9;
            }
            if (stringSubCategory == "Chocolate Truffles") {
                allSubProducts[1].gameObject.SetActive(true);
                totalNumberOfCollections = 2;
            }
            if (stringSubCategory == "Mawa Modak") {
                allSubProducts[2].gameObject.SetActive(true);
                totalNumberOfCollections = 5;
            }
            if (stringSubCategory == "Rice Kheer") {
                allSubProducts[3].gameObject.SetActive(true);
                totalNumberOfCollections = 5;
            }
            if (stringSubCategory == "Pancake") {
                allSubProducts[4].gameObject.SetActive(true);
                totalNumberOfCollections = 12;
            }
            if (stringSubCategory == "Summer Fruit Delight") {
                allSubProducts[5].gameObject.SetActive(true);
                totalNumberOfCollections = 7;
            }
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

            if (stringSubCategory == "Chocolate Cake") { finalProducts[0].gameObject.SetActive(true); }
            if (stringSubCategory == "Chocolate Truffles") { finalProducts[1].gameObject.SetActive(true); }
            if (stringSubCategory == "Mawa Modak") { finalProducts[2].gameObject.SetActive(true); }
            if (stringSubCategory == "Rice Kheer") { finalProducts[3].gameObject.SetActive(true); }
            if (stringSubCategory == "Pancake") { finalProducts[4].gameObject.SetActive(true); }
            if (stringSubCategory == "Summer Fruit Delight") { finalProducts[5].gameObject.SetActive(true); }
        }
    }
}