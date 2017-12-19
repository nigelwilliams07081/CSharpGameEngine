using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop
{
    class StateSystem
    {
        Dictionary<string, IGameObject> m_StateStore = new Dictionary<string, IGameObject>();
        IGameObject m_CurrentState = null;

        public void Update(float deltaTime)
        {
            if (m_CurrentState == null) return;

            m_CurrentState.Update(deltaTime);
        }

        public void Draw()
        {
            if (m_CurrentState == null) return;

            m_CurrentState.Draw();
        }

        public void AddState(string stateID, IGameObject state)
        {
            System.Diagnostics.Debug.Assert(Exists(stateID) == false);
            m_StateStore.Add(stateID, state);
        }

        public void ChangeState(string stateID)
        {
            System.Diagnostics.Debug.Assert(Exists(stateID));
            m_CurrentState = m_StateStore[stateID];
        }

        public bool Exists(string stateID)
        {
            return m_StateStore.ContainsKey(stateID);
        }
    }
}
