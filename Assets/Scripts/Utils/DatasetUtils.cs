using System.Collections.Generic;

public static class DatasetUtils
{
	public static List<string> datasetColumns = new List<string>
	{
		"time_sn", "ctrlong", "ctrlatr", "ax_m_s2", "ay_m_s2", "az_m_s2", "p_rad_s", "q_rad_s", "r_rad_s",
		"quat_e0", "quat_ex", "quat_ey", "quat_ez", "alpha_rad", "beta_rad", "tas_m_s", "de_rad", "dr_rad",
		"da_rad", "mass_kg", "thrust_N", "lat_rad", "lon_rad", "alt_m"
	};
}
