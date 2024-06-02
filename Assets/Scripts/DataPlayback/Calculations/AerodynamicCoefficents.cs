using UnityEngine;
using TMPro;

public class AerodynamicCoefficients : MonoBehaviour
{
	// Reference to the text game object
	private TextMeshProUGUI aerodynamicCoefficientsText;

	// Constant variable declarations
	private const float CMAC = 0.19f;
	private const float S = 0.55f;

	private void Awake()
	{
		aerodynamicCoefficientsText = GetComponent<TextMeshProUGUI>();
	}

	// Calculate Air Density
	private float CalculateAirDensity(float altitude)
	{
		float seaLevelPressure = 101325f; // Pa
		float seaLevelTemperature = 288.15f; // K
		float lapseRate = -0.0065f; // K/m
		float gasConstant = 287.05f; // J/(kg·K)
		float gravity = 9.80665f; // m/s²

		float temperature = seaLevelTemperature + lapseRate * altitude;
		float pressure = seaLevelPressure * Mathf.Pow((temperature / seaLevelTemperature), (-gravity / (lapseRate * gasConstant)));

		return pressure / (gasConstant * temperature);
	}

	// Method to calculate aerodynamic coefficients
	public void VisualizeAerodynamicCoefficients(float ax, float ay, float az, float mass, float thrust, float tas, float altitude)
	{
		float airDensity = CalculateAirDensity(altitude);

		// Lift (L) and Drag (D) components
		float L = mass * az;
		float D = thrust - (mass * ax);

		// Pitching moment
		float M = mass * ay * CMAC;

		// Aerodynamic coefficients
		float CL = (2 * L) / (airDensity * tas * tas * S);
		float CD = (2 * D) / (airDensity * tas * tas * S);
		float Cm = (2 * M) / (airDensity * tas * tas * S * CMAC);

		aerodynamicCoefficientsText.text = $"CL: {string.Format("{0:F2}", CL)}, CD: {string.Format("{0:F2}", CD)}, Cm: {string.Format("{0:F2}", Cm)}";
	}
}
