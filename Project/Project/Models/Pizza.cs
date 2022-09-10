using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    class Pizza
    {
        //ctor
        public Pizza()
        {
            _id++;
            Id = _id;
        }


        //fields
        private static int _id;

        //props
        public int Id { get; }

    }
}
