using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {menu, playing, lose,dead}

public class GameManager : MonoBehaviour {

	public GameObject menu;
	public GameObject deadMenu;
	public GameObject fruitManager;
	public GameObject snake;
	public Text actualScore;
	public Text bestScore;
	public static GameState gameState = GameState.menu;
	public static int points;

	private bool usserAction;
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

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);

		if (points > actualPoints) {
			//Aqui se verifica si se incrementaron los puntos
			//Por lo tanto acabamos de comer una fruta
			//Pon aqui el sonido de comer fruta
			actualPoints = points;
		}

		if (gameState == GameState.menu) {
			deadMenu.SetActive (false);
			if (usserAction) {
				menu.SetActive (false);
				gameState = GameState.playing;
				fruitManager.SetActive (false);
				snake.SetActive (true);
			}
		}

		if (gameState == GameState.playing) {
			deadMenu.SetActive (false);
			fruitManager.SetActive (true);
			snake.SetActive (true);
		}

		if (gameState == GameState.dead) {
			actualScore.text = points.ToString ();
			fruitManager.SetActive (false);
			deadMenu.SetActive (true);
			if (usserAction) {
				gameState = GameState.menu;
				SceneManager.LoadScene ("MainScene");
			}
		}
	}
}
