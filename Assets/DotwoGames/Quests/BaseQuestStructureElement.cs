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

        private bool _active;

        public bool Active
        {
            get => _active;
            set
            {
                Debug.Log($"Setting {name} active state: {value}");
                _active = value;
            }
        }

        public virtual void SetActive(bool active)
        {
            Active = active;
        }



        private bool _completed;

        public bool Completed
        {
            get => _completed;
            set
            {
                if (!Active)
                {
                    Debug.Log($"Cannot mark {name} completed when it's not active!");
                    return;
                }

                _completed = value;
                if (_completed)
                {
                    SetActive(false);
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
