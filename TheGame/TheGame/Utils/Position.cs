namespace TheGame.Utils
{
    public class Position
    {
        private int debthCoo;
        private int widthCoo;

        public Position(int widthCoo, int debthCoo)
        {
            this.widthCoo = widthCoo;
            this.debthCoo = debthCoo;
        }

        public int GetDebthCoo()
        {
            return this.debthCoo;
        }

        public void SetDebthCoo(int newDebthCoo)
        {
            this.debthCoo = newDebthCoo;
        }

        public int GetWidthCoo()
        {
            return this.widthCoo;
        }

        public void SetWidthCoo(int newWidthCoo)
        {
            this.widthCoo = newWidthCoo;
        }
    }
}