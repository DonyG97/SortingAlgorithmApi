using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
namespace SortingAlgorithmApi.Controllers
{
    [RoutePrefix("api/BubbleSortController")]
    public class BubbleSortController : ApiController
    {
        Random _rand = new Random();
        int _demoLength = 100;
        //TODO Setup HTTP Response messages that get returned with data
        [HttpGet]
        [Route("DemoData")]
        public List<int[]> DemoData()
        {        
            
            var unsorted = CreateDemoList(); //See what Harris thinks, dont think there is any point in creating this list. Just easier to pop than an array
            var unsortedArray = unsorted.ToArray();           
           
            return Sort(unsortedArray);
        }

        [HttpGet]
        [Route("DemoDataStrings")]
        public List<string> DemoDataStrings()
        {
            //var test = new int[10];            
            var passList = new List<String>();
            var unsorted = CreateDemoList();
            var unsortedArray = unsorted.ToArray();

            var sorted = false;
            while (!sorted)
            {
                var changes = 0;
                for (int i = 0; i < unsortedArray.Length - 1; i++) //Count -1 so it stops after comparing 9 and 10
                {
                    var passString = String.Join(",", unsortedArray);
                    passList.Add(passString);
                    //var tempArray = new int[_demoLength];
                    //unsortedArray.CopyTo(tempArray,0);
                    //passList.Add(tempArray);
                    if (Compare(unsortedArray[i], unsortedArray[i + 1]))
                    {
                        var temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = temp;
                        changes++;
                    }
                }
                if (changes == 0)
                {
                    sorted = true;
                }
            }
            return passList;
        }

        [HttpPost]
        [ActionName("Complex")]
        [Route("SortData")]
        public List<int[]> SortData([FromBody] string values)
        {
            
            //return Sort(values);
            return new List<int[]>();
        }
        #region private methods
        private bool Compare(int firstVal, int secondVal)
        {
            if (firstVal > secondVal)
            {
                return true;
            }
            else return false;
        }
        private List<int> CreateDemoList()
        {
            var unsorted = new List<int>();
            for (int i = 0; i < _demoLength; i++)
            {
                unsorted.Add(_rand.Next(20));
            }
            return unsorted;
        }

        private List<int[]> Sort(int[] unsortedArray)
        {
            var passList = new List<int[]>();
            var sorted = false;
            while (!sorted)
            {
                var changes = 0;
                for (int i = 0; i < unsortedArray.Length - 1; i++) //Count -1 so it stops after comparing 9 and 10
                {
                    var tempArray = new int[_demoLength];
                    unsortedArray.CopyTo(tempArray, 0);
                    passList.Add(tempArray);
                    if (Compare(unsortedArray[i], unsortedArray[i + 1]))
                    {
                        var temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = temp;
                        changes++;
                    }
                }
                if (changes == 0)
                {
                    sorted = true;
                }
            }
            return passList;
        }
        #endregion
    }
}