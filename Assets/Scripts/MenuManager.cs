using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public TMP_Text searchField;
    public GameObject keyBoard;
    public Transform ME3110Parent, ME3150Parent, ME2510Parent;
    public GameObject spotPrefab;
    public List<SpotButtonHandler> ME3110SpotList, ME3150SpotList, ME2510SpotList; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void onClickSearch()
    //{
    //    SceneHandler.Instance.searchForWayPoints(searchField.text);
    //    searchField.text = "";
    //    keyBoard.SetActive(false);
    //}

    public void initList(SpotDetail[] ME3110, SpotDetail[] ME3150, SpotDetail[] ME2510)
    {
        foreach (SpotDetail t in ME3110)
        {
            GameObject temp = Instantiate(spotPrefab, ME3110Parent);
            temp.GetComponent<SpotButtonHandler>().init(t);
            ME3110SpotList.Add(temp.GetComponent<SpotButtonHandler>());
        }
        foreach (SpotDetail t in ME3150)
        {
            GameObject temp = Instantiate(spotPrefab, ME3150Parent);
            temp.GetComponent<SpotButtonHandler>().init(t);
            ME3150SpotList.Add(temp.GetComponent<SpotButtonHandler>());
        }
        foreach (SpotDetail t in ME2510)
        {
            GameObject temp = Instantiate(spotPrefab, ME2510Parent);
            temp.GetComponent<SpotButtonHandler>().init(t);
            ME2510SpotList.Add(temp.GetComponent<SpotButtonHandler>());
        }
    }

    public void onClickLocation()
    {
        //EventSystem.current.currentSelectedGameObject.name
    }

    public void onClickKeyBoard()
    {
        keyBoard.SetActive(!keyBoard.activeSelf);
    }

    public void findSpot()
    {
        //
    }

    public void updateLists()
    {
        SpotDetail[] ME3110, ME3150, ME2510;
        ME3110 = SceneHandler.Instance.ME3110;
        ME3150 = SceneHandler.Instance.ME3150;
        ME2510 = SceneHandler.Instance.ME2510;
        clearLists();
        foreach (SpotDetail t in ME3110)
        {
            if(t.spotName.ToLower().Contains(searchField.text.ToLower()) || t.spotID.ToLower().Contains(searchField.text.ToLower()))
            {
                GameObject temp = Instantiate(spotPrefab, ME3110Parent);
                temp.GetComponent<SpotButtonHandler>().init(t);
                ME3110SpotList.Add(temp.GetComponent<SpotButtonHandler>());
            }
        }
        foreach (SpotDetail t in ME3150)
        {
            if (t.spotName.ToLower().Contains(searchField.text.ToLower()) || t.spotID.ToLower().Contains(searchField.text.ToLower()))
            {
                GameObject temp = Instantiate(spotPrefab, ME3150Parent);
                temp.GetComponent<SpotButtonHandler>().init(t);
                ME3150SpotList.Add(temp.GetComponent<SpotButtonHandler>());
            }
        }
        foreach (SpotDetail t in ME2510)
        {
            if (t.spotName.ToLower().Contains(searchField.text.ToLower()) || t.spotID.ToLower().Contains(searchField.text.ToLower()))
            {
                GameObject temp = Instantiate(spotPrefab, ME2510Parent);
                temp.GetComponent<SpotButtonHandler>().init(t);
                ME2510SpotList.Add(temp.GetComponent<SpotButtonHandler>());
            }
        }

    }

    public void clearLists()
    {
        foreach (SpotButtonHandler btn in ME3110SpotList)
        {
            Destroy(btn.gameObject);
        }
        foreach (SpotButtonHandler btn in ME3150SpotList)
        {
            Destroy(btn.gameObject);
        }
        foreach (SpotButtonHandler btn in ME2510SpotList)
        {
            Destroy(btn.gameObject);
        }
        ME3110SpotList.Clear();
        ME3150SpotList.Clear();
        ME2510SpotList.Clear();
    }

}
