using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DotwoGames.Quests
{
    /// <summary>
    /// DEBUG!
    /// </summary>
    public class QuestInteractionButton : MonoBehaviour
    {
        [SerializeField] private string _progress;

        private Quest currentQuest;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            // TODO: This probably won't cause problems?
            currentQuest = FindObjectOfType<QuestManager>().Quest;

            if (_progress != "0")
            {
                _button.GetComponentInChildren<Text>().text = _progress;
            }
        }

        private void Update()
        {
            _button.interactable =
                _progress == "0" || // Inline override for non-version buttons
                _progress == currentQuest.GetProgress();
        }

        public void OnQuestProgress()
        {
            Debug.Log($"Completing a step in {_progress}");

            List<Step> stepsToComplete = currentQuest.CurrentAct.CurrentChapter.CurrentTask.RemainingSteps;

            if (stepsToComplete.Count == 0)
            {
                Debug.Log($"No steps in the task! We should have moved on!");
                return;
            }

            stepsToComplete[0].Completed = true;
        }

        public void CheckQuestProgress(string predicate)
        {
            Debug.Log($"{predicate}, {currentQuest.GetProgress()}, :{currentQuest.CheckProgress(predicate)}");
        }
    }
}
