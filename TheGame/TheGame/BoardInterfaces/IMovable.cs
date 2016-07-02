namespace TheGame.BoardInterfaces
{
    using System.Collections.Generic;
    using TheGame.Utils;

    public interface IMovable
    {
        void SetPosition(List<Position> newPosition);
    }
}