using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DTO;
using Hospital.Model;

namespace Hospital.View.Pacijent.Strategy
{
    class ContextClass
    {
        private IStrategy _strategy;
        public ContextClass() { }
        public ContextClass(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public List<CheckupDTO> availableTimes(object firstObject, object secondObjct)
        {
          return  this._strategy.availableTimes(firstObject, secondObjct);
        }
    }
}
