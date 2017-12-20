using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	static private Player instance;
	static public Player Instance{
		get{ 
			if (instance == null) {
				instance = new Player ();
			}
			return instance;
		}
	}
	private Player(){

	}

	public UIController uiCtrl;

	private int score = 0;
	private int life = 4;

	public int Score{
		get{ return score; }
		set{ 
			score = value;
			uiCtrl.updateUI();
		}

	}

	public int Life{
		get{ return life; }
		set{ 
			life = value;

			if (life <= 0)
				uiCtrl.GameOver ();

			uiCtrl.updateUI();
			}
	}
}
