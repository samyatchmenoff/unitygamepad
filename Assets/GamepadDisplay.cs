using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamepadDisplay : MonoBehaviour {
  public Text A;
  public Text B;
  public Text Left;
  public Text Right;
  public Text Down;
  public Text Up;
  public Text Start;
  public Text Select;

  void Check(Gamepad.Button button, Text text) {
    if(text == null) return;
    if(Gamepad.JustDown(button)) {
      text.color = Color.yellow;
    } else if(Gamepad.Down(button)) {
      text.color = Color.white;
    } else {
      text.color = Color.grey;
    }
  }

  void Update() {
    Check(Gamepad.Button.A, A);
    Check(Gamepad.Button.B, B);
    Check(Gamepad.Button.Left, Left);
    Check(Gamepad.Button.Right, Right);
    Check(Gamepad.Button.Down, Down);
    Check(Gamepad.Button.Up, Up);
    Check(Gamepad.Button.Start, Start);
    Check(Gamepad.Button.Select, Select);
  }
}
