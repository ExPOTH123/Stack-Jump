using UnityEngine;

[CreateAssetMenu(fileName = "ParametersSetting", menuName = "GameSetting/Parameters Setting", order = 1)]
public class Setting_Game : ScriptableObject {
   [Header("Scenes")]
   [SerializeField]
   [Tooltip("How long to wait to change to GameOver Scene when player lose")]
   public float waitGameOver = 2.0f;
}
