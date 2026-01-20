using UnityEngine;

public abstract class Effect
{
    public EffectsManager toolbox;
    public virtual bool IsValid()
    {
        return true;
    }
    public abstract void Perform();
    public virtual void Init()
    {
        
    }

    public virtual string GetData()
    {
        return "";
    }
}
