using UnityEngine;
using System.Collections;

public class ScoreManager : AbstractSingleton<ScoreManager> {
	
	[SerializeField]
	private int score;
	[SerializeField]
	private int highscore;

	private string hiscorePlayerPrefKey;

	public delegate void ScoreAction(int score);
	public event ScoreAction OnScore;
	public event ScoreAction OnHighScore;

	public int GetScore(){
		return score;
	}

	public int GetHiScore(){
		return highscore;
	}

	// set the score and notify the listerners
	public void SetScore(int newScore){
		int scoreDiff = newScore - score;
		score = newScore;
		if (score > highscore) {
			SetHighScore(score);
		}

		NotifyScoreMod (scoreDiff);
	}

	public void SetHighScore(int newHighScore){
		int HighScoreDiff = newHighScore - highscore;
		highscore = newHighScore;

		NotifyHighScoreMod (HighScoreDiff);

		SaveHighScore ();
	}

	public void AddScore(int scoreDiff){
		SetScore (score + scoreDiff);
	}

	private void NotifyScoreMod(int scoreDiff){
		if (OnScore != null) {
			OnScore (scoreDiff);
		}
	}

	private void NotifyHighScoreMod(int scoreDiff){
		if (OnScore != null) {
			OnHighScore (scoreDiff);
		}
	}

	private void SaveHighScore(){
		PlayerPrefs.SetInt (hiscorePlayerPrefKey, highscore);
		PlayerPrefs.Save ();
	}

	private void loadHighScore(){
		highscore = PlayerPrefs.GetInt (hiscorePlayerPrefKey, 0);
	}

	public override void Initialize ()
	{
		hiscorePlayerPrefKey = PlayerPrefsKeys.Keys.HIGHSCORE.TooltipToString();
		loadHighScore ();
	}

		
}
