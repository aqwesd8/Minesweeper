namespace Minesweeper;

public readonly struct ScaledMouseState {
    public readonly float X;
    public readonly float Y;
    public readonly float Previous_X;
    public readonly float Previous_Y;

    public ScaledMouseState(float x, float y, float pX, float pY){
        X = x;
        Y = y;
        Previous_X = pX;
        Previous_Y = pY;
    }
}