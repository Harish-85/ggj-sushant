using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    private GameObject heldObject; 
    private Rigidbody heldObjectRB;

    public float throwForce = 10f; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J) && heldObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                if (hit.collider.CompareTag("Pickupable"))
                {
                    // Heb das Objekt auf
                    heldObject = hit.collider.gameObject;
                    heldObjectRB = heldObject.GetComponent<Rigidbody>();
                    heldObjectRB.isKinematic = true; 
                    heldObject.transform.SetParent(transform);
                    heldObject.transform.localPosition = new Vector3(0f, 1f, 1f);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) && heldObject != null)
        {
           
            ReleaseObject();
        }

       
        if (Input.GetMouseButtonDown(0) && heldObject != null)
        {
            ThrowObject();
        }
    }

    void ReleaseObject()
    {
        heldObjectRB.isKinematic = false; 
        heldObject.transform.SetParent(null);
        heldObject = null;
        heldObjectRB = null;
    }

    void ThrowObject()
    {
        heldObjectRB.isKinematic = false; 
        heldObject.transform.SetParent(null);
        heldObjectRB.AddForce(transform.forward * throwForce, ForceMode.Impulse); 
        heldObject = null;
        heldObjectRB = null;
    }
}
