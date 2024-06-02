using UnityEngine;

public class VehicleVisualization : MonoBehaviour
{
	private const float EarthRadius = 6371000f;

	public void VisualizePlaneLocationAndRotation(float lat_rad, float lon_rad, float alt_m, float quat_ex, float quat_ey, float quat_ez, float quat_e0, float timeGap)
	{
		float x = (EarthRadius + alt_m) * Mathf.Cos(lat_rad) * Mathf.Cos(lon_rad);
		float z = (EarthRadius + alt_m) * Mathf.Cos(lat_rad) * Mathf.Sin(lon_rad);
		float y = (EarthRadius + alt_m) * Mathf.Sin(lat_rad);


		transform.SetPositionAndRotation(Vector3.Lerp(transform.position, new Vector3(x, y, z), timeGap) * Time.deltaTime, 
										Quaternion.Slerp(transform.rotation, new Quaternion(quat_ex, quat_ey, quat_ez, quat_e0), timeGap * Time.deltaTime));

	}
}