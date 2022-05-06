using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpotType 
{
    SPOT,
    RECEPTION,
    MEETINGROOM,
    CAFE
}

[Serializable]
public class SpotDetail
{
    public SpotType type;
    public string spotName;
    public string spotID;
    public Vector3 postion;
    public string details = "This is Dummy details";
    public bool spawnInfoOnLeft = true;
    public float textSize;
}
public class SceneHandler : Singleton<SceneHandler>
{
    public MenuManager menuManager;
    public List<LocationData> allLocations;
    public Graphway Graphway;
    public GameObject pathPointPrefab;
    public GameObject pathPointParent;
    public List<GameObject> allPathPoints;
    public GameObject pathPointStart;
    public GameObject pathPointLastPrefab;
    public GameObject[] allSpots;
    public GameObject infoPrefab;
    public GameObject spawnedInfoPrefab;
    public Vector3 startPoint;
    int currentSpotIndex;
    bool infoPanelActivated = false;
    RaycastHit hit;
    public SpotDetail[] ME3110, ME3150, ME2510;
    public Sprite spotIcon, ReceptionistIcon, MeetingRoomIcon, CafeIcon;
    public SpotDetail currentSpot;
    bool showingPoints = false;
    public float timer = 0f;
    public bool startCountDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        menuManager.initList(ME3110, ME3150, ME2510);
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDown)
        {
            timer += Time.deltaTime;
            if (timer > 10)
            {
                clearAll();
                startCountDown = false;
                timer = 0;
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (infoPanelActivated)
        //    {
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        // Create a particle if hit
        //        if (Physics.Raycast(ray, out hit))
        //        {
        //            Debug.Log(hit.transform.name);
        //            if (hit.transform.name == "InfoIcon")
        //            {
        //                spawnedInfoPrefab.transform.GetChild(1).gameObject.SetActive(true);
        //            }
        //        }
        //    }
        //}
    }

    public void searchForWayPoints(SpotDetail spot)
    {
        stopTimer();
        if (showingPoints)
            return;
        if (spot.postion == Vector3.zero)
            return;
        currentSpot = spot;
        clearAll();
        Graphway.FindPath(startPoint, spot.postion, returnedWayPoints);
            //if (allSpots[i].name == spotName)
            //{
            //    currentSpotIndex = i;
            //    break;
            //}
    }

    private void returnedWayPoints(GwWaypoint[] path)
    {
        if (path.Length > 0)
        {
            StartCoroutine(showPath(path));
        }
        else
        {
            Debug.Log("No Path Found");
        }
    }

    IEnumerator showPath(GwWaypoint[] path)
    {
        pathPointStart.SetActive(true);
        showingPoints = true; 
        spawnedInfoPrefab = Instantiate(infoPrefab, path[path.Length - 1].position, Quaternion.Euler(new Vector3(90, 0, 0)), allSpots[currentSpotIndex].transform);
        GameObject infoIcon = spawnedInfoPrefab.transform.GetChild(0).gameObject;
        GameObject infoBox = spawnedInfoPrefab.transform.GetChild(1).gameObject;
        infoBox.transform.GetChild(0).GetComponent<Text>().text = currentSpot.spotID + " " + currentSpot.spotName;
        infoIcon.SetActive(true); 
        infoPanelActivated = true;
        for (int i = 0; i < path.Length - 1; i++)
        {
            GameObject temp = Instantiate(pathPointPrefab, path[i].position, Quaternion.identity, pathPointParent.transform);
            allPathPoints.Add(temp);
            yield return new WaitForSeconds(0.2f);
        }
        //spawnedInfoPrefab = Instantiate(infoPrefab, currentSpot.postion, Quaternion.Euler(new Vector3(90, 0, 0)), allSpots[currentSpotIndex].transform);
        //GameObject infoIcon = spawnedInfoPrefab.transform.GetChild(0).gameObject;
        //infoIcon.SetActive(true);
        //infoIcon.GetComponent<RectTransform>().localPosition = allSpots[currentSpotIndex].GetComponent<SpotHandler>().infoIconPosition;
        //infoPanelActivated = true;
        showingPoints = false;
        //GameObject infoBox = spawnedInfoPrefab.transform.GetChild(1).gameObject;
        infoIcon.SetActive(false);
        infoBox.SetActive(true);
        startTimer();
    }

    public void clearAll()
    {
        foreach (GameObject t in allPathPoints)
        {
            Destroy(t);
        }
        allPathPoints.Clear();
        pathPointStart.SetActive(false);
        Destroy(spawnedInfoPrefab);
        //menuManager.onClickClearBtn();
    }

    public void startTimer()
    {
        timer = 0;
        startCountDown = true;
    }

    public void stopTimer()
    {
        timer = 0;
        startCountDown = false;
    }
}
