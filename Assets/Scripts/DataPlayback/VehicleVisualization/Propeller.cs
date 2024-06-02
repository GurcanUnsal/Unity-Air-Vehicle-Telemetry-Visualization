using UnityEngine;

public class Propeller : MonoBehaviour
{
    public static bool shouldTurn = true;
    void Update()
    {
        if (shouldTurn)
        {
			transform.Rotate(500f * Time.deltaTime, 0f, 0f); // Just for visualizing the propeller
		}
    }
}
