using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {
	bool check;
	bool stop;
	public Player player;
	public Camera mainCam;
	public GameObject tile;
	public GameObject spawnPoint;
	public Blocker blocker;
	int spawnCount;
	int climbCount;
	int scoreCount;
	public bool start;
	public bool offCooldown;
	public bool isTooClose;
	public Ender ender;
	public Text scoreText;
	public Text highscoreText;
	public Text result;
	public Text speedText;
	public GameObject instance;
	public GameObject endMenu;
	public GameObject mainMenu;
	public TileMaterials tileMats;
	bool end;
	public float gamespeed;
	void Start () {
		
		FindObjectOfType<AudioManager>().Play("Theme");
		spawnCount = 0;
		start = false;
		offCooldown = true;
		mainMenu.SetActive(true);
		instance.SetActive(false);
		Time.timeScale = 0.0F;
		scoreText.text = "";
		highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0) && offCooldown && !isTooClose && start){
			offCooldown = false;
			SpawnTile();
			
			
			Invoke("CooldownSpawn",1f);
		}
		if (start){
			
			Time.timeScale = 1.0F;
			instance.SetActive(true);
			mainCam.transform.Translate(new Vector3(0,gamespeed,0));
			GetUpdateScore();
			CheckDistance();
			CheckEndgame();
			mainMenu.SetActive(false);	
		}			
		if(end){

			start = false;
			Time.timeScale = 0.0f;
			endMenu.SetActive(true);
			result.text = PlayerPrefs.GetInt("HighScore",0).ToString();
			instance.SetActive(false);
			spawnPoint.SetActive(false);
		}	

	}

    private void CheckEndgame()
    {
		end = ender.GetEnder();
		if(end){
			FindObjectOfType<AudioManager>().Play("Death");
		}
		
    }

    private void CheckDistance()
    {
        bool notBlocked = blocker.GetSpawnable();
		if(notBlocked){
			isTooClose = false;
		}else{
			isTooClose = true;
		}
    }

    private void GetUpdateScore()
    {
		bool score = player.GetScored();
		if (score){
			scoreCount +=1;
			ScoreUpdate();
		}
    }

    private void ScoreUpdate()
    {
		scoreText.text = scoreCount.ToString();
		if (scoreCount > PlayerPrefs.GetInt("HighScore",0)){
			PlayerPrefs.SetInt("HighScore",scoreCount);
			highscoreText.text = scoreCount.ToString();
		}
		if (scoreCount % 10 == 0){
			SpeedUp();
			FindObjectOfType<AudioManager>().Play("SpeedUp");
		}
    }
	

    void SpawnTile(){
		
		GameObject newTile = Instantiate(tile,spawnPoint.transform.position,spawnPoint.transform.rotation);
		Renderer mat = newTile.GetComponent<Renderer>();
		
		mat.material = tileMats.tileMaterials[UnityEngine.Random.Range(0,6)];
		
		spawnCount+=1;
		
	}
	void CooldownSpawn(){
		
		offCooldown = true;
	}

	void SpeedUp(){
		gamespeed += 0.05f;
		speedText.text = "SPEED UP!!";
		StartCoroutine(SpeedUpText());
		
		
	}
	IEnumerator SpeedUpText(){
		yield return new WaitForSeconds(2);
		speedText.text = "";
		Debug.Log("game speed up");
	}

	public void StartGame()	{
		start = true;
		FindObjectOfType<AudioManager>().Play("SpeedUp");
		SpawnTile();
	}
	public void Retry() {
     	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 	}

	public void ResetScore(){
		PlayerPrefs.DeleteAll();
		highscoreText.text = "0";
	}
}
