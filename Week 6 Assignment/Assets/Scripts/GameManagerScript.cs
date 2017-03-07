using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public Text scoreText; //ui text for score

	public Text healthText; //ui text for health

	public string playerName = "PlayerName";
	 
	public GameObject player; //reference to player

	private int scoreToAdvance = 100; //score needed to advance to next level

	private const string PREF_HIGH_SCORE = "highScorePref"; //constant high score

	private int score; //player score

	public int Score{//property for score
		get{
			return score;
		}
		set{
			score = value;
			if(score > HighScore){ //if score exceeds high score
				HighScore = score; //update high score to the new score
			}
			scoreText.text = "Score: " + score;//sets ui text for score to equal current score
			Debug.Log ("Score: " + Score);
		}
	} 

	private int highScore = 0; //high score

	public int HighScore {//property for high score
		get{
			highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE); //sets highScore to equal the saved player pref high score
			return highScore; //returns this highScore
		}
		set{
			highScore = value; 
			PlayerPrefs.SetInt(PREF_HIGH_SCORE, highScore); //sets player constant high score to equal the new high score
			FileIOScript.instance.SaveHighScore(playerName, highScore.ToString());
		}
	}

		
	private const int HEALTH_MIN = 0; //sets constant minimum value for health
	public const int HEALTH_MAX = 5; //sets constant maxiumum value for health

	//public int damageAmt = 1;

	private static int health; //player health

	public int Health{ //property for health
		get{
			return health;
		}

		set{
			health = value;
			healthText.text = "Health: " + health; //sets ui text for health to equal current health

			if(health > HEALTH_MAX){ //keeps health from going above max
				health = HEALTH_MAX;
			}

			if(health < HEALTH_MIN){ //keeps health from going below min
				health = HEALTH_MIN;
			}

			Debug.Log ("Health: " + Health);
		}
	}
		
	public static GameManagerScript instance; //static instance of this class which can be accessed by other scripts

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll();

		if(instance == null){ //checks if instance already exists
			instance = this; //if no instance already exists, make this the instance
			DontDestroyOnLoad(this); //sets this to not be destroyed when a scene is loaded
		}
		else{ //if an instance already exists
			Destroy(this.gameObject); //destroys this
		}

		Score = 0; //sets starting score
		Health = HEALTH_MAX;//sets starting health

		scoreText.text = "Score: " + score; //sets score ui
		healthText.text = "Health: " + health;//sets health ui
	}

	// Update is called once per frame
	void Update () {
		if(Score == scoreToAdvance){ //if the score has reached the necessary value to advance levels
			scoreToAdvance += 100; //increase the necessary score for next time
			player.transform.position = new Vector3 (0,0,0); //zero out player position
			SceneManager.LoadScene("Scene 2"); //load next scene
		}
		if(Health == HEALTH_MIN){ //if health reaches minimum
			Health = HEALTH_MAX;//set health back to maximum
			player.transform.position = new Vector3 (0,0,0);//sero out player position
			SceneManager.LoadScene("Scene 1");//load first scene
		}
	}
}
