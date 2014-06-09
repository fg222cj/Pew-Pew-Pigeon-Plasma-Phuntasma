using UnityEngine;
using System.Collections;

// Till stor del hämtat från kodexempel i Unitys wiki - http://wiki.unity3d.com/index.php?title=PauseMenu

public class PauseMenu : MonoBehaviour
{
	
	public GUISkin skin;

	private float startTime = 0.1f;
	
	public Material mat;
	
	private long tris = 0;
	private long verts = 0;
	private float savedTimeScale;

	public GameObject start;
	
	public string url = "Builds.html";
	
	public Color statColor = Color.yellow;
	
	public string[] credits= {
		"Pew Pew Pigeon Plasma Phuntasma",
		"Skapat av Fabian Gillholm"} ;
	public Texture[] crediticons;
	
	public enum Page {
		None,Main,Options,Credits
	}
	
	private Page currentPage;
	
	private int toolbarInt = 0;
	private string[]  toolbarstrings =  {};

	private GameObject[] GUIElements;
	
	
	void Start() {
		GUIElements = GameObject.FindGameObjectsWithTag("GUI");
		Time.timeScale = 1;
		PauseGame();
	}
	
	static bool IsDashboard() {
		return Application.platform == RuntimePlatform.OSXDashboardPlayer;
	}
	
	static bool IsBrowser() {
		return (Application.platform == RuntimePlatform.WindowsWebPlayer ||
		        Application.platform == RuntimePlatform.OSXWebPlayer);
	}
	
	void LateUpdate () {
		
		if (Input.GetKeyDown("escape")) 
		{
			switch (currentPage) 
			{
			case Page.None: 
				PauseGame(); 
				break;
				
			case Page.Main: 
				if (!IsBeginning()) 
					UnPauseGame(); 
				break;
				
			default: 
				currentPage = Page.Main;
				break;
			}
		}

		if (Input.GetKeyDown("return")) 
		{
			switch (currentPage) 
			{
			case Page.Main: 
				UnPauseGame(); 
				break;
			}
		}
	}
	
	void OnGUI () {
		if (skin != null) {
			GUI.skin = skin;
		}

		if (IsGamePaused()) {
			GUI.color = statColor;
			switch (currentPage) {
			case Page.Main: MainPauseMenu(); break;
			case Page.Options: ShowToolbar(); break;
			case Page.Credits: ShowCredits(); break;
			}
		}   
	}
	
	void ShowToolbar() {
		BeginPage(300,300);
		toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarstrings);
		switch (toolbarInt) {
		case 0: VolumeControl(); break;
		//case 3: ShowDevice(); break;
		//case 1: Qualities(); QualityControl(); break;
		//case 2: StatControl(); break;
		}
		EndPage();
	}
	
	void ShowCredits() {
		BeginPage(300,300);
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		foreach( Texture credit in crediticons) {
			GUILayout.Label(credit);
		}
		EndPage();
	}
	
	void ShowBackButton() {
		if (GUI.Button(new Rect(280, Screen.height - 500, 50, 20),"Back")) {
			currentPage = Page.Main;
		}
	}

	void VolumeControl() {
		GUILayout.Label("Volume");
		AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0, 1);
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}
	
	bool IsBeginning() {
		return (Time.time < startTime);
	}
	
	
	void MainPauseMenu() {
		BeginPage(200,200);
		if (GameObject.Find ("Player") != null) {
						if (GUILayout.Button (IsBeginning () ? "New Game" : "Continue")) {
								UnPauseGame ();
			
						}
				}
		if (GUILayout.Button ("Options")) {
			currentPage = Page.Options;
		}

		if (!IsBeginning() && GUILayout.Button ("Restart")) {
			Application.LoadLevel(Application.loadedLevel);
		}

		EndPage();
	}
	
	void GetObjectStats() {
		verts = 0;
		tris = 0;
		GameObject[] ob = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		foreach (GameObject obj in ob) {
			GetObjectStats(obj);
		}
	}
	
	void GetObjectStats(GameObject obj) {
		Component[] filters;
		filters = obj.GetComponentsInChildren<MeshFilter>();
		foreach( MeshFilter f  in filters )
		{
			tris += f.sharedMesh.triangles.Length/3;
			verts += f.sharedMesh.vertexCount;
		}
	}
	
	public void PauseGame() {
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;

		foreach(GameObject element in GUIElements)
		{
			element.SetActive(true);
		}

		currentPage = Page.Main;
	}
	
	void UnPauseGame() {
		Time.timeScale = savedTimeScale;
		AudioListener.pause = false;

		foreach(GameObject element in GUIElements)
		{
			element.SetActive(false);
		}

		currentPage = Page.None;
		
		if (IsBeginning() && start != null) {
			start.SetActive(true);
		}
	}
	
	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}
	
	void OnApplicationPause(bool pause) {
		if (IsGamePaused()) {
			AudioListener.pause = true;
		}
	}
}