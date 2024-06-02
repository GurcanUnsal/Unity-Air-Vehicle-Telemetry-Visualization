using TMPro;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour
{
	private TextMeshProUGUI velocityCalculatorText;

	private void Awake()
	{
		velocityCalculatorText = GetComponent<TextMeshProUGUI>();
	}

	public void VisualizeBodyVelocities(float alpha_rad, float beta_rad, float tas_m_s)
	{
		float u = tas_m_s * Mathf.Cos(alpha_rad) * Mathf.Cos(beta_rad);
		float v = tas_m_s * Mathf.Sin(beta_rad);
		float w = tas_m_s * Mathf.Sin(alpha_rad) * Mathf.Cos(beta_rad);

		velocityCalculatorText.text = $"Body Velocities: U: {string.Format("{0:F2}", u)} V: {string.Format("{0:F2}", v)} W: {string.Format("{0:F2}", w)}";
	}
}
