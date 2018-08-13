
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public string sceneName;
    public string currentLevel;

    public Scene currentScene;
    public static bool gameStarted = false;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    void Start () {
        DontDestroyOnLoad(gameObject);
	}

    void Update() {
        currentScene = SceneManager.GetActiveScene();
        // SceneName is the name of the current scene
        sceneName = currentScene.name;

    }
}
