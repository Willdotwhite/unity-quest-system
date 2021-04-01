namespace DotwoGames.Quests
{
    /// <summary>
    /// Large, cohesive unit of a quest
    /// </summary>
    public class Act : ParentQuestStructureElement<Chapter>
    {
        public Chapter CurrentChapter => CurrentChild;
    }
}
