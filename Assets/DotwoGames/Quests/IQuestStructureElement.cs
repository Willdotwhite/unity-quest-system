using UnityEngine;

namespace DotwoGames.Quests
{
    public interface IQuestStructureElement
    {
        delegate void OnComplete();

        event OnComplete onComplete;

        bool Completed { get; set; }

        void SetState(int[] states);
    }
}
