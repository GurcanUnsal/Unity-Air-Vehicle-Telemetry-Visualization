using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataProgressSlider : MonoBehaviour, IPointerDownHandler
{
	DataPlayer player; // Reference to DataPlayer component
	public void OnPointerDown(PointerEventData eventData)
	{
		player = GameObject.Find("DataPlayer").GetComponent<DataPlayer>();
		player.StopData(); // Stop the coroutine

		float startFrom = Mathf.Floor(this.GetComponent<Slider>().value); // Calculate start time

		player.StartData(startFrom); // Start the coroutine with the start time
	}
}
