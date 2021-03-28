using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Individual element to complete a quest
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/5. Step")]
    public /*abstract*/ class Step : ScriptableObject, IQuestStructureElement
    {
        public bool Completed { get => isCompleted; set => isCompleted = value; }

        [SerializeField]
        private bool isCompleted;

        public void Debug_Complete()
        {
            Completed = true;
        }

        public void SetState(int[] state)
        {
            Debug.Log($"Not sure what this'll be: {state}, {state.Length}");
        }

        public void UpdateState()
        {

        }
    }
}
