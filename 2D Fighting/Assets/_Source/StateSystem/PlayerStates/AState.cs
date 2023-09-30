namespace StateSystem
{
    public abstract class AState
    {
        protected IStateMachine Owner;

        public void SetOwner(IStateMachine owner)
        {
            Owner = owner;
        }

        public virtual void Enter(float value = 0) { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}
