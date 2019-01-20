using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject canvas;
    
    //public Animator textDisplayAnimator;
    //private AudioSource source;

    // Use this for initialization
    void Start () {
        
        //source.GetComponent<AudioSource>();
        canvas.SetActive(true);
        StartCoroutine(Type());
	}

    // Update is called once per frame
    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

	public void nextSentence() {
        //source.Play();
        //textDisplayAnimator.SetTrigger("Change");
        canvas.SetActive(true);
        continueButton.SetActive(false);

		if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if (index == sentences.Length - 1)
        {
            canvas.SetActive(false);
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
	}
}
