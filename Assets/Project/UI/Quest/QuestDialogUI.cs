using UnityEngine;
using UnityEngine.UI;

public class QuestDialogUI : MonoBehaviour
{
  public QuestManager quest;
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

    foreach (Transform child in gridParent)
      Destroy(child.gameObject);
    QuestUI uI = Instantiate(questUIPrefab, gridParent);
    uI.Init(quest.config, quest);

  }
  void OnDisable()
  {
    if (quest == null) return;
    quest.IsOpenQuestDialog -= ShowQuestDialog;
  }

}