using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace video_rental
{
    internal class BoxSet
    {
        /* TV Series


     Seasons(string)

     Title(string)

     Season(int)

     Episodes(int)

     Episode Length(double)

     Year(int)

     MPA Rating(Char, E, T, M)

     Format(DVD, Blu-Ray) (String)
     Discs Included(Int)

     Available Copies(Int)

     Total Copies(int)
        */
        public int Season { get; set; }
    }
}
