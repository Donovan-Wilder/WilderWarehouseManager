using UnityEngine;
using com.donovanwilder.wws;
using System.Collections.Generic;
using System;

public class ZoneTracker : MonoBehaviour
{
    private List<Zone> zoneList;
    private List<GameObject> zoneObjectList;
    public GameObject zoneObjectImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoneList = new List<Zone>();
        zoneObjectList = new List<GameObject>();
    }

    public void AddZone(Zone zone)
    {
        zoneList.Add(zone);
    }
    public void DeleteZone(Zone zone)
    {
        zoneList.Remove(zone);
    }

    public void CreateAllZones()
    {
        foreach (Zone n in zoneList)
        {
            if (n.created == false)
            {
                CreateZoneObject(n);
                n.created = true;
            }
        }
    }
    private void CreateZoneObject(Zone zone)
    {
        GameObject zoneGameObject = Instantiate(zoneObjectImage);
        zoneObjectList.Add(zoneGameObject);
        float differenceX = zone.StartPosition.x - zone.EndPosition.x;
        float differenceZ = zone.StartPosition.z - zone.EndPosition.z;
        zoneGameObject.transform.localScale = new Vector3(Math.Abs(differenceX), zone.Height, Math.Abs(differenceZ));
        zoneGameObject.transform.position = new Vector3(zone.StartPosition.x - differenceX / 2, zone.PositionY + zone.Height / 2, zone.StartPosition.z - differenceZ / 2);
    }
}
