using UnityEngine;
using LitJson;
using System.Collections.Generic;
using TMPro;

public class StoryController : MonoBehaviour
{
    private List<Quest> quests = new List<Quest>();
    private Quest currentQuest = null;

    [Header("Internal References")]
    [SerializeField] private TextMeshProUGUI questGoalText = null;

    private void Awake()
    {
        string polyglotFile = Resources.Load<TextAsset>("Polyglot Story/PolyglotStoryline").text;
        JsonData polyglotTojsonData = JsonMapper.ToObject(polyglotFile);

        for (int i = 0; i < polyglotTojsonData["Story"].Count; i++)
        {
            string stringID = polyglotTojsonData["Story"][i]["STRING ID"].ToString();

            if (stringID == string.Empty)
            {
                continue;
            }

            string englishText = polyglotTojsonData["Story"][i]["ENGLISH"].ToString();

            // Format: QUEST_X_OBJECTIVE_X
            string[] stringIDArray = stringID.Split('_');

            if (stringIDArray[0] == "QUEST")
            {
                if (quests.Count <= 0)
                {
                    Quest newQuest = new Quest(int.Parse(stringIDArray[1]));

                    Objective objective = new Objective(englishText);
                    newQuest.AddObjective(objective);

                    quests.Add(newQuest);

                    currentQuest = newQuest;
                }
                else
                {
                    bool doesQuestIDExist = false;
                    int id = int.Parse(stringIDArray[1]);

                    foreach (Quest quest in quests)
                    {
                        if (quest.GetID() == id)
                        {
                            Objective objective = new Objective(englishText);
                            quest.AddObjective(objective);
                            doesQuestIDExist = true;
                            break;
                        }
                    }

                    if (doesQuestIDExist == false)
                    {
                        Quest newQuest = new Quest(id);

                        Objective objective = new Objective(englishText);
                        newQuest.AddObjective(objective);

                        quests.Add(newQuest);
                    }
                }
            }
        }

        //foreach (Quest quest in quests)
        //{
        //    LogController.LogMessage(string.Format(
        //        "QUEST_{0}",
        //        quest.GetID()
        //        ));

        //    foreach (Objective objective in quest.GetObjectives())
        //    {
        //        LogController.LogMessage("    " + objective.GetGoal());
        //    }
        //}

        RefreshQuestUI();
    }

    public void RefreshQuestUI()
    {
        questGoalText.text = currentQuest.GetObjectives()[0].GetGoal();
    }
}
