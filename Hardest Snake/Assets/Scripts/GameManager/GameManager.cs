using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum GameState {menu, playing, dead}

	public GameObject menu;
	public GameObject deadMenu;
	public GameObject fruitManager;
	public Text actualScore;
	public Text bestScore;

	private bool usserAction;
	private GameState gameState = GameState.menu;
	private int points;
	private int bestPoints;

	void Start () {
		menu.SetActive (true);
		deadMenu.SetActive (false);
		fruitManager.SetActive (false);
	}

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);

		if (gameState == GameState.menu) {
			if (usserAction) {
				menu.SetActive (false);
				gameState = GameState.playing;
				fruitManager.SetActive (true);
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			IngreasePoints ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && gameState == GameState.playing) {
			gameState = GameState.dead;
			deadMenu.SetActive (true);
			fruitManager.SetActive (false);
		}

		if (gameState == GameState.dead) {
			if (usserAction) {
				RestartScene ();
			}
		}
	}

	void RestartScene () {
		SceneManager.LoadScene ("MainScene");
	}

	void IngreasePoints() {
		points++;
		actualScore.text = points.ToString ();

		if (bestPoints < points) {
			SetBestScore ();
		}
	}

	void SetBestScore() {
		bestPoints = points;
		bestScore.text = bestPoints.ToString ();
	}
}
