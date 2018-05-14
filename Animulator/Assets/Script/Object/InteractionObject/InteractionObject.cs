using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private PlayerInteraction playerInteraction;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInteraction = InGameManager.Instance.PlayerDataContainer.PlayerInteraction;

            playerInteraction.InteractionObject = this;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInteraction.InteractionObject = null;

            playerInteraction = null;
        }
    }

    public virtual void Interaction() { }
}