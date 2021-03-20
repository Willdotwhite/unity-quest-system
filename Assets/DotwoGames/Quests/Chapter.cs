using System.Collections.Generic;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Small component of a quest, with several steps
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/3. Chapter")]
    public class Chapter : ScriptableObject
    {
        [SerializeField] private List<Task> tasks;

    }
}
