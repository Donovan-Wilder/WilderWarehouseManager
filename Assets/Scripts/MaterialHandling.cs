using System.Collections.Generic;
using UnityEngine;

public class MaterialHandling : MonoBehaviour
{
    private List<GameObject> canPickup;
    private List<GameObject> heldItems;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heldItems = new List<GameObject>();
        canPickup = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject n in heldItems)
        {
            n.transform.position = transform.position + new Vector3(1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.N) && canPickup.Count > 0)
        {
            PickupItem();
        }
        if (Input.GetKeyDown(KeyCode.B) && heldItems.Count > 0)
        {
            DropItem();
        }
    }

    public void PickupItem()
    {
        heldItems.Add(canPickup[0]);
    }
    public void DropItem()
    {
        heldItems.Remove(heldItems[0]);
        heldItems[0].transform.position.Set(transform.position.x, 0.66f, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            canPickup.Add(other.gameObject);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            canPickup.Remove(other.gameObject);
        }
    }

}
