using UnityEngine;
using UnityEditor;

    public class Saver
    {
        
        public void saveScore(int score) {
            PlayerPrefs.SetInt("Score", score);
        }
        public int loadScore() {
            return PlayerPrefs.GetInt("Score");
        }
        public void saveSpeed(float speed) {
            PlayerPrefs.SetFloat("Speed", speed);
        }
        public float loadSpeed() {
           return PlayerPrefs.GetFloat("Speed");
        }
        public void saveSpawnRate(float spawnRate) {
            PlayerPrefs.SetFloat("Spawn Rate", spawnRate);
        }
        public float loadSpawnRate() {
            return PlayerPrefs.GetFloat("Spawn Rate");
        }
        public void saveColor(string color) {
            PlayerPrefs.SetString("Color", color);
        }
        public string loadColor() {
            return PlayerPrefs.GetString("Color");
        }


    }
