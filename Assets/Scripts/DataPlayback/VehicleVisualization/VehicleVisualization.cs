using UnityEngine;

public class VehicleVisualization : MonoBehaviour
{
	// Calculate position and rotation for every data row
	public void VisualizePlaneLocationAndRotation(float quat_ex, float quat_ey, float quat_ez, float quat_e0)
	{
		transform.SetPositionAndRotation(new Vector3(GeoToNED.north, GeoToNED.down, GeoToNED.east), new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0));
	}
}
