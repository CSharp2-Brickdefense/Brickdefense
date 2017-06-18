using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickdefense
{
    interface Object 
    {
        int width { get; set; }
        int height { get; set; }
        int xpos { get; set; }

        void collision();


    }
}
