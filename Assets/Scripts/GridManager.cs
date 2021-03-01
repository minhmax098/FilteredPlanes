using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; 
using UnityEngine.XR.ARSubsystems; 


public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
    // }
    // // Update is called once per frame
    // void Update()
    // {
    // }

    [SerializeField]
    private float size = 0.05f; 

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position  -= transform.position; 

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount *size, 
            (float)yCount *size, 
            (float)zCount *size
        );

        result += transform.position; 

        return result; 

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow; 
        for (float x = 0; x < 40; x+= size)
        {
            for(float z = 0; z < 40; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z)); 
                Gizmos.DrawSphere(point, 0.01f);
            }
        }
    }
}
