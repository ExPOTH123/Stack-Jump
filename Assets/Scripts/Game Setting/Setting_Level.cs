using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetting", menuName = "GameSetting/Level Setting", order = 1)]
public class Setting_Level : ScriptableObject {
   [Header("Block")]
   [SerializeField]
   [Tooltip("Max speed of the block")]
   public float maxSpeed = 10.0f;
   [Tooltip("Min speed of the block")]
   public float minSpeed = 5.0f;
}
