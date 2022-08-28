using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetLocation;
    public GameObject desertWaveSpawner;
    public Player playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //npc.transform.position = targetLocation.transform.position + (npc.transform.position - other.gameObject.transform.position);

            other.gameObject.transform.position = targetLocation.transform.position;
        }

        desertWaveSpawner.SetActive(true);
    }
}
