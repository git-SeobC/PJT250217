using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJT250217
{
    public class Character
    {
        public int x;
        public int y;
        public void Move() { }
        public void Collider() { }
    }

    // Player is a Character
    // Monster is a Character == 상속관계 성립
}
