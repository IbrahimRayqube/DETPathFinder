using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotButtonHandler : MonoBehaviour
{
    string spotName, spotID;
    public Text SpotNameText;
    public Text spotIDText;
    public SpotType spotType;
    public Vector3 location;
    public Image icon;
    public SpotDetail myDetails;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void init(SpotDetail detail)
    {
        myDetails = detail;
        spotIDText.text = detail.spotID;
        spotID = detail.spotID;
        SpotNameText.text = detail.spotName;
        spotName = detail.spotName; ;
        switch (detail.type)
        {
            case SpotType.CAFE:
                icon.sprite = SceneHandler.Instance.CafeIcon;
                break;
            case SpotType.MEETINGROOM:
                icon.sprite = SceneHandler.Instance.MeetingRoomIcon;
                break;
            case SpotType.RECEPTION:
                icon.sprite = SceneHandler.Instance.ReceptionistIcon;
                break;
            case SpotType.SPOT:
                icon.sprite = SceneHandler.Instance.spotIcon;
                break;
        }
    }

    public void onClickMe()
    {
        SceneHandler.Instance.searchForWayPoints(myDetails);
    }
}
