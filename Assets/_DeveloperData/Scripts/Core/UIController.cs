using UnityEngine;
using TMPro;
using DG;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace OculusSampleFramework {
    public class UIController : MonoBehaviour {

        public static UIController instance;

        [Header("Panels")]
        public GameObject homePanel;
        public GameObject categorySelectionPanel;
        public GameObject cakeSubCategoryPanel;
        public GameObject festiveSubCategoryPanel;
        public GameObject pourSubCategoryPanel;
        public GameObject instructionPanel;
        public GameObject gameOverPanel;

        [Header("LaserPointer")]
        public GameObject laserPointer;

        private GameObject currentSubCategoryPanel;// forReferanceOnly

        private void Awake() {
            instance = this;
            ResetAllPanels();
            homePanel.SetActive(true);
            homePanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            laserPointer.SetActive(true);
        }

        public void ResetAllPanels() {
            homePanel.transform.localScale = Vector3.zero;
            categorySelectionPanel.transform.localScale = Vector3.zero;
            cakeSubCategoryPanel.transform.localScale = Vector3.zero;
            festiveSubCategoryPanel.transform.localScale = Vector3.zero;
            pourSubCategoryPanel.transform.localScale = Vector3.zero;
            instructionPanel.transform.localScale = Vector3.zero;
            gameOverPanel.transform.localScale = Vector3.zero;
        }

        public void OnClickStartBtn() {

            categorySelectionPanel.SetActive(false);
            homePanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() => {
                homePanel.SetActive(false);
                categorySelectionPanel.SetActive(true);
                categorySelectionPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            });
        }

        public void OnClickSelectCategory(string _category) {
            if (_category == "Bake") {
                currentSubCategoryPanel = cakeSubCategoryPanel;
                categorySelectionPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() => {
                    categorySelectionPanel.SetActive(false);
                    cakeSubCategoryPanel.SetActive(true);
                    cakeSubCategoryPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
                });
            }

            if (_category == "Pour") {
                currentSubCategoryPanel = pourSubCategoryPanel;
                categorySelectionPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() => {
                    categorySelectionPanel.SetActive(false);
                    pourSubCategoryPanel.SetActive(true);
                    pourSubCategoryPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);

                });
            }

            if (_category == "Festive") {
                currentSubCategoryPanel = festiveSubCategoryPanel;
                categorySelectionPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() => {
                    categorySelectionPanel.SetActive(false);
                    festiveSubCategoryPanel.SetActive(true);
                    festiveSubCategoryPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
                });
            }
            GameManager.instance.stringCategory = _category;
        }

        public void OnClickSelectSubCategory(string _subcategory) {
            GameManager.instance.stringSubCategory = _subcategory;
            currentSubCategoryPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() => {
                currentSubCategoryPanel.SetActive(false);
                instructionPanel.SetActive(true);
                instructionPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            });
        }

        public void OnClickInstructionPanel() {
            instructionPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() => {
                instructionPanel.SetActive(false);
                GameManager.instance.OnGameStart();
                laserPointer.SetActive(false);
            });
        }

        public void OnGameEnd() {

            laserPointer.SetActive(true);
            gameOverPanel.SetActive(true);
            GameManager.instance.finalBowl.SetActive(false);
            GameManager.instance.isGameEnd = true;
            GameManager.instance.isGameStart = false;
            for (int i = 0; i < GameManager.instance.allTheParticals.Count; i++) {
                GameManager.instance.allTheParticals[i].gameObject.SetActive(true);
            }
            gameOverPanel.transform.DOScale(Vector3.one, 0.5f).SetDelay(2).SetEase(Ease.OutBounce).OnComplete(() => GameManager.instance.OnGameEnd());
        }

        public void OnRestartGame() {
            gameOverPanel.transform.DOScale(Vector3.zero, 0.5f).SetDelay(2).SetEase(Ease.InBounce).OnComplete(() => {
                gameOverPanel.SetActive(false);
                SceneManager.LoadScene("CoreScene");
            });
        }
    }

}