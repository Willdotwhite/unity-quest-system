namespace DotwoGames.Quests
{
    /// <summary>
    /// Small component of a quest, with several steps
    /// </summary>
    public class Chapter : ParentQuestStructureElement<Task>
    {
        public Task CurrentTask => CurrentChild;
    }
}
