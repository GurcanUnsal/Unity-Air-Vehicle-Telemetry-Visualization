using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour
{
	private int tas_m_s_index = Dataset.columns.IndexOf("tas_m_s");
	private int alpha_rad_index = Dataset.columns.IndexOf("alpha_rad");
	private int beta_rad_index = Dataset.columns.IndexOf("beta_rad");
	public Vector3 CalculateBodyVelocities()
	{
		float u = Dataset.telemetryData[0][tas_m_s_index] * Mathf.Cos(Dataset.telemetryData[0][alpha_rad_index]) * Mathf.Cos(Dataset.telemetryData[0][beta_rad_index]);
		float v = Dataset.telemetryData[0][tas_m_s_index] * Mathf.Sin(Dataset.telemetryData[0][beta_rad_index]);
		float w = Dataset.telemetryData[0][tas_m_s_index] * Mathf.Sin(Dataset.telemetryData[0][alpha_rad_index]) * Mathf.Cos(Dataset.telemetryData[0][beta_rad_index]);

		return new Vector3(u, v, w);
	}

	void Start()
	{
		Vector3 bodyVelocities = CalculateBodyVelocities();
		Debug.Log($"u: {bodyVelocities.x}, v: {bodyVelocities.y}, w: {bodyVelocities.z}");
	}
}
