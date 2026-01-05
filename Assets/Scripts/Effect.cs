using UnityEngine;

public abstract class Effect
{
    public EffectsManager toolbox;
    public bool IsValid()
    {
        return true;
    }
    public abstract void Perform();
    public virtual void Init()
    {
        
    }
}
