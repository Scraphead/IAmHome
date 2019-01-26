using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpItem : MonoBehaviour
{
    public UnityEvent onPickUpItemEvent;

    public void OnPickUpItem()
    {
        if (onPickUpItemEvent != null)
            onPickUpItemEvent.Invoke();
        GameManager.Instance.haveKey = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            OnPickUpItem();
        }
    }
}
