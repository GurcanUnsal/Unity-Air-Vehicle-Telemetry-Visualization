using TMPro;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour
{
	// Reference to the text game object
	private TextMeshProUGUI velocityCalculatorText;

	private void Awake()
	{
		velocityCalculatorText = GetComponent<TextMeshProUGUI>();
	}

	public void VisualizeBodyVelocities(float alpha, float beta, float tas)
	{
		// Calculations of velocity components
		float u = tas * Mathf.Cos(alpha) * Mathf.Cos(beta);
		float v = tas * Mathf.Sin(beta);
		float w = tas * Mathf.Sin(alpha) * Mathf.Cos(beta);

		velocityCalculatorText.text = $"U: {string.Format("{0:F2}", u)} V: {string.Format("{0:F2}", v)} W: {string.Format("{0:F2}", w)}";
	}
}
