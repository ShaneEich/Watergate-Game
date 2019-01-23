using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {

    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject canvas;
    
    //public Animator textDisplayAnimator;
    //private AudioSource source;

    // Use this for initialization
    void Start () {

        //source.GetComponent<AudioSource>();
        if (sentences.Length != 0)
        {
            canvas.SetActive(true);
            StartCoroutine(Type());
        }

	}

    // Update is called once per frame
    private void Update()
    {
        if(sentences.Length != 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //StopAllCoroutines();
                //nextSentence();
            }
            if (textDisplay.text == sentences[index])
            {
                //if (Input.GetKey(KeyCode.Space))
                // {
                //StopAllCoroutines();
                nextSentence();
               // }
                //continueButton.SetActive(true);
            }
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(2);
    }

	public void nextSentence() {
        //source.Play();
        //textDisplayAnimator.SetTrigger("Change");
        canvas.SetActive(true);
        // continueButton.SetActive(false);
        textDisplay.text = "";
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StopAllCoroutines();
            StartCoroutine(Type());
        }
        else if (index == sentences.Length - 1)
        {
            canvas.SetActive(false);
        }
        else if (index == null)
        {
            canvas.SetActive(false);
        }
        else
        {
            textDisplay.text = "";
            //continueButton.SetActive(false);
        }
	}
}
