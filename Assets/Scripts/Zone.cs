using System;
using Unity.VisualScripting;
using UnityEngine;

namespace com.donovanwilder.wws
{
    public class Zone
    {
        public String Name;
        public Vector3 StartPosition;
        public Vector3 EndPosition;
        public float Height;
        public float PositionY;
        public Guid ZoneID;
        public bool created = false;

        public Zone(Vector3 startPos, Vector3 endPos, float zoneHeight, float zonePosY)
        {
            this.Name = "blank";
            StartPosition = startPos;
            EndPosition = endPos;
            this.Height = zoneHeight;
            PositionY = zonePosY;
            ZoneID = Guid.NewGuid();

        }
    }
}
