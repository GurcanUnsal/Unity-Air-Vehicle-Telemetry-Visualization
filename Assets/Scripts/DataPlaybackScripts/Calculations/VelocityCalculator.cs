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
		float u = float.Parse(Dataset.telemetryData[3000][tas_m_s_index]) * Mathf.Cos(float.Parse(Dataset.telemetryData[1][alpha_rad_index])) * Mathf.Cos(float.Parse(Dataset.telemetryData[1][beta_rad_index]));
		float v = float.Parse(Dataset.telemetryData[3000][tas_m_s_index]) * Mathf.Sin(float.Parse(Dataset.telemetryData[1][beta_rad_index]));
		float w = float.Parse(Dataset.telemetryData[3000][tas_m_s_index]) * Mathf.Sin(float.Parse(Dataset.telemetryData[1][alpha_rad_index])) * Mathf.Cos(float.Parse(Dataset.telemetryData[1][beta_rad_index]));

		return new Vector3(u, v, w);
	}

	void Start()
	{
		Vector3 bodyVelocities = CalculateBodyVelocities();
		Debug.Log($"u: {bodyVelocities.x}, v: {bodyVelocities.y}, w: {bodyVelocities.z}");
	}
}
