using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    //ReferĂȘncias
    [Header("ReferĂȘncias")]
    public Transform player;
    public float triggerRange;

    void Update()
    {
        CheckDistance();
    }

    public void CheckDistance()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= triggerRange)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            this.gameObject.GetComponent<NPCFollow>().enabled = true;
        }
    }
}
