using UnityEngine;

public class VehicleVisualization : MonoBehaviour
{
	// Calculate position and rotation for every data row
	public void VisualizePlaneLocationAndRotation(float quat_ex, float quat_ey, float quat_ez, float quat_e0, float timeGap)
	{
		transform.position = Vector3.Lerp(transform.position, new Vector3(GeoToNED.north, GeoToNED.down, GeoToNED.east), timeGap);
		transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0), timeGap);
	}
}
