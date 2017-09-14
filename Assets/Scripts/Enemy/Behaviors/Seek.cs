using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seek : MonoBehaviour {

    public Rigidbody rb;

    private float maxSpeed = 5f;
    private float maxMagnitude = 3f;

    public void ApplyForce(Vector3 force)
    {
        rb.velocity += force * Time.deltaTime;
        //Debug.Log(rb.velocity);
        if (rb.velocity.magnitude > maxMagnitude)
        {
            rb.velocity = rb.velocity.normalized * maxMagnitude;
        }
    }

    public Vector3 seek(Vector3 target)
    {
        //Debug.DrawRay(transform.position, target, Color.red);
        //Debug.DrawRay(target, transform.position, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * 10f, Color.blue);
        //direction to that the force will be applied to
        Vector3 desired = target - transform.position;

        //normalize
        desired.Normalize();

        return desired;

    }

    //Uses the arrive function to seek out a target and slow down as it gets closer to the target
    public Vector3 seek(Vector3 target, float weight)
    {
        //Debug.DrawRay(transform.position, target, Color.red);
        //Debug.DrawRay(target, transform.position, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * 10f, Color.blue);
        //direction to that the force will be applied to
        //Vector3 desired = target - transform.position;

        //normalize
        //desired.Normalize();

        //BoundsCheck(desired);
        Vector3 desired = arrive(target);
        return desired *= weight;

    }

    public Vector3 arrive(Vector3 target)
    {

        float maxAcceleration = 2;
        float maxSpeed = 2;
        float targetRadius = 0.005f;
        float slowRadius = 2f;
        float timeToTarget = 0.1f;

        Vector3 desired = target - transform.position;

        float dist = target.magnitude;

        if(dist < targetRadius)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return Vector3.zero;
        }

        float targetSpeed;
        if (dist > slowRadius)
        {
            targetSpeed = maxSpeed;
        } else
        {
            targetSpeed = maxSpeed * (dist / slowRadius);
        }

        desired.Normalize();
        desired *= targetSpeed;

        Vector3 acceleration = desired - this.GetComponent<Rigidbody>().velocity;
        acceleration *= 1 / timeToTarget;

        if(acceleration.magnitude > maxAcceleration)
        {
            acceleration.Normalize();
            acceleration *= maxAcceleration;
        }

        return acceleration;
    }

}
