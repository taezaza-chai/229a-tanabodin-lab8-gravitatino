using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Gravity : MonoBehaviour
{
     Rigidbody rb;
      const float G = 0.00674f;

     private void Awake()
     {
         rb = GetComponent<Rigidbody>();
     }

      void FixedUpdate()
     {
         
     }

     void Attract(Gravity other)
     {
         Rigidbody rbOther = GetComponent<Rigidbody>();

         Vector3 direction = rb.position - other.rb.position;

         float distance = direction.magnitude;
         
         if (distance == 0) {return;}

         float forcMagnitude = G * (rb.mass * other.rb.mass) / Mathf.Pow(distance, 2);
         Vector3 Force = forcMagnitude * direction.normalized;


     }
}
