using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public enum NumScoreLevel {
		ToFar = 0,
		Near,
		Correct
	}


	public NumScoreLevel currentScoreLevel = NumScoreLevel.ToFar;
	private int currentNumber = 0;
	public int ProduceGameNumber() {
		currentNumber = Random.Range (0, 100);
		return  currentNumber;
	}

	public NumScoreLevel CompareNumber(int guessNumber){
		if (Mathf.Abs (guessNumber - currentNumber) > 5) {
			currentScoreLevel = NumScoreLevel.ToFar;
		} else if (Mathf.Abs (guessNumber - currentNumber) <= 5&&Mathf.Abs (guessNumber - currentNumber)>0) {
			currentScoreLevel = NumScoreLevel.Near;
		} else {
			currentScoreLevel = NumScoreLevel.Correct;
		}
		return currentScoreLevel;
	}

	                                
}
