using UnityEngine;
using System.Collections;

public class SingletonGenericScript : MonoBehaviour {

	public static SingletonGenericScript instance;

	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this);
		}
		else{
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
