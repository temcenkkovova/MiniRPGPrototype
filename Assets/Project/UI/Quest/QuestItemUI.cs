using TMPro;
using UnityEngine;

public class QuestItemUI : MonoBehaviour
{

  public TMP_Text title;
  public TMP_Text condition;


  public void Init(QuestConfig data)
  {

    title.text = data.title;
    condition.text = data.EnemyNameToKill + " " + data.RequiredKills;
  }
}