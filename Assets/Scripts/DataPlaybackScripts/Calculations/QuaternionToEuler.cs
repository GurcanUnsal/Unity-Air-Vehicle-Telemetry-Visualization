using UnityEngine;
using TMPro;

public class QuaternionToEuler : MonoBehaviour
{
	private TextMeshProUGUI quaternionToEulerText;

    private Vector3 eulerAngles;
	private Quaternion quaternion;

	private void Awake()
	{
		quaternionToEulerText = GetComponent<TextMeshProUGUI>();
	}

	public void VisualizeQuaternionToEuler(float quat_e0, float quat_ex, float quat_ey, float quat_ez)
	{
		quaternion = new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0);
		eulerAngles = quaternion.eulerAngles;

		quaternionToEulerText.text = $"Euler Angles: {eulerAngles}";
	}
}
