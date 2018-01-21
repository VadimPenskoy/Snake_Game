using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour {
    Saver saver = new Saver();
	public void whiteClick() {
		saver.saveColor ("White");
	}

	public void redClick() {
        saver.saveColor("Red");
    }

	public void greenClick() {
        saver.saveColor("Green");
    }

	public void blueClick() {
        saver.saveColor("Blue");
    }
}
