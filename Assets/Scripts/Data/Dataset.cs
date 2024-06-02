using System.Collections.Generic;

public static class Dataset
{
	public static List<string> expectedColumns = new List<string> // Variable declaration for column check
	{
		"time_sn", "ctrlong", "ctrlatr", "ax_m_s2", "ay_m_s2", "az_m_s2", "p_rad_s", "q_rad_s", 
		"r_rad_s", "quat_e0", "quat_ex", "quat_ey", "quat_ez", "alpha_rad", "beta_rad", "tas_m_s",
		"de_rad", "dr_rad", "da_rad", "mass_kg", "thrust_N_1", "lat_rad", "lon_rad", "alt_m"
	}; 

	public static List<string> columns = new List<string>(); // Variable declaration for dataset columns

	public static List<List<float>> telemetryData = new List<List<float>>(); // Variable declaration for telemetry data
}
