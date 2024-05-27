using UnityEngine;

public class QuaternionToEuler : MonoBehaviour
{
	float quat_e0 = Dataset.telemetryData[0][Dataset.columns.IndexOf("quat_e0")];
	float quat_ex = Dataset.telemetryData[0][Dataset.columns.IndexOf("quat_ex")];
	float quat_ey = Dataset.telemetryData[0][Dataset.columns.IndexOf("quat_ey")];
	float quat_ez = Dataset.telemetryData[0][Dataset.columns.IndexOf("quat_ez")];
	
    private Vector3 eulerAngles;

	void Start()
    {
		Quaternion quaternion = new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0);
		Debug.Log(quaternion.ToString());
        eulerAngles = quaternion.eulerAngles;

		Debug.Log("Euler Açýlarý: " + eulerAngles);

		Debug.Log(Dataset.telemetryData[0][5]);
		

		foreach (var column in Dataset.columns)
		{
			Debug.Log(column);
		}

		for (int i = 0; i < 24; i++)
		{
			Debug.Log(Dataset.telemetryData[0][i]);

		}
		
	}
}
