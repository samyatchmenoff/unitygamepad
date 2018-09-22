using UnityEngine.EventSystems;

public class GamepadInputModule : BaseInputModule {
  override public bool ShouldActivateModule() {
    return true;
  }

  override public void ActivateModule() {
    if(eventSystem.firstSelectedGameObject) {
      eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject, GetBaseEventData());
    }
  }

  override public void Process() {
    if(Gamepad.JustDown(Gamepad.Button.A)) {
      var data = GetBaseEventData ();
      ExecuteEvents.Execute(eventSystem.currentSelectedGameObject, data, ExecuteEvents.submitHandler);
      return;
    }

    if(Gamepad.JustDown(Gamepad.Button.B)) {
      var data = GetBaseEventData ();
      ExecuteEvents.Execute(eventSystem.currentSelectedGameObject, data, ExecuteEvents.cancelHandler);
      return;
    }

    float x = 0.0f;
    float y = 0.0f;
    if(Gamepad.JustDown(Gamepad.Button.Left)) x -= 1.0f;
    if(Gamepad.JustDown(Gamepad.Button.Right)) x += 1.0f;
    if(Gamepad.JustDown(Gamepad.Button.Down)) y -= 1.0f;
    if(Gamepad.JustDown(Gamepad.Button.Up)) y += 1.0f;
    if(x != 0.0 || y != 0.0) {
      var axisEventData = GetAxisEventData(x, y, 0.5f);
      ExecuteEvents.Execute (eventSystem.currentSelectedGameObject, axisEventData, ExecuteEvents.moveHandler);
    }
  }
}
