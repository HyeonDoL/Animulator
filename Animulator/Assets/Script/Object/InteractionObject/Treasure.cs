
public class Treasure : InteractionObject
{
    public override void Interaction()
    {
        InGameManager.Instance.TreasureFind();

        Destroy(this.gameObject);
    }
}
