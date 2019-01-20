using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public Button startButton;

	// Use this for initialization
	void Start () {
        Button button = startButton.GetComponent<Button>();
        button.onClick.AddListener(startGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void startGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
