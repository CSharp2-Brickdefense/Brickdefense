﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickdefense
{
    class Block
    {
        private int width;
        private int height;
        private int xpos;
        private int ypos;
        private int value;

        public void collision()
        {

        }

        public void setWidht(int value)
        {
            this.width = value;
        }

        public int getWidth()
        {
            return this.width;
        }

        public void setHeight(int value)
        {
            this.height = value;
        }

        public int getHeight()
        {
            return this.height;
        }

        public void setXpos(int value)
        {
            this.xpos = value;
        }

        public int getXpos()
        {
            return this.xpos;
        }

        public void setYpos(int value)
        {
            this.ypos = value;
        }

        public int getYpos()
        {
            return this.ypos;
        }

        public void setValue(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return this.value;
        }
    }
}
