using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerDownHandler
{

    private static DialogManager instance;
    public static DialogManager Instance { get { return instance; } }




    public TextMeshProUGUI dialogueText;
    public GameObject nextText;
    public CanvasGroup dialogueGroup;

    public Queue<string> sentences = new Queue<string>();

    public string currnetSentence;

    public float typingSpeed = 0.05f;
    public float applyTypingSpeed;

    bool isTyping;
    public bool isTutorial;

    [Header("TEST")]
    public bool Test;
    public string[] testSentence;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        applyTypingSpeed = typingSpeed;
        if (Test)
            Ondialogue(testSentence);
    }
    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }

        dialogueGroup.alpha = 1;
        dialogueGroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        applyTypingSpeed = typingSpeed;
        if (sentences.Count != 0)
        {
            currnetSentence = sentences.Dequeue();
            isTyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currnetSentence));
            isTutorial = true;
        }
        else
        {
            dialogueGroup.alpha = 0;
            dialogueGroup.blocksRaycasts = false;
            isTutorial = false;
        }
    }


    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(applyTypingSpeed);
        }
    }

    void Update()
    {
        // ве??? ???? й°во
        if (dialogueText.text.Equals(currnetSentence))
        {
            nextText.SetActive(true);
            isTyping = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isTyping)
            NextSentence();
        else
            applyTypingSpeed = 0;
    }
}