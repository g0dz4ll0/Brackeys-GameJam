using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform missileTarget;
    public Rigidbody missileRigidbody;

    public float turn;
    public float missileVelocity;

    private void Awake()
    {
        missileTarget = GameObject.Find("BaseWizard").transform;
    }

    private void FixedUpdate()
    {
        missileRigidbody.velocity = transform.forward * missileVelocity;

        var missileTargetRotation = Quaternion.LookRotation(missileTarget.position - transform.position);

        missileRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, missileTargetRotation, turn));
    }
}
