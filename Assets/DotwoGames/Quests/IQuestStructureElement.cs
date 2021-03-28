using UnityEngine;

namespace DotwoGames.Quests
{
    public interface IQuestStructureElement
    {
        bool Completed { get; set; }

        void SetState(int[] states);

        void UpdateState();
    }
}
