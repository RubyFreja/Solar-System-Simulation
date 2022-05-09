using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    //SI units
    public float mass_in_kg;
    public float radius_in_meters;
    public Vector3 velocity_in_mps;
    
    //Unity units
    public float unity_mass;
    public float unity_radius;
    public Vector3 unity_velocity;
    
    public Rigidbody rigid_body;
    public float force_magnitude;
    public float distance_squared;



    //Apply gravity to each Celestial Body
    void FixedUpdate ()
    {
        CelestialBody[] celestialbodies = FindObjectsOfType<CelestialBody>();
        foreach (CelestialBody celestialbody in celestialbodies)
        {
            if (celestialbody != this)
                Gravity(celestialbody);
        }
    }
    
    //Simulates the force of gravity
    void Gravity (CelestialBody Otherbody)
    {
       //Convert SI values to Unity's units (for display)
       unity_radius = radius_in_meters * Units.m_to_unit;
       unity_mass = mass_in_kg * Units.kg_to_unit;
       unity_velocity = velocity_in_mps * Units.m_to_unit / Units.sec_to_unit;

       //set rigibody components to their respective values in Unity's units
       rigid_body.mass = unity_mass;
       rigid_body.velocity = unity_velocity;

       //The other celestial body which is acting on the current one
       Rigidbody otherbody = Otherbody.rigid_body;

       Vector3 distance = (rigid_body.position - otherbody.position).normalized;   //distance between bodies
       distance_squared = (rigid_body.position - otherbody.position).sqrMagnitude;  //distance between bodies squared

       force_magnitude = (Units.G_to_unit * Universe.gravitational_constant) * rigid_body.mass * otherbody.mass / distance_squared;    //Newton's law of gravity

       Vector3 force = distance * force_magnitude;  //converts magnitude of force to a vector (gives it direction)
       Vector3 acceleration = -force / rigid_body.mass;     //Calculates acceleration due to the force
       velocity_in_mps = (unity_velocity + (acceleration * Time.deltaTime)) * Units.sec_to_unit / Units.m_to_unit;  //Applies the acceleration to the body
    }

}
