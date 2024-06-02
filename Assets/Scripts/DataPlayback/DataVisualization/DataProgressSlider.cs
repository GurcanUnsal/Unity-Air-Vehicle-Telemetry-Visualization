using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataProgressSlider : MonoBehaviour, IPointerDownHandler
{
	// Reference to DataPlayer component
	DataPlayer player;
	public void OnPointerDown(PointerEventData eventData)
	{
		player = GameObject.Find("DataPlayer").GetComponent<DataPlayer>();
		player.StopData(); // Stop the coroutine

		float startFrom = Mathf.Floor(this.GetComponent<Slider>().value); // Calculate start time

		player.StartData(startFrom); // Start the coroutine with the start time
	}
}
