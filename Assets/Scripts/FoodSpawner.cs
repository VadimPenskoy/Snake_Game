using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

    Saver saver;
	public GameObject foodPrefab;

	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;


	void Spawn() {
		
		int x = (int)Random.Range (borderLeft.position.x + 0.1f, borderRight.position.x - 0.1f);
		int y = (int)Random.Range (borderBottom.position.y + 0.1f, borderTop.position.y - 0.1f);

		Instantiate (foodPrefab, new Vector2(x, y), Quaternion.identity);

	}

	void Start() {
        Saver saver = new Saver();
        float spawnRate = 4.0f / saver.loadSpawnRate();
		InvokeRepeating ("Spawn", 3, spawnRate);
	}
}
