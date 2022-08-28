using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetLocation;
    public GameObject desertWaveSpawner;
    public Player playerScript;

    List<GameObject> NPCsFollowing;

    private void Start()
    {
        NPCsFollowing = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {          
            
            other.gameObject.transform.position = targetLocation.transform.position;
        }

        desertWaveSpawner.SetActive(true);
    }
}
