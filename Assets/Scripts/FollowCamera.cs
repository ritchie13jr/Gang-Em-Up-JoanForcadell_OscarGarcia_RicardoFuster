using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   [ExecuteInEditMode]
   [SerializeField] private Vector3 offset;
   [SerializeField] private float damping;

   public Transform Mordecai_Spritesheed_55;

   private Vector3 vel = Vector3.zero;

   private void FixedUpdate() 
   {
        Vector3 targetPos = Mordecai_Spritesheed_55.position + offset; 

        if (targetPos.y < transform.position.y)
        {
            targetPos.y = transform.position.y;
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, damping);
   }
}
