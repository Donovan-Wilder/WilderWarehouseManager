
using UnityEngine;

public class MoveToLocation : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool hasArrived = true;
    private Vector3 moveToFlattedLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveToFlattedLocation=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, moveToFlattedLocation, moveSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (hasArrived == false)
            {
                if (Vector3.Distance(transform.position, moveToFlattedLocation) < 0.0001f)
                {
                    hasArrived = true;
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                moveToFlattedLocation = FlattenPosition(hit.point);
                Debug.Log($"Clicked Position: {hit.point}");
                hasArrived = false;
            }
        }
    }

    private Vector3 FlattenPosition(Vector3 newPos){
        return new Vector3(newPos.x,transform.position.y, newPos.z);
    }
}

