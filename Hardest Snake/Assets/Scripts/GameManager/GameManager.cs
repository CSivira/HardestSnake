using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum GameState {menu, playing, lose,dead}

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

	void Start () {
		menu.SetActive (true);
		deadMenu.SetActive (false);
		fruitManager.SetActive (false);
		snake.SetActive (true);
	}

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);

		if (gameState == GameState.menu) {
			if (usserAction) {
				menu.SetActive (false);
				deadMenu.SetActive (false);
				gameState = GameState.playing;
				fruitManager.SetActive (true);
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
			Dead ();
			if (usserAction) {
				deadMenu.SetActive (false);
				//RestartScene ();
				menu.SetActive (true);
				snake.SetActive (true);
				snake.transform.position = new Vector3 (0f,-1f,0f);
			}
		}

		if (bestPoints < points) {
			SetBestScore ();
		}
	}

	void RestartScene () {
		SceneManager.LoadScene ("MainScene");
	}

	void Dead() {
		deadMenu.SetActive (true);
	}

	void SetBestScore() {
		bestPoints = points;
		bestScore.text = bestPoints.ToString ();
	}
}
