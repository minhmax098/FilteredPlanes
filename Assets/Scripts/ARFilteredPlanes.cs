using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; 
using UnityEngine.XR.ARSubsystems; 
using UnityEngine.UI; 

public class ARFilteredPlanes : MonoBehaviour
{
    [SerializeField] private Vector2 dimensionsForBigPlane; 

    public event Action OnVerticalPlaneFound; 
    public event Action OnHorizontalPlaneFound; 
    public event Action OnBigPlaneFound; 


    private int test; 

    // need ARPlaneManager 
    private ARPlaneManager arPlaneManager; 
    // need List<FilterdPlanes>, can call ar planes 
    private List<ARPlane> arPlanes; 

    // go set enable, disable at the same time 
    private void OnEnable()
    {
        //set arPlaneManager by this one equals FindObjectOfType since we have one of those 
        arPlanes = new List<ARPlanes>();

        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged; 
    }

    private void OnDisable() 
    {
        arPlaneManager = FindOjectOfType<arPlaneManager>();
        arPlaneManager.planesChanged -= OnPlanesChanged; 
    }

    private void OnPlanesChanged(ARPlanesChangesEventArgs args) 
    {
        if(args.added != null && args.added.Count > 0 )
            //arPlane.AddRange
            arPlanes.AddRange(args.added);
        
        foreach(ARPlane plane in arPlanes.Where(plane => plane.extents.x * plane.extents.y >= 0.1f))
        {
            if(plane.alignment.IsVertical())
            {
                //tell someone we found a vertical
                OnVerticalPlaneFound.Invoke();
            }
            else 
            {
                //tell someone we found a horizontal\
                OnHorizontalPlaneFound.Invoke();

            }

            if(plane.extents.x * plane.extents.y >= dimensionsForBigPlane.x * dimensionsForBigPlane.y)
            {
                // tell someone we found a big plane 
                OnBigPlaneFound.Invoke();


            }
        }

    }



}
