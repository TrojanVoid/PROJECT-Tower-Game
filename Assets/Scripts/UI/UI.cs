using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UI : MonoBehaviour{

    public Button towerFirstPageButton;
    public Button towerSecondPageButton;

    private List<GameObject> panels;
    private List<GameObject> pages;

    void Start(){
        AddListeners();
        panels = GameObject.FindGameObjectsWithTag("UIUpgradePanel").ToList();
        pages = GameObject.FindGameObjectsWithTag("UIUpgradePage").ToList();
    }

    private void AddListeners(){
        towerFirstPageButton.onClick.AddListener(() => SwitchUIPage("TowerUpgrades", 1));
        towerSecondPageButton.onClick.AddListener(() => SwitchUIPage("TowerUpgrades", 2));
    }

    // TODO NOT COMPLETED
    private void EnableUIPanel(string panelName){
        GameObject.Find(panelName).SetActive(true);
    }

    private void SwitchUIPage(string panelName, int pageNumber){
        string pageName = "";
        switch(panelName){
            case "TowerUpgrades":
                pageName += "Tower";
                
            break;
        }
        pageName += pageNumber == 1 ? "FirstPage" : "SecondPage";
        foreach(GameObject go in pages){
            Debug.Log(go.name);
            if(go.name.Equals(pageName)) go.SetActive(true);
            else go.SetActive(false);
        }         
    }
}