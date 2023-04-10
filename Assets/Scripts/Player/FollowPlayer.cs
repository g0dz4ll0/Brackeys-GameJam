using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerTransform;

    private void FixedUpdate()
    {
        
        transform.position = playerTransform.position;

    }

}
