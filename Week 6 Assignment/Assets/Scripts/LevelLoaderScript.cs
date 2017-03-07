using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour {

	public float offsetX = 0;
	public float offsetY = 0;

	public string[] fileNames;

	public static int levelNum = 0;


	// Use this for initialization
	void Start () {
		string fileName = fileNames[levelNum];

		string filePath = Application.dataPath + "/" + fileName;

		StreamReader sr = new StreamReader(filePath);

		GameObject levelHolder = new GameObject("Level Holder");

		int yPos = 0;

		GameObject player = Instantiate(Resources.Load("Prefabs/Player") as GameObject);

		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			for(int xPos = 0; xPos < line.Length; xPos++){
				if(line[xPos] == 'x'){
					//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

					GameObject obstacleHorizontal = Instantiate(Resources.Load("Prefabs/Obstacle1") as GameObject);

					obstacleHorizontal.transform.parent = levelHolder.transform;

					obstacleHorizontal.transform.position = new Vector3(xPos + offsetX, yPos + offsetY, 0);
				}

				if(line[xPos] == 'y'){
					
					GameObject obstacleVertical = Instantiate(Resources.Load("Prefabs/Obstacle2") as GameObject);

					obstacleVertical.transform.parent = levelHolder.transform;

					obstacleVertical.transform.position = new Vector3(xPos + offsetX, yPos + offsetY, 0);
				}

				if(line[xPos] == '+'){
					
					GameObject obstacleCross = Instantiate(Resources.Load("Prefabs/Obstacle3") as GameObject);

					obstacleCross.transform.parent = levelHolder.transform;

					obstacleCross.transform.position = new Vector3(xPos + offsetX, yPos + offsetY, 0);
				}

				if(line[xPos] == 'r'){
					
					GameObject obstacleRotating = Instantiate(Resources.Load("Prefabs/ObstacleRotating") as GameObject);

					obstacleRotating.transform.parent = levelHolder.transform;

					obstacleRotating.transform.position = new Vector3(xPos + offsetX, yPos + offsetY, 0);
				}

				if(line[xPos] == 'o'){
					
					GameObject points = Instantiate(Resources.Load("Prefabs/Points") as GameObject);

					points.transform.parent = levelHolder.transform;

					points.transform.position = new Vector3(xPos + offsetX, yPos + offsetY, 0);
				}

				if(line[xPos] == 'P'){
					player.transform.position = new Vector3(
						xPos + offsetX, yPos + offsetY, 0);
				}

			}
			yPos--;
		}
		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			levelNum++;
			SceneManager.LoadScene("LevelBuilder");
		}
	}
}
