using UnityEngine;

public class QuestDialogUI : MonoBehaviour
{
  public Quest quest;
  public Transform gridParent;
  public QuestUI questUIPrefab;
  public GameObject questPanel;

  void Awake()
  {
    if (quest == null) return;
    quest.IsOpenQuestDialog += ShowQuestDialog;
  }

  public void ShowQuestDialog(bool isOpen)
  {
    questPanel.SetActive(isOpen);
    if (!isOpen) return;
    QuestUI uI = Instantiate(questUIPrefab, gridParent);
    uI.Init(quest.config, quest);
  }
  void OnDisable()
  {
    if (quest == null) return;
    quest.IsOpenQuestDialog -= ShowQuestDialog;
  }

}