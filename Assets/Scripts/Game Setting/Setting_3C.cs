using UnityEngine;

[CreateAssetMenu(fileName = "3CSetting", menuName = "GameSetting/3CSetting", order = 1)]
public class Setting_3C : ScriptableObject {
   [Header("Camera")]
   [SerializeField]
   [Tooltip("Reflect how fast camera move up with character")]
   public float moveUpSpeed = 5.0f;
   [Tooltip("Reflect how fast camera zoom out when player lose")]
   public float zoomOutSpeed = 10.0f;
   [Tooltip("Distance to zoom out")]
   public float zoomOutDistance = 10.0f;

   [Header("Character")]
   [SerializeField]
   [Tooltip("Force to jump (not jump height)")]
   public float jumpForce = 700.0f;
   [Tooltip("Force that push character out when user die (not distance)")]
   public float deadForce = 700.0f;
}
