using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isLanded = false;
    bool isDead = false;

    public int streak = 0;

    public void setLanded(bool isLanded_In) {
        isLanded = isLanded_In;
    }

    public void setDead(bool isDead_In) {
        isDead = isDead_In;
    }

    public bool isPlayerLanded() {
        return isLanded;
    }

    public bool isPlayerDead() {
        return isDead;
    }
}
