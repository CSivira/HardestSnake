using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {menu, playing, lose,dead}

public class GameManager : MonoBehaviour {

	public GameObject menu;
	public GameObject deadMenu;
	public GameObject fruitManager;
	public GameObject snake;

	public GameObject MenuSound;
	public GameObject InGameSound;
	public GameObject FruitSound;
	public GameObject DeadSound;

	public Text actualScore;
	public Text bestScore;
	public static GameState gameState = GameState.menu;
	public static int points;

	private bool usserAction;
	private bool usserQuit;
	private int bestPoints;
	private int actualPoints;

	void Start () {
		points = 0;
		actualPoints = points;
		menu.SetActive (true);
		deadMenu.SetActive (false);
		fruitManager.SetActive (false);
		snake.SetActive (true);
	}

	void Desactivate() {
		FruitSound.SetActive(false);
	}

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);
		usserQuit = Input.GetKeyDown ("q");

		if (points > actualPoints) {
			actualPoints = points;
			FruitSound.SetActive(true);
			Invoke ("Desactivate", 15f*Time.deltaTime);
		}

		if (gameState == GameState.menu) {
			deadMenu.SetActive (false);
			if (usserAction) {
				menu.SetActive (false);
				gameState = GameState.playing;
				fruitManager.SetActive (false);
				snake.SetActive (true);
				DeadSound.SetActive(false);
				MenuSound.SetActive(true);
			}
			if (usserQuit) {
				Debug.Log ("Quit!");
				Application.Quit ();
			}
		}

		if (gameState == GameState.playing) {
			deadMenu.SetActive (false);
			fruitManager.SetActive (true);
			snake.SetActive (true);
			MenuSound.SetActive(false);
			InGameSound.SetActive(true);

		}

		if (gameState == GameState.dead) {
			actualScore.text = points.ToString ();
			fruitManager.SetActive (false);
			deadMenu.SetActive (true);
			InGameSound.SetActive(false);
			DeadSound.SetActive(true);


			if (usserAction) {
				gameState = GameState.menu;
				SceneManager.LoadScene ("MainScene");
			}
		}
	}
}
