using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Play(){
		Application.LoadLevel("level1");
	}
	public void Menu(){
		Application.LoadLevel("Menu");
	}
	public void Exit(){
		Application.Quit();
	}
	public void Pause(){
		if(Time.timeScale == 1){
			Time.timeScale = 0; 
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
	
	}
	
}
