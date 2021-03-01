using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class InteractivePoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ARSessio.state == ARSessionState.SessionTracking)
        {
            FollowPalmCenter();
        }
    }

    private void FollowPalmCenter()
    {
        HandInfo currentlyDetectedHand = ManomotionManager.Instance.Hand_infos[0].hand_info;

        ManoClass currentlyDetectedManoClass = currentlyDetectedHand.gesture_info.mano_class;

        Vector3 palmCenterPosition = currentlyDetectedHand.tracking_info.palm_center;

        if(currentlyDetectedManoClass == currentlyDetectedManoClass.GRAB_GESTURE)
        {
            this.transform.position = ManoUtils.Instance.CalculateNewPosition(palmCenterPosition, currentlyDetectedHand.tracking_info.depth_estimation);
            
        }
    }
}
