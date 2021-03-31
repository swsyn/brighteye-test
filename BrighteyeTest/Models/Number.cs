using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighteyeTest.Models
{
    public class Number
    {
        public int Id { get; set; }
        private int value;
        public int Value
        {
            get { return value; }
            set
            {
                if (value < 1)
                {
                    this.value = 1;
                }
                else if (value > 10)
                {
                    this.value = 10;
                }
                else
                {
                    this.value = value;
                }
            }
        }
    }
}
