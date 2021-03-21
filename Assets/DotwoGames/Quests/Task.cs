using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Singular story element as part of a quest
    /// <para>
    /// Wrapper around Step[] in order to allow a flexible format (e.g. two steps in either order)
    /// </para>
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/4. Task")]
    public class Task : ScriptableObject
    {
        public int ID;

        public Chapter parent;

        // DEBUG
        public List<Step> Steps => steps;
        [SerializeField] private List<Step> steps;

        private void OnEnable()
        {
            foreach (Step step in steps)
            {
                step.parent = this;
            }
        }

        public void NotifyComplete()
        {
            bool areAllStepsComplete = steps.All(step => step.Completed);

            if (areAllStepsComplete)
            {
                // Notify parent
                Debug.Log("I'm complete!");
                parent.NotifyComplete();
            }
        }
    }
}
