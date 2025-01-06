using Microsoft.Xna.Framework;
using MonoGame.Extended.Input;

namespace Minesweeper;

public static class ScaledMouse {
    private static Matrix _scale;

    public static ScaledMouseState GetState(){
        MouseStateExtended ms = MouseExtended.GetState();
        float mouseX= ms.X;
        float mouseY = ms.Y;
        float prevX = mouseX + ms.DeltaX;
        float prevY = mouseY + ms.DeltaY;
        Vector2 changed = Vector2.Transform(new Vector2(mouseX,mouseY), Matrix.Invert(_scale));
        Vector2 changedPrevious = Vector2.Transform(new Vector2(prevX,prevY), Matrix.Invert(_scale));
        mouseX = changed.X;
        mouseY = changed.Y;
        prevX = changedPrevious.X;
        prevY = changedPrevious.Y;
        ScaledMouseState mSk = new ScaledMouseState(mouseX,mouseY,prevX,prevY);

        return mSk;
    }

    public static void Update(Matrix scale){
        _scale = scale;
    }

}