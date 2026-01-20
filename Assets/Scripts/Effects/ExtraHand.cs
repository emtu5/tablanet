using UnityEngine;

public class ExtraHand : Effect
{
    public override void Perform()
    {
        toolbox.Play(true);
    }

    public override bool IsValid() {
        return toolbox.IsHandValid();
    }
}
