namespace TheGame.Utils
{
    public class Position
    {
        private int debthCoo;
        private int widthCoo;

        /// <summary>
        /// X, Y
        /// </summary>
        /// <param name="widthCoo">X</param>
        /// <param name="debthCoo">Y</param>
        public Position(int widthCoo, int debthCoo)
        {
            this.widthCoo = widthCoo;
            this.debthCoo = debthCoo;
        }

        /// <summary>
        /// Y
        /// </summary>
        /// <returns>Y</returns>
        public int GetDebthCoo()
        {
            return this.debthCoo;
        }

        /// <summary>
        /// Y
        /// </summary>
        /// <returns>Y</returns>
        public void SetDebthCoo(int newDebthCoo)
        {
            this.debthCoo = newDebthCoo;
        }

        /// <summary>
        /// X
        /// </summary>
        /// <returns>X</returns>
        public int GetWidthCoo()
        {
            return this.widthCoo;
        }

        /// <summary>
        /// X
        /// </summary>
        /// <returns>X</returns>
        public void SetWidthCoo(int newWidthCoo)
        {
            this.widthCoo = newWidthCoo;
        }
    }
}