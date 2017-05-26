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
        [HttpGet]
        [Route("DemoData")]
        public List<int[]> DemoData()
        {
            //var test = new int[10];            
            var passList = new List<int[]>();
            var unsorted = CreateDemoList();
            var unsortedArray = unsorted.ToArray();
            
            var sorted = false;
            while (!sorted)
            {
                var changes = 0;
                for (int i = 0; i < unsortedArray.Length - 1; i++) //Count -1 so it stops after comparing 9 and 10
                {
                    var tempArray = new int[_demoLength];
                    unsortedArray.CopyTo(tempArray,0);
                    passList.Add(tempArray);
                    if (Compare(unsortedArray[i],unsortedArray[i+1]))
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
    }
}