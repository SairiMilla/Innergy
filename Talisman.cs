using UnityEngine;
using System.Collections;

public abstract class Talisman : MonoBehaviour {

    public int level=1;
    public float energy;
    public float effectDuration;
    public float[] energytresholds=new float[3];
    protected bool active;
    public Sprite simbol;

    public abstract void activate();
    public abstract void levelUp();
    public abstract void levelDown();

    public void getEnergy(float amount) {
        if (energy != energytresholds[2]) {
            energy += amount;
            if (energy > energytresholds[2])
                energy = energytresholds[2];
            if (level != 3 && energy >= energytresholds[level-1]) {
                levelUp();
            }
        }
    }

    public void looseEnergy(float amount) {
        if (energy != 0) {
            energy -= amount;
            if (energy < 0)
                energy = 0;
            if (level != 1 && energy <= energytresholds[level - 2])
                levelDown();
        }
    }

    public bool isActive() {
        return active;
    }

    public void setActive(bool act) {
        active = act;
    }
}
