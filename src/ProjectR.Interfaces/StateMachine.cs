using System.Collections.Generic;

namespace ProjectR.Interfaces
{
    public class StateMachine : IStateMachine
    {
        private readonly List<IState> _states;
        private int _currentState;
        private ISynchronizer<int> _synchronizer;

        public StateMachine()
        {
            _states = new List<IState>();
            _currentState = -1;
            _synchronizer = null;
        }

        public virtual void Next()
        {
            Sync(_currentState + 1);
            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
        }

        public virtual void Previous()
        {
            Sync(_currentState - 1);
            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
        }

        public IState CurrentState { get { return _states[_currentState]; } }


        public void AddState(IState state)
        {
            if (state != null)
            {
                state.SetStateMachine(this);
            }

            _states.Add(state);
        }

        public void RunCurrentState()
        {
            var state = CurrentState;

            if (state != null)
            {
                state.Run();
            }

            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
        }

        public IState GetState(int index)
        {
            return _states[index];
        }

        public virtual void SetCurrentState(int index)
        {
            if (_synchronizer != null)
            {
                _synchronizer.Sync(_currentState);
            }
            else
            {
                Sync(index);
            }
        }

        public void ClearStates()
        {
            _states.Clear();
        }

        public int GetStateCount()
        {
            return _states.Count;
        }

        public bool FirstStateActive()
        {
            return _currentState == 0;
        }

        public int GetCurrentStateNumber()
        {
            return _currentState;
        }

        public void Sync(int value)
        {
            if (_currentState == value || _states.Count == 0)
            {
                return;
            }

            if (_currentState != -1 && CurrentState != null)
            {
                CurrentState.Deactivate();
            }

            _currentState = value;

            if (CurrentState != null)
            {
                CurrentState.Activate();
            }
        }

        public void SetSynchronizer(ISynchronizer<int> syncer)
        {
            _synchronizer = syncer;
        }
    }
}