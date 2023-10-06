using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WheelAlignment : MonoBehaviour
{
    public WheelCollider correspondingCollider;
    private float rotationVel = 0f;

    public void Update()
    {
        RaycastHit hit;

       
        Vector3 colliderCenter = correspondingCollider.transform.TransformPoint(correspondingCollider.center);

        
        bool collided = Physics.Raycast(colliderCenter,
                                        -correspondingCollider.transform.up,
                                        out hit,
                                        correspondingCollider.suspensionDistance + correspondingCollider.radius);
        if (collided)
        {
            transform.position = hit.point + (correspondingCollider.transform.up * correspondingCollider.radius);
        }
        else
        {
            transform.position = colliderCenter - (correspondingCollider.transform.up * correspondingCollider.suspensionDistance);
        }

        transform.rotation = correspondingCollider.transform.rotation * Quaternion.Euler(rotationVel, correspondingCollider.steerAngle, 0);

        rotationVel += correspondingCollider.rpm * (360 / 60) * Time.deltaTime;
    }

}