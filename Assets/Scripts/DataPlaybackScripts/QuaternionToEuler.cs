using UnityEngine;

public class QuaternionToEuler : MonoBehaviour
{
	float quat_e0 = float.Parse(DataManager.telemetryData[115][DatasetUtils.datasetColumns.IndexOf("quat_e0")]);
	float quat_ex = float.Parse(DataManager.telemetryData[115][DatasetUtils.datasetColumns.IndexOf("quat_ex")]);
	float quat_ey = float.Parse(DataManager.telemetryData[115][DatasetUtils.datasetColumns.IndexOf("quat_ey")]);
	float quat_ez = float.Parse(DataManager.telemetryData[115][DatasetUtils.datasetColumns.IndexOf("quat_ez")]);
	
    private Vector3 eulerAngles;

	void Start()
    {
		Quaternion quaternion = new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0);
		Debug.Log(quaternion.ToString());
        eulerAngles = quaternion.eulerAngles;

		Debug.Log("Euler Açýlarý: " + eulerAngles);

		Debug.Log(DataManager.telemetryData[1][5]);
	}
}
