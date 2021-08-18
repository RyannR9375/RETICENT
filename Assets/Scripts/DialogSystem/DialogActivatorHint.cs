using UnityEngine;

public class DialogActivatorHint : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject;
    
    public GameObject EButton;
    public GameObject Hint;

    public void UpdateDialogObject(DialogObject dialogObject)
    {
        this.dialogObject = dialogObject;
    }

    public bool isPaused = false;
    public void SwitchPause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        isPaused = isPaused = true ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player)) //checks for player tag and component
        {
            player.Interactable = this;
            EButton.SetActive(true);

            SwitchPause();
            Hint.SetActive(true);


            if(Input.GetKeyDown("E"))
            {
                EButton.SetActive(false);
            }

        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {
            if(player.Interactable is DialogActivator dialogActivator && dialogActivator == this)
            {
                player.Interactable = null; // in the case that there r multiple activated, it makes sure that its null if its sure that its the current interactable
            }
        }

        EButton.SetActive(false);
    }

    public void Interact(PlayerMovement player)
    {
        foreach(DialogResponseEvents responseEvents in GetComponents<DialogResponseEvents>())
        {
            if(responseEvents.DialogObject == dialogObject)
            {
                player.DialogUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }


        player.DialogUI.ShowDialog(dialogObject);
    }
}
