using UnityEngine;

public class QuestManagerUI : MonoBehaviour
{
  public GameObject missQuestPanel;
  public GameObject questPanel;
  public Transform gridParent;
  public QuestItemUI questItemPrefab;
  public QuestSystem questSystem;

  void Awake()
  {
    if (!questSystem) return;

    questSystem.OnQuestsChanged += RefreshQuestList;
  }

  public void RefreshQuestList()
  {

    foreach (Transform child in gridParent)
      Destroy(child.gameObject);
    foreach (var item in questSystem.acceptedQuests)
    {
      QuestItemUI questItem = Instantiate(questItemPrefab, gridParent);
      questItem.Init(item.Config);
    }
  }

  void Update()
  {
    bool active = questSystem.acceptedQuests.Count > 0;
    Debug.Log(active);
    missQuestPanel.SetActive(!active);
    questPanel.SetActive(active);
  }
}