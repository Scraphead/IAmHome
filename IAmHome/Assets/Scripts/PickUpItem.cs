using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpItem : MonoBehaviour
{
    public UnityEvent onPickUpItemEvent;
    public GameObject keyObj;
    public GameObject keyPickedUpPivot;

    public void OnPickUpItem(GameObject key)
    {
        keyObj = key.gameObject.transform.parent.gameObject;
        if (onPickUpItemEvent != null)
            onPickUpItemEvent.Invoke();
        GameManager.Instance.haveKey = true;
        MoveKeyToHand(keyObj);
    }

    public void MoveKeyToHand(GameObject key)
    {
        key.transform.position = keyPickedUpPivot.transform.position;
        key.gameObject.transform.SetParent(transform);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {

        }
    }

    public void DropKey()
    {
        if (!GameManager.Instance.haveKey)
        {
            Debug.Log("No key in hand to drop");
            return;
        }

        keyObj.transform.parent = null;
    }
    private void OnTriggerEnter  (Collider other)
    {
       
        if (other.CompareTag("Key"))
        {
            Debug.Log("Touched Key!");
            
            OnPickUpItem(other.gameObject);
        }
    }
}
