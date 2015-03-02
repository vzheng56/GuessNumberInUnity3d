using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Text currentValueText;
	public Text guessNumberText;
	public Text lastConpareInfoText;
	public Text scoreText;

	public GameLogic GameLogicController;
	private int currentScore = 0;

	void Start() {
		scoreText.text = "0";
		StartCoroutine (ChangeNumberText ());
	}

	private int guessNumber = 50;
	public void SliderValueChanged(float value){
		if (currentValueText) {
			guessNumber = (int)value;
			currentValueText.text = "CurrentValue: "+value.ToString("0");
		}
	}

	public void CompareNumberAction() {

		switch (GameLogicController.CompareNumber (guessNumber)) {
		case GameLogic.NumScoreLevel.ToFar:
			lastConpareInfoText.text = "cha de tai duo le ";
			currentScore += 10;
			break;
		case GameLogic.NumScoreLevel.Near:
			lastConpareInfoText.text = "bu cuo ,cha dian cai dui  ";
			currentScore += 100;
			break;
		case GameLogic.NumScoreLevel.Correct:
			lastConpareInfoText.text = "wan quan zheng que!";
			currentScore += 200;
			break;
		}
		scoreText .text ="Score: "+ currentScore.ToString ();
		StartCoroutine (ChangeNumberText ());
	}

	IEnumerator ChangeNumberText()
	{

		yield return new WaitForSeconds (3);
		var currentNumber = GameLogicController.ProduceGameNumber ();
		guessNumberText.text = "Guess: " + currentNumber;
		lastConpareInfoText.text = "nuo dong dao ni cai de  wei zhi";
	}

}
