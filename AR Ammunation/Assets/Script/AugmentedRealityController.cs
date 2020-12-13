using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedRealityController : MonoBehaviour
{
    public Transform ARCamera;
    private Transform currentObject;

    public GameObject prefab, startinganimation;
    private int maxprefab;
    private GameObject spawnprefab;

    // Start is called before the first frame update
    void Start()
    {
        maxprefab = 0;

    }

  
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (ARCamera.position, ARCamera.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {
            if (currentObject != hitInfo.transform)
            {
                currentObject = hitInfo.transform;
            }
            else
            {
                currentObject = null;

                if (Session.Status != SessionStatus.Tracking)
                {
                    return;
                }
                //Session.GetTrackables<DetectedPlane>(allPlanes, TrackableQueryFilter.All);

                Touch touch;
                if (Input.touchCount > 0 && ((touch = Input.GetTouch(0)).phase == TouchPhase.Began))
                {
                    TrackableHit hit;
                    TrackableHitFlags flags = TrackableHitFlags.PlaneWithinPolygon;
                    if (Frame.Raycast(touch.position.x, touch.position.y, flags, out hit))
                    {
                        if ((hit.Trackable is DetectedPlane) && Vector3.Dot(Camera.main.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up) > 0)
                        {
                            DetectedPlane plane = hit.Trackable as DetectedPlane;
                            if (maxprefab < 1)
                            {
                                spawnprefab = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                                maxprefab++;
                                startinganimation.SetActive(false);
                            }
                            var anchor = plane.CreateAnchor(hit.Pose);
                            spawnprefab.transform.parent = anchor.transform;
                        }
                    }
                }
            }
        }
    }
}
