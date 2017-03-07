using UnityEngine;
using System.Collections;

public class CollectPointsScript : MonoBehaviour {

	public GameManagerScript gameManager; //reference to game manager

	public int pointsValue = 10; //number of points to award

	public int damageValue = 1; //number of damage to incur

	public static CollectPointsScript instance;//static instance of this class which can be accessed by other scripts

	void Start(){
		if(instance == null){//checks if instance already exists
			instance = this;//if no instance already exists, make this the instance
			DontDestroyOnLoad(this);//sets this to not be destroyed when a scene is loaded
		}
		else{//if an instance already exists
			Destroy(this.gameObject);//destroys this
		}
	}


	void OnCollisionEnter2D (Collision2D other){ //when this object collides with another object
		//Debug.Log ("collided");
		if (other.gameObject.tag == "Points") //if the other object has the points tag
		{
			Destroy(other.gameObject); //destory the other object
			gameManager.Score += pointsValue; //increase points by value
		}
		if (other.gameObject.tag == "Obstacle"){ //if the other object has the obstacle tag
			gameManager.Health -= damageValue; //reduce health by value
		}
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Points") //if the other object has the points tag
		{
			Destroy(other.gameObject); //destory the other object
			gameManager.Score += pointsValue; //increase points by value
		}
		if (other.gameObject.tag == "Obstacle"){ //if the other object has the obstacle tag
			gameManager.Health -= damageValue; //reduce health by value
		}
	}
}
