using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI; 

//Manomotion

public class Clicker : MonoBehaviour
{

    bool isSessionQualityOk; 

    // Start is called before the first frame update
    private void Start()
    {
        ARSession.stateChanged += HandleStateChanged; 
    }

    // Update is called once per frame
    private void Update()
    {
        if(isSessionQualityOk)
        {
            SpawnCubeWithClickTriggerGesture();

        }
    }

    // Handles the situation when the status of the Session has Changed. 
    // In this case, keep track if the session is in Good Quality and Tracking
    // <param name = "stateEventArguments"></param>

    private void HandleStateChanged (ARSessionStateChangedEventArgs statEventArguments)
    {
        isSessionQualityOk = statEventArguments.state == ARSessionState.SessionTracking; 

    }

    //Replace this with a prefab of items you feel like spawning.
    public GameObject itemPrefab; 

    //Spawns a cube in front of the user when the user performs a Click Gesture and its detected by the system
    private void SpawnCubeWithClickTriggerGesture()
    {

        // All the information for a detected hand. It refers to a single hand.
        HandInfo handInformation = ManomotionManager.Instance.Hand_infors[0].hand_infor; 

        // All the gesture information for this hand
        GestureInfo gestureInformation = handInformation.gesture_info; 

        // The trigger gesture that is detected in this frame
        ManoGestureTrigger currentDetectedTriggerGesture = gestureInformation.mano_gesture_trigger;

        if (currentDetectedTriggerGesture == ManoGestureTrigger.CLICK)
        {
            // A click has been performed by the user and it has been detected as the current trigger Gesture
            GameObject newItem = Instantiate(itemPrefab);

            // Spawn a cube at the position of the camera, also adding a small offset forward so it does not spawn right in front of it.
            Vector3 positionToMove = Camera.main.transform.position + (Camera.main.transform.forward * 2);

            newItem.transform.position = positionToMove;

            //Make the phone vibrate for feedback 
            Handheld.Vibrate();

        }

    }


}
