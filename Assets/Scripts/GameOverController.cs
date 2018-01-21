using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

    Saver saver;
    public Image scoreImage1;
	public Image scoreImage2;
	public Image scoreImage3;

	void Start () {
        Saver saver = new Saver();
        int score = saver.loadScore();

		int[] digits = new int[3];
		for (int i = 0; i < 3; i++)
			digits[i] = 0;
		
		string strScore = score.ToString ();
		
		int j = strScore.Length - 1;
		for (int i = 2; i >= 0; i--) {
			digits[i] = strScore[j] - '0';
			j--;
			if (j < 0)
				break;
		}
		
		scoreImage1.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite>(string.Format ("sprites/{0}", digits[2]));
		scoreImage2.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite>(string.Format ("sprites/{0}", digits[1]));
		scoreImage3.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite>(string.Format ("sprites/{0}", digits[0]));
	}

}
