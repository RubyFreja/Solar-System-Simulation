using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarBody : MonoBehaviour
{    
    public Rigidbody rb;
    public float temperature;
    public float luminosity;
    public float lifetime;

    
    void FixedUpdate ()
    {
        StellarBody[] stellarbodies = FindObjectsOfType<StellarBody>();
        foreach (StellarBody stellarbody in stellarbodies)
        {
             StellarPhysics(stellarbody);
        }
    }    

    void StellarPhysics (StellarBody Otherbody)
    {
        float mass = GetComponent<CelestialBody>().mass_in_kg;  //retrieves mass of the star
        float radius = GetComponent<CelestialBody>().radius_in_meters;  //retrieves radius of the star
       
        float massratio = mass/Universe.solar_mass;  //mass in terms of stellar mass

        //Conditions to achieve certain luminosities
        if (massratio < 0.43f)
        {    
            luminosity = (0.23f * Universe.solar_luminosity * Mathf.Pow(massratio, 2.3f));
        }
        if (massratio <= 2 && massratio >= 0.43f)
        {
            luminosity = Universe.solar_luminosity * Mathf.Pow(massratio, 4);
        }
        if (massratio <= 55 && massratio >= 2)
        {
            luminosity = 1.4f * Universe.solar_luminosity * Mathf.Pow(massratio, 3.5f);
        }
        if (massratio >= 55f)
        {
            luminosity = 32000 * Universe.solar_luminosity * massratio;
        }


        float temperature_power = luminosity / (4 * Mathf.PI * Mathf.Pow(radius,2) * Universe.stefan_constant);
        
        temperature = Mathf.Pow(temperature_power, 0.25f);  //returns the temperature of the star, if only given an input of mass and radius
        
        lifetime =(Mathf.Pow(massratio, -2.5f)) * Universe.solar_lifetime;   //approximation for the lifetime of a star
    }


 
}