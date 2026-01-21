using UnityEngine;

public class TempDiscard : Effect
{
    public override void Perform(string param)
    {
        toolbox.Discard();
    }
}
