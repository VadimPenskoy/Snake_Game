using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    Saver saver;
	public Slider sliderSpeed;
	public Slider sliderSpawnRate;
    
	void Awake() {
	
	}

	public void clickStart() {
		SceneManager.LoadScene ("Play");
		
	}

	public void clickOptions() {
        SceneManager.LoadScene("Options");
		
	}

	public void clickReturn() {
        SceneManager.LoadScene("Start");
	
	}

	public void clickOptionsReturn() {
        Saver saver = new Saver();
        saver.saveSpeed (sliderSpeed.value);
		saver.saveSpawnRate (sliderSpawnRate.value);
		clickReturn ();
	}
}
