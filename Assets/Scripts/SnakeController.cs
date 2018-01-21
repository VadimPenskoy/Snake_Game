using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

[System.Serializable]
public class SnakeController : MonoBehaviour
{
    Score score;
    Saver saver;
    InputHandler input;
    Direction inputDirection;
    public GameObject tailPrefab;
    Vector2 dir;
    List<Transform> tail = new List<Transform>();
    bool ate = false;

    public Image scoreImage1;
    public Image scoreImage2;
    public Image scoreImage3;

    void Awake()
    {
        Saver saver = new Saver();
        saver.saveScore(0);
        string color = saver.loadColor();
        switch (color)
        {
            default:
            case "White":
                this.GetComponent<SpriteRenderer>().color = Color.white;
                this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "Red":
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "Green":
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case "Blue":
                this.GetComponent<SpriteRenderer>().color = new Color(0, 116, 255, 255);
                this.GetComponent<SnakeController>().tailPrefab.GetComponent<SpriteRenderer>().color = new Color(0, 116, 255, 255);
                break;
        }

    }

    void Start()
    {
        Saver saver = new Saver();
        input = new InputHandler();
        float speed = 0.2f / saver.loadSpeed();
        InvokeRepeating("Move", speed, speed);
    }

   
    void Update()
    {
        dir = input.HandleArrows(inputDirection).GetVector();
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }

        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(coll.gameObject);
            saver.saveScore(score.addPoint());
            int[] digits = new int[3];
            for (int i = 0; i < 3; i++)
                digits[i] = 0;

            string strScore = score.ToString();

            int j = strScore.Length - 1;
            for (int i = 2; i >= 0; i--)
            {
                digits[i] = strScore[j] - '0';
                j--;
                if (j < 0)
                    break;
            }

            scoreImage1.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>(string.Format("sprites/{0}", digits[2]));
            scoreImage2.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>(string.Format("sprites/{0}", digits[1]));
            scoreImage3.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>(string.Format("sprites/{0}", digits[0]));
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}



