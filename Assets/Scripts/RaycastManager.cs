using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] private GameObject marker;

    [SerializeField] private ARSessionOrigin aRSessionOrigin;
    [SerializeField] private ARRaycastManager raycastManager;

    private Vector3 _position = Vector3.zero;

    private void Update()
    {
        UpdatePositionMarker();
        SetMarkerPosition(_position);
    }

    private void UpdatePositionMarker()
    {
        Ray ray = Camera.main.ScreenPointToRay(Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)));
        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject, 25.0f, LayerMask.GetMask("Ground")))
        {
            if (hitObject.transform.tag.Contains("Ground"))
                _position = hitObject.point;
        }
    }

    private void SetMarkerPosition(Vector3 position)
    {
        marker.transform.position = position;
    }
}
