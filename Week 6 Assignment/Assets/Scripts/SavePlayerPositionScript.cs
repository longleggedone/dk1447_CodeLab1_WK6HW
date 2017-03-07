using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SavePlayerPositionScript : MonoBehaviour {

	public bool loadPlayer = false;

	public string fileName;

	string filePath;

	const char DELIMITER = '|';

	// Use this for initialization
	void Start () {
		filePath = Application.dataPath + "/" + fileName;

		if(File.Exists(filePath) && loadPlayer){
			StreamReader sr = new StreamReader(filePath);

			string line = sr.ReadLine();

			sr.Close();

			string[] splitLine = line.Split(DELIMITER);

			transform.position = new Vector3(float.Parse(splitLine[0]), float.Parse(splitLine[1]), float.Parse(splitLine[2]));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Vector3 playerPos = transform.position;

			StreamWriter sw = new StreamWriter(filePath, false);

			sw.WriteLine("" + playerPos.x + DELIMITER + playerPos.y + DELIMITER + playerPos.z);

			sw.Close();
		}
	}
}
