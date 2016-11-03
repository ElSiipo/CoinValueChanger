using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinValueChanger
{
    public class ValueChangeHander
    {
        private List<Change> _listOfChange;

        public ValueChangeHander(List<Change> ListOfChange)
        {
            if (ListOfChange == null || ListOfChange.Count == 0)
                throw new ArgumentException("Stupid hobbit! List of change must contain something!");

            _listOfChange = ListOfChange;
            //_listOfChange = ListOfChange.OrderByDescending(x => x.Value).ToList();
        }
        

        public List<Change> GetValueCombinations(int valueToConvert)
        {
            var _changeListToReturn = new List<Change>();

            foreach(var changeValue in _listOfChange)
            {
                while(valueToConvert >= changeValue.Value)
                {
                    changeValue.Amout = valueToConvert / changeValue.Value;
                    _changeListToReturn.Add(changeValue);

                    valueToConvert = valueToConvert - (changeValue.Value * changeValue.Amout);
                }
            }
            
            return _changeListToReturn;
        }
    }
}
