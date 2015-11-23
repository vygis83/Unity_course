using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	// Use this for initialization
	int max;
	int min;
	int guess;

	public int maxGuesses = 10;
	public Text text;
			
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		NextGuess();
	}

	public void GuessHigher(){
		min = guess;
		NextGuess();
	}

	public void GuessLower(){
		max = guess;
		NextGuess();
	}

	void NextGuess () {
		if (maxGuesses <= 0) {
			Application.LoadLevel ("Win");
		} else {
			maxGuesses = maxGuesses - 1;
			guess = Random.Range(min, max+1);
			text.text = guess.ToString();
		}
	}
}
