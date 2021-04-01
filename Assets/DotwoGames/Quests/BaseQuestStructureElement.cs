using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DotwoGames.Quests
{
    public abstract class BaseQuestStructureElement<TChild> : MonoBehaviour, IQuestStructureElement where TChild: Object, IQuestStructureElement
    {
        // DEBUG
        protected virtual void Awake()
        {
            _currentChildId = 1;
            _completed = false;

            // Create in-memory clones of Steps, so they can be completed and updated independently
            Children = Children.Select(child => Instantiate(child, transform)).ToList();

            foreach (TChild child in Children)
            {
                child.onComplete += OnChildComplete;
            }
        }

        public int ID;

        //
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

        #region Children

        /// <summary>
        /// Current active child
        /// </summary>
        protected TChild CurrentChild => Children[_currentChildId - 1];

        /// <summary>
        /// All Children in this element of the quest as structured in the inspector
        /// <para>
        /// These aren't the actual children used, as Tasks need to overwrite them
        /// </para>
        /// </summary>
        [SerializeField] protected List<TChild> Children;

        /// <summary>
        /// ID of current active Child in children
        /// </summary>
        [SerializeField] protected int _currentChildId = 1;

        /// <summary>
        /// Recursively set state for Quest
        /// </summary>
        /// <param name="states"></param>
        public void SetState(int[] states)
        {
            // If we've iterated through states, bounce out here
            // TODO: Customise this logic to Task/Step interaction
            if (states.Length == 0)
            {
                return;
            }

            int currentState = states[0];

            for (int i = 0; i < Children.Count; i++)
            {
                // Mark all previous Acts/Chapters/Tasks completed
                Children[i].Completed = (i < currentState - 1);
            }

            _currentChildId = currentState;

            ArraySegment<int> stateSegment = new ArraySegment<int>(states, 1, states.Length - 1);

            // TODO: This won't reset Task2's child idx if we've just set CurrentChild to Task1
            CurrentChild.SetState(stateSegment.ToArray());
        }

        private void OnChildComplete()
        {
            Debug.Log("Element completed!");

            // TODO: Guard against multiple child triggers?
            if (Completed)
            {
                Debug.Log("Errr, what?");
            }

            if (Children.All(child => child.Completed))
            {
                Completed = true;
            }
            else
            {
                _currentChildId++;
            }
        }

        #endregion
    }
}
