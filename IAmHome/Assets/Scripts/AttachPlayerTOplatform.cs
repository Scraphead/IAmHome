using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayerTOplatform : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            Debug.Log("Attached palyer");
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            Debug.Log("Attached palyer EXIT");

            player.transform.parent = null;
        }
    }
}
