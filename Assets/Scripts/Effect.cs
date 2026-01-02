using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public EffectsManager toolbox;
    public bool IsValid()
    {
        return true;
    }
    public abstract void Perform();
}
