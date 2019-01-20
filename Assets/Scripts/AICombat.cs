using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AICombat : MonoBehaviour {
    public Collider attackCollider;
    public bool isGuard = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KOGuard()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider attackCollider)
    {
        if (attackCollider.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
