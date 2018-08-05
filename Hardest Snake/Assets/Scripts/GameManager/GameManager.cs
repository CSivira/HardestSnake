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
	public AudioClip[] clips;
	private AudioSource player;

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
		player = GetComponent<AudioSource>();
	}

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);

		if (points > actualPoints) {
			actualPoints = points;
			player.clip = clips[2];
			player.Play();
		}

		if (gameState == GameState.menu) {
			deadMenu.SetActive (false);
			if (usserAction) {
				menu.SetActive (false);
				gameState = GameState.playing;
				fruitManager.SetActive (false);
				snake.SetActive (true);
			}
			player.clip = clips[0];
			player.Play();
		}

		if (gameState == GameState.playing) {
			deadMenu.SetActive (false);
			fruitManager.SetActive (true);
			snake.SetActive (true);
			player.clip = clips[1];
			player.Play();
		}

		if (gameState == GameState.dead) {
			actualScore.text = points.ToString ();
			fruitManager.SetActive (false);
			deadMenu.SetActive (true);
			player.clip = clips[3];
			player.Play();
			if (usserAction) {
				gameState = GameState.menu;
				SceneManager.LoadScene ("MainScene");
			}
		}
	}
}
