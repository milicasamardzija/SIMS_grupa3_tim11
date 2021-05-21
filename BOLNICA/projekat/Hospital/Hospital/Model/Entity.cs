using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Entity
    {
        private int id;
        public Entity() { }
        public Entity(int id) { this.id = id; }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    } 
}
