using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour {

    public List<string> tasks = new List<string>();
    public Text taskPlace;
    public TextIntro taskAdder;

    public int currentTask;
    public bool advance;

    [Header("KeyUpdate")]
    public Keys keys;

    [Header("DoorUpdate")]
    public DoorOpen door;

    public float level;

    private void Update()
    {
        if (advance)
        {
            advance = false;
            currentTask += 1;
            if(currentTask < tasks.Capacity)
            {
                taskPlace.text = "";
                taskAdder.text = tasks[currentTask];
                taskAdder.charC = 0;
                taskAdder.finished = false;
                taskAdder.started = false;
                taskAdder.startNow = true;
            } else
            {
                currentTask -= 1;
            }
        }
        if (keys.hasCellKey)
        {
            if(currentTask == 0)
            {
                if(level == 0)
                {
                    advance = true;
                }
            }
        }
        if (door.hasOpened)
        {
            if(currentTask == 1)
            {
                if(level == 0)
                {
                    advance = true;
                }
            }
        }
    }

}
