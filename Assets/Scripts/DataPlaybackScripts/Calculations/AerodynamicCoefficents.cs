using System.Collections;
using System.Collections.Generic;
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

	public static void CalculateAerodynamicCoefficients()
	{
		float rho = GetAirDensity(float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("alt_m")]));
		float V = float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("tas_m_s")]);
		float S = 0.55f;
		float CMAC = 0.19f;

		// Lift ve Drag kuvvetlerini hesapla (basit modelleme ile)
		float Lift = float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("mass_kg")]) * float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("az_m_s2")]);
		float Drag = float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("mass_kg")]) * float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("ax_m_s2")]);

		// Moment hesaplamasý burada yapýlmalý (örneðin dikey eksen etrafýndaki moment)
		float M = 0; // Bu deðeri uygun þekilde hesaplamanýz gerekecek

		// Katsayýlarý hesapla
		float CL = (2 * Lift) / (rho * V * V * S);
		float CD = (2 * Drag) / (rho * V * V * S);
		float Cm = (2 * M) / (rho * V * V * S * CMAC);

		Debug.Log($"CL: {CL}, CD: {CD}, Cm: {Cm}");
	}

	private void Start()
	{
		CalculateAerodynamicCoefficients();
	}
}
