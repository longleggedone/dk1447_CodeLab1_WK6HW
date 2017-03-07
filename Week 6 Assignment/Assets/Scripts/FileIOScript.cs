using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class FileIOScript : MonoBehaviour {

	public static FileIOScript instance;

	public List<string> highScoreNames;
	public List<string> highScoreValues;

	public const string FILE_NAME = "highScores.txt";
	private string finalFilePath;

	// Use this for initialization
	void Start () {
		finalFilePath = Application.dataPath + "/" + FILE_NAME;
		if (instance == null){
			instance = this;
			DontDestroyOnLoad(this);
		}
		else{
			Destroy(gameObject);
		}

	
	}

	public void SaveHighScore(string name, string newHighScore){
		StreamWriter sw = new StreamWriter(finalFilePath, false);
		sw.WriteLine(newHighScore);
		sw.Close();
	}

	public void ReadHighScores(){
		StreamReader sr = new StreamReader(finalFilePath);

		int i = 0;

		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			string[] splitLine = line.Split(' ');

			string name = splitLine[0];
			string value = splitLine[1];

			Debug.Log("name: " + name);
			Debug.Log("value: " + value);

			highScoreNames.Add(name);
			highScoreValues.Add(value);

			i++;
		}

		sr.Close();
	}
}
