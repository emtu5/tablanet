using UnityEngine;

public class ExtraHand : Effect
{
    public override void Perform(string param)
    {
        toolbox.Play(true);
    }

    public override bool IsValid() {
        return toolbox.IsHandValid();
    }
}
