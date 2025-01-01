using MonoGameGum.Forms.Controls;

namespace Minesweeper;

public class Tile : Button {
    public bool ValueVisible {get; private set;}
    public bool HasMine {get; private set;}
    public bool MinesInProximity {get; private set;}
    public bool IsFlagged {get; private set;}

}