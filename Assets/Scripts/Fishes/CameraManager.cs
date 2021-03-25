using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] FishMove target = default;
    [SerializeField] Transform frontObj = default;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        if (target.state == FishMove.Status.Escape)
        {

        }
        else if (target.transform.localScale.x == -1)
        {
            cameraPosition.x = target.transform.position.x;
        }
        else if (target.transform.localScale.x == 1)
        {
            cameraPosition.x = target.transform.position.x;
        }
        frontObj.position -= (cameraPosition - transform.position) * 0.3f;
        transform.position = cameraPosition;
    }

}
