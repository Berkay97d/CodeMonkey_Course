using System;

public interface IHasProgress
{
    public class OnProgressChangedArguments : EventArgs
    {
        public float progressNormalized;
    }
    public event EventHandler<OnProgressChangedArguments> OnProgressChance;
    
}
