using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    
    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypeWriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogBox();
    }


    public void ShowDialog(DialogObject dialogObject)
    {
        IsOpen = true;
        dialogBox.SetActive(true); // changes visibility of the dialog box to show on start
        StartCoroutine(StepThroughDialog(dialogObject)); // starts the process of typing the text through a dialogObject
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {

        for(int i = 0; i < dialogObject.Dialog.Length; i++)
        {
            string dialog = dialogObject.Dialog[i];

            yield return RunTypingEffect(dialog);

            textLabel.text = dialog;

            if(i == dialogObject.Dialog.Length - 1 && dialogObject.HasResponses) break; //checks if the text is done typing to be able to show or activate responses

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); // Waits till u press space bar to continue the dialog
        }

        if (dialogObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogObject.Responses);
        }
        else
        {
            CloseDialogBox(); // Calls the closedialogbox function once all the dialog is finished
        }
    }

    private IEnumerator RunTypingEffect(string dialog)
    {
        typewriterEffect.Run(dialog, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogBox() //Closes dialog box after finishing dialog
    {
        IsOpen = false;
        dialogBox.SetActive(false);  // changes the visibilty of the dialog UI 
        textLabel.text = string.Empty; // changes the box to show an empty string 
    }

}