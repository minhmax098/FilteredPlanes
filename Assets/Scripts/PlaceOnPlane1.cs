using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; 
using UnityEngine.XR.ARSubsystems; 


[RequirementComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane1 : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Instnatiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab; 

    public GameObject placedPrefab 
    {
        get { 
            return m_PlacedPrefab;
            } 
        set {
            m_PlacedPrefab = value;
        }
    }

    public GameObject spawnedObject 
    {
        get; 
        private set; 
    }
    
    private void Awake() {
        m_RaycastManager = GetComponent<ARRaycastManager>();

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position; 
            return true; 

        }

        touchPosition = default; 
        return false; 

        
    }

    void Update() 
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        
        if(m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.Pl))
    }





    
    
}
