namespace DotwoGames.Quests
{
    public interface IQuestStructureElement
    {
        /// <summary>
        /// Delegate method structure for event when this quest element completes
        /// </summary>
        delegate void OnComplete();

        /// <summary>
        /// Event called when quest completed
        /// </summary>
        event OnComplete onComplete;

        void SetActive(bool active);

        bool Active { get; set; }

        /// <summary>
        /// Has this quest element been completed yet?
        /// </summary>
        bool Completed { get; set; }

        /// <summary>
        /// Set the state of this element and it's children
        /// </summary>
        /// <param name="states"></param>
        void SetState(int[] states);
    }
}
