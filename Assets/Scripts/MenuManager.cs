using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public TMP_Text searchField;
    public GameObject keyBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickSearch()
    {
        SceneHandler.Instance.searchForWayPoints(searchField.text);
        searchField.text = "";
        keyBoard.SetActive(false);
    }

    public void onClickLocation()
    {
        //EventSystem.current.currentSelectedGameObject.name
    }

    public void onClickKeyBoard()
    {
        keyBoard.SetActive(true);
    }

}
