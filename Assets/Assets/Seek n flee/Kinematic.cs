using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ngl i had a lot of trouble with this one
public class Kinematic : MonoBehaviour
{
    public Vector3 vel;
    public float rot;
    private KinematicSeek steering;
    public Transform target;
    public float maxSpeed = 5f;

    void Start()
    {
        steering = new KinematicSeek();
        steering.target = target;
        steering.character = this.transform;
        steering.maxSpeed = maxSpeed;
    }

    void Update()
    {
        SteeringOutput steerOut = steering.getSteering();
        getSteering(steerOut, Time.deltaTime);
    }

    public float newOrientation(float current, Vector3 vel)
    {
        if(vel.magnitude > 0)
        {
            return (Mathf.Atan2(vel.x, vel.z) * Mathf.Rad2Deg);
        }
        else
        {
            return current;
        }

    }

    public void getSteering(SteeringOutput steering, float time)
    {
        vel += steering.vel * time;
        transform.position += vel * time;

    }
}
