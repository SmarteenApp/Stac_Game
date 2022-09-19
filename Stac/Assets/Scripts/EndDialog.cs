using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndDialog : MonoBehaviour
{
    [SerializeField] string[] sentence;
    [SerializeField] TMP_Text dialogText;

    Coroutine endCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        if (sentence != null)
        {
            DialogManager.Instance.Ondialogue(sentence);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(dialogText.text == "fin." && endCoroutine == null)
        {
            endCoroutine =  StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
