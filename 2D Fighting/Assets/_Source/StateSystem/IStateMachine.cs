using System;

namespace StateSystem
{
    public interface IStateMachine
    {
        void ChangeState(Type type, float value = 0);
        void Update();
    }
}
