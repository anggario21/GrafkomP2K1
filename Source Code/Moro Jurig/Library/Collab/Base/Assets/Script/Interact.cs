using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public string interactButton;

    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public Image interactIcon;

    public bool isInteracting;
    // Start is called before the first frame update
    void Start()
    {
        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactDistance, interactLayer))
        {
            if (isInteracting = false)
            {
                interactIcon.enabled = true;
                
                if (Input.GetButtonDown(interactButton))
                {
                    if (hitInfo.collider.CompareTag("Door"))
                    {
                        hitInfo.collider.GetComponent<Door90>().ChangeDoorState();
                       // hitInfo.collider.GetComponent<DoorMin90>().ChangeDoorState();
                    }
                }
            }
        }
    }
}