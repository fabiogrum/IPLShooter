using UnityEngine;
using System.Collections;

public class GameOverDieBehaviour : AbstractDieBehaviour {

	public override void Die (GameObject deadObject)
	{
		GameManager.GetInstance ().GameOver ();
	}




}
