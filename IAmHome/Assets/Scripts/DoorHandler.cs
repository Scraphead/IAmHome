using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DoorHandler : MonoBehaviour
{
    public UnityEvent onOpenDoorEvent;
    // Start is called before the first frame update
   
    public void OnOpenDoor()
    {
        if (!GameManager.Instance.haveKey)
            return;
        Debug.Log("Door OPENED");
        GameManager.Instance.openedDoor = true;
        if (onOpenDoorEvent != null)
            onOpenDoorEvent.Invoke();
        GameManager.Instance.GameFinnishhed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Door interacted with player, but no key");
        }
    }

}
