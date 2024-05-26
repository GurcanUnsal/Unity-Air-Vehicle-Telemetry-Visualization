using UnityEngine;

public class QuaternionToEuler : MonoBehaviour
{
	float quat_e0 = float.Parse(Dataset.telemetryData[1][Dataset.columns.IndexOf("quat_e0")]);
	float quat_ex = float.Parse(Dataset.telemetryData[1][Dataset.columns.IndexOf("quat_ex")]);
	float quat_ey = float.Parse(Dataset.telemetryData[1][Dataset.columns.IndexOf("quat_ey")]);
	float quat_ez = float.Parse(Dataset.telemetryData[1][Dataset.columns.IndexOf("quat_ez")]);
	
    private Vector3 eulerAngles;

	void Start()
    {
		Quaternion quaternion = new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0);
		Debug.Log(quaternion.ToString());
        eulerAngles = quaternion.eulerAngles;

		Debug.Log("Euler Açýlarý: " + eulerAngles);

		Debug.Log(Dataset.telemetryData[1][5]);
	}
}
