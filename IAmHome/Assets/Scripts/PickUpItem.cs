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
        if (GameManager.Instance.haveKey)
            return;
        GameManager.Instance.haveKey = true;
        keyObj = key.gameObject.transform.parent.gameObject;
        if (onPickUpItemEvent != null)
            onPickUpItemEvent.Invoke();
        
        MoveKeyToHand(keyObj);
    }

    public void MoveKeyToHand(GameObject key)
    {
        key.transform.position = keyPickedUpPivot.transform.position;
        key.gameObject.transform.SetParent(transform);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropKey();
        }
    }

    public void DropKey()
    {
        //if (!GameManager.Instance.haveKey)
        //{
        //    Debug.Log("No key in hand to drop");
        //    return;
        //}
        if(keyObj != null)
         keyObj.transform.parent = null;
        GameManager.Instance.haveKey = false;


    }
    private void OnTriggerStay  (Collider other)
    {
       
        if (other.CompareTag("Key") && !GameManager.Instance.haveKey)
        {
            Debug.Log("Touched Key!");
            
            OnPickUpItem(other.gameObject);
        }
    }
}
