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
            if (isInteracting == false)
            {
                if (interactIcon != null)
                {
                    interactIcon.enabled = true;
                    // Debug.Log("YES");
                }

                if (Input.GetButtonDown(interactButton))
                {
                    //Debug.Log("Kepencet Cok");
                    if (hitInfo.collider.CompareTag("Door"))
                    {
                        hitInfo.collider.GetComponent<Door>().ChangeDoorState();
                    }

                    else if (hitInfo.collider.CompareTag("Pistolaer"))
                    {
                        hitInfo.collider.GetComponent<PistolInteract>().PickupPistol();
                    }

                    else if (hitInfo.collider.CompareTag("lilin"))
                    {
                        hitInfo.collider.GetComponent<LilinInteract>().MatiLilin();
                    }
                }
            }
        }
        else
        {
            interactIcon.enabled = false;
        }
    }
}