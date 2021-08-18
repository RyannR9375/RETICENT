using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialog/DialogObject")]

public class DialogObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialog;
    [SerializeField] private Response[] responses;

    public string[] Dialog => dialog;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;

}
