using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinValueChanger
{
    public class ValueChangeHander
    {
        private List<Change> _listOfValidChange;

        public ValueChangeHander(List<Change> ListOfValidChange)
        {
            if (ListOfValidChange == null || ListOfValidChange.Count == 0)
                throw new ArgumentException("Stupid hobbit! List of change must contain something!");

            _listOfValidChange = ListOfValidChange;
        }
        

        public List<Change> GetValueCombinations(int valueToConvert)
        {
            var _changeListToReturn = new List<Change>();

            foreach(var changeValue in _listOfValidChange)
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


        public List<Change> GetValuesWithAnyCombinations(int valueToConvert)
        {
            throw new NotImplementedException();

            var _changeListToReturn = new List<Change>();

            foreach(var changeValue in _listOfValidChange)
            {
                //Implement functionality to check combinations...
            }

        }
    }
}
