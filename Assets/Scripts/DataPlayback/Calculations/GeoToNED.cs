using UnityEngine;
using TMPro;

public class GeoToNED : MonoBehaviour
{
	// Reference to the text game object
	private TextMeshProUGUI geoToNEDText;

	// Radius of earth
	private const float EarthRadius = 6378137.0f;

	public static float north;
	public static float east;
	public static float down;

	private void Awake()
	{
		geoToNEDText = GetComponent<TextMeshProUGUI>();
	}

	// Convert latitude, longitude, and altitude to NED coordinates
	public void LatLonAltToNED(float ref_lat, float ref_lon, float ref_alt, float lat_rad, float lon_rad, float alt_m)
	{
		float dLat = Mathf.Deg2Rad * (lat_rad - ref_lat);
		float dLon = Mathf.Deg2Rad * (lon_rad - ref_lon);

		north = dLat * EarthRadius;
		east = dLon * EarthRadius * Mathf.Cos(Mathf.Deg2Rad * ref_lat);
		down = ref_alt - alt_m;

		geoToNEDText.text = $"North: {string.Format("{0:F2}", north)} East: {string.Format("{0:F2}", east)} Down: {string.Format("{0:F2}", down)}";
	}
}
