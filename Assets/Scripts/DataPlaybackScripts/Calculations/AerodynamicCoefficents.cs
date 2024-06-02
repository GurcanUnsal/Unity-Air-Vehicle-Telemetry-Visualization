using UnityEngine;

public class AerodynamicCoefficents : MonoBehaviour
{
	public static float GetAirDensity(float altitude)
	{
		float T0 = 288.15f; // Sea level standard temperature in Kelvin
		float P0 = 101325f; // Sea level standard pressure in Pascals
		float R = 287.05f; // Specific gas constant for dry air in J/(kg*K)
		float L = 0.0065f; // Temperature lapse rate in K/m
		float g = 9.80665f; // Gravitational acceleration in m/s^2

		float T = T0 - L * altitude;
		float P = P0 * Mathf.Pow((1 - (L * altitude) / T0), (g / (R * L)));

		return P / (R * T);
	}

	public static void VisualizeAerodynamicCoefficients(float alt_m, float tas_m_s, float mass_kg, float ay_m_s2, float az_m_s2, float thrust_N, float alpha_rad)
	{
		float airDensity = GetAirDensity(alt_m);
		float V = tas_m_s;
		float S = 0.55f;
		float CMAC = 0.19f;

		float weight = mass_kg * 9.80665f;

		// Calculate lift and drag
		float Lift = mass_kg * ay_m_s2 + weight * Mathf.Cos(alpha_rad);
		float Drag = mass_kg * az_m_s2 - thrust_N * Mathf.Cos(alpha_rad);

		// Moment hesaplamasý burada yapýlmalý (örneðin dikey eksen etrafýndaki moment)
		float M = 0; // Bu deðeri uygun þekilde hesaplamanýz gerekecek

		// Katsayýlarý hesapla
		float CL = (2 * Lift) / (airDensity * V * V * S);
		float CD = (2 * Drag) / (airDensity * V * V * S);
		float Cm = (2 * M) / (airDensity * V * V * S * CMAC);

		Debug.Log($"CL: {CL}, CD: {CD}, Cm: {Cm}");
	}
}
