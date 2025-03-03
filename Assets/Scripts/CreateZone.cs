using System;
using com.donovanwilder.wws;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateZone : MonoBehaviour
{

    private Vector3 startPosition;
    private Vector3 pendingPosition;
    private Vector3 endPosition;
    private bool hasStarted = false;
    private GameObject zoneObject;
    private MeshRenderer visibility;
    public float zoneHeight = 3f;
    public float zonePositionY = 1f;
    private ZoneTracker zoneTracker;
    public GameObject zoneMarkImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoneObject = Instantiate(zoneMarkImage);
        zoneObject.name = "ZoneArea";
        visibility = zoneObject.GetComponent<MeshRenderer>();
        visibility.enabled = false;
        zoneTracker = GetComponent<ZoneTracker>();
    }

    // Update is called once per frame
    void Update()
    {

        // Starts the zone creation
        if (Input.GetMouseButtonDown(1) && !hasStarted)
        {
            hasStarted = true;
            visibility.enabled = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                startPosition = hit.point;
            }
        }
        // Tracks the current point
        if (hasStarted)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                pendingPosition = hit.point;
            }
            Debug.Log($"Create zone: start({startPosition}), pending({pendingPosition}), end({endPosition})");
            DrawZone();
        }

        if (Input.GetMouseButtonUp(1) && hasStarted)
        {
            hasStarted = false;
            visibility.enabled= false;
            endPosition = pendingPosition;
            Zone zone = new Zone(startPosition,endPosition,zoneHeight,zonePositionY);
            zoneTracker.AddZone(zone);
            zoneTracker.CreateAllZones();
            Debug.Log($"Create zone: start({startPosition}), pending({pendingPosition}), end({endPosition})");
        } 
    }

    private void DrawZone()
    {
        float differenceX = startPosition.x - pendingPosition.x;
        float differenceZ = startPosition.z - pendingPosition.z;

        zoneObject.transform.localScale = new Vector3(Math.Abs(differenceX), zoneHeight, Math.Abs(differenceZ));
        zoneObject.transform.position = new Vector3(startPosition.x - differenceX / 2, zonePositionY+zoneHeight/2, startPosition.z - differenceZ / 2);
    }
}
