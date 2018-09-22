using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamepad : MonoBehaviour {
  public enum Button {
    A = 0,
    B,
    Left,
    Right,
    Down,
    Up,
    Start,
    Select,
    Count,
  };

  static int[] prevButtonDownCounts = new int[(int)Button.Count];
  static int[] buttonDownCounts = new int[(int)Button.Count];

  static Dictionary<string,Button> buttonMap = new Dictionary<string,Button> {
    { "a", Button.B },
    { "s", Button.A },
    { "left", Button.Left },
    { "right", Button.Right },
    { "up", Button.Up },
    { "down", Button.Down },
  #if UNITY_STANDALONE_WIN
    { "joystick button 0", Button.B },
    { "joystick button 1", Button.A },
    { "joystick button 2", Button.B },
    { "joystick button 3", Button.A },
    { "joystick button 6", Button.Select },
    { "joystick button 7", Button.Start },
  #elif UNITY_STANDALONE_OSX
    { "joystick button 7", Button.Left },
    { "joystick button 8", Button.Right },
    { "joystick button 6", Button.Down },
    { "joystick button 5", Button.Up },
    { "joystick button 9", Button.Start },
    { "joystick button 10", Button.Select },
    { "joystick button 16", Button.B },
    { "joystick button 17", Button.A },
    { "joystick button 18", Button.B },
    { "joystick button 19", Button.A },
  #endif
  };

  public void Update () {
    var swap = buttonDownCounts;
    buttonDownCounts = prevButtonDownCounts;
    prevButtonDownCounts = swap;

    for(int i = 0; i < (int)Button.Count; i++) {
      buttonDownCounts[i] = 0;
    }

    foreach(var item in buttonMap) {
      if(Input.GetKey(item.Key)) {
        buttonDownCounts[(int)item.Value]++;
      }
    }

    if(Input.GetAxis("LeftX") < -0.5) buttonDownCounts[(int)Button.Left]++;
    if(Input.GetAxis("LeftX") >  0.5) buttonDownCounts[(int)Button.Right]++;
    if(Input.GetAxis("LeftY") < -0.5) buttonDownCounts[(int)Button.Up]++;
    if(Input.GetAxis("LeftY") >  0.5) buttonDownCounts[(int)Button.Down]++;
    if(Input.GetAxis("DPadX") < -0.5) buttonDownCounts[(int)Button.Left]++;
    if(Input.GetAxis("DPadX") >  0.5) buttonDownCounts[(int)Button.Right]++;
    if(Input.GetAxis("DPadY") < -0.5) buttonDownCounts[(int)Button.Up]++;
    if(Input.GetAxis("DPadY") >  0.5) buttonDownCounts[(int)Button.Down]++;
  }

  public static bool JustDown(Button button) {
    return buttonDownCounts[(int)button] > 0 && prevButtonDownCounts[(int)button] == 0;
  }

  public static bool Down(Button button) {
    return buttonDownCounts[(int)button] > 0;
  }

  public static bool JustUp(Button button) {
    return buttonDownCounts[(int)button] == 0 && prevButtonDownCounts[(int)button] > 0;
  }

  public static bool Up(Button button) {
    return buttonDownCounts[(int)button] == 0;
  }
}
