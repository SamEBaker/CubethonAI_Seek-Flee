using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour
{
    public Transform character;
    public Transform target;

    public float maxSpeed;

    void Update()
    {
        getSteering();
    }

    private float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return (Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg);
        }
        else
        {
            return current;
        }
    }

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.vel = target.position - character.position;
        result.vel.Normalize();
        result.vel *= maxSpeed;
        float angle = newOrientation(character.rotation.eulerAngles.y, result.vel);
        character.eulerAngles = new Vector3(0, angle, 0);
        character.position += result.vel * Time.deltaTime;
        result.rot = 0;
        return result;
    }
}
