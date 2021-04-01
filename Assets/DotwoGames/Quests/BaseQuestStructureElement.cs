using System;
using UnityEngine;

namespace DotwoGames.Quests
{
    public abstract class BaseQuestStructureElement : MonoBehaviour, IQuestStructureElement
    {
        /// <summary>
        /// Unique identifier within sibling scope
        /// <para>
        /// TODO: Should this be set up-front to be unique within Quest scope?
        /// </para>
        /// </summary>
        public int ID;

        public event IQuestStructureElement.OnComplete onComplete;

        private bool _completed;

        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                if (_completed)
                {
                    onComplete?.Invoke();
                }
            }
        }

        protected virtual void Awake()
        {
            _completed = false;
        }

        public virtual void SetState(int[] states)
        {
            throw new NotImplementedException();
        }
    }
}
