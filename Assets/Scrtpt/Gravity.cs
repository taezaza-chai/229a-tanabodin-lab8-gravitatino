using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gravity : MonoBehaviour
{
     Rigidbody rb;
      const float G = 100f;
      public static List<Gravity> GarvityObjectsList;

     private void Awake()
     {
         rb = GetComponent<Rigidbody>();
         if (GarvityObjectsList == null)
         {
             GarvityObjectsList = new List<Gravity>();
         }
         GarvityObjectsList.Add(this);
     }

      void FixedUpdate()
     {
         foreach (Gravity odj  in GarvityObjectsList)
         {
             Attract(odj);
         }
     }

     void Attract(Gravity other)
     {
         Rigidbody rbOther = other.rb;

         Vector3 direction = rb.position - rbOther.position;

         float distance = direction.magnitude;
         
         if (distance == 0) {return;}

         float forcMagnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);
         Vector3 Force = forcMagnitude * direction.normalized;
         
         rbOther.AddForce(Force);


     }
}
