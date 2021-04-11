using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DotwoGames.Quests
{
    public abstract class ParentQuestStructureElement<TChild> : BaseQuestStructureElement where TChild: Object, IQuestStructureElement
    {
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

        protected override void Awake()
        {
            base.Awake();

            // Create in-memory clones of Steps, so they can be completed and updated independently
            Children = Children.Select(child => Instantiate(child, transform)).ToList();

            foreach (TChild child in Children)
            {
                child.onComplete += OnChildComplete;
            }
        }

        /// <summary>
        /// Recursively set state for Quest
        /// </summary>
        /// <param name="states"></param>
        public override void SetState(int[] states)
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
                Children[i].SetActive(i == currentState - 1);
                Children[i].Completed = (i < currentState - 1);
            }

            _currentChildId = currentState;

            ArraySegment<int> stateSegment = new ArraySegment<int>(states, 1, states.Length - 1);
            CurrentChild.SetState(stateSegment.ToArray());
        }

        public override void SetActive(bool active)
        {
            base.SetActive(active);

            if (active)
            {
                CurrentChild.SetActive(true);
            }
            else
            {
                foreach (TChild child in Children)
                {
                    child.SetActive(false);
                }
            }
        }

        private void OnChildComplete()
        {
            // TODO: Guard against multiple child triggers?
            if (Completed)
            {
                Debug.Log("Errr, what?");
            }

            if (Children.All(child => child.Completed))
            {
                Debug.Log($"All children of {name} complete");
                Completed = true;
            }
            else
            {
                _currentChildId++;
                CurrentChild.SetActive(true);
            }
        }
    }
}
