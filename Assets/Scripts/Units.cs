using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Units
{
	public const float kg_to_unit = 1/(5.9722e+24f);    //converts kilograms into unity units
    public const float m_to_unit = 100/(149597870700f); //converts metres into unity units
    public const float sec_to_unit = 12/(31557600f);    //converts seconds into unity units
    public static float G_to_unit = Mathf.Pow(100/(149597870700f),3) * (5.9722e+24f) * Mathf.Pow(12/(31557600f), -2);   //converts Newton's constant into unity units
    public static float S_to_unit = 1/(5.9722e+24f) * Mathf.Pow(12/(31557600f), -3);    //converts the Stefan Boltzman constant into unity units
}
