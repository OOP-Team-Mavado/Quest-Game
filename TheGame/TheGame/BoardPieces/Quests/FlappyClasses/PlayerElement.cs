using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.BoardPieces.Quests.FlappyClasses
{
    class PlayerElement : GameElement
    {
        private bool isJumping = false;
        private int remainingJumpFrames = 0;


        public override ConsoleColor DisplayColor
        {
            get
            {
                return ConsoleColor.Red;
            }
        }

        public override char DisplaySymbol
        {
            get
            {
                return 'w';
            }
        }

        public override void UpdateNextFrame()
        {
            if (isJumping && remainingJumpFrames > 0)
            {
                this.remainingJumpFrames--;
                this.Row--;
            }
            else if (isJumping && remainingJumpFrames == 0)
            {
                this.isJumping = false;
            }
            else
            {
                this.Row++;
            }
        }

        public void Jump()
        {
            this.isJumping = true;
            this.remainingJumpFrames = 3;
        }

        public bool IsColliding(ObstacleElement obstacle)
        {
            if (obstacle.Row == this.Row && obstacle.Column == this.Column)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
