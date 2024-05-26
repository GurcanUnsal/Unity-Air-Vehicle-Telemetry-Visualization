using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour
{
	public Vector3 CalculateBodyVelocities()
	{
		float u = float.Parse(DataManager.telemetryData[3000][DatasetUtils.datasetColumns.IndexOf("tas_m_s")]) * Mathf.Cos(float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("alpha_rad")])) * Mathf.Cos(float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("beta_rad")]));
		float v = float.Parse(DataManager.telemetryData[3000][DatasetUtils.datasetColumns.IndexOf("tas_m_s")]) * Mathf.Sin(float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("beta_rad")]));
		float w = float.Parse(DataManager.telemetryData[3000][DatasetUtils.datasetColumns.IndexOf("tas_m_s")]) * Mathf.Sin(float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("alpha_rad")])) * Mathf.Cos(float.Parse(DataManager.telemetryData[1][DatasetUtils.datasetColumns.IndexOf("beta_rad")]));

		return new Vector3(u, v, w);
	}

	void Start()
	{
		Vector3 bodyVelocities = CalculateBodyVelocities();
		Debug.Log($"u: {bodyVelocities.x}, v: {bodyVelocities.y}, w: {bodyVelocities.z}");
	}
}
