using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class RecipeCoreClass {
    public string recipeName;
    public List<string> CorrectIngridiants = new List<string>();
}

//[Serializable]
//public class CorrectIngrediant {
//    public string name;
//    public bool isValid;
//}

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

    private void Awake() {
        instance = this;
        for (int i = 0; i < finalProducts.Count; i++) {
            finalProducts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < allSubProducts.Count; i++) {
            allSubProducts[i].gameObject.SetActive(false);
        }
    }

    public void OnGameStart() {
        for (int i = 0; i < finalProducts.Count; i++) {
            finalProducts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < allSubProducts.Count; i++) {
            allSubProducts[i].gameObject.SetActive(false);
        }
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
