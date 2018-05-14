using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InteractionObject InteractionObject { get; set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Interaction();
    }

    private void Interaction()
    {
        if (InteractionObject == null)
            return;

        InteractionObject.Interaction();
    }
}