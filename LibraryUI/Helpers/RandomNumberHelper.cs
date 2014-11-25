using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI
{
    public static class RandomNumberHelper
    {
        public static int RandomNumber(int Maximum)
        {
            Random RND = new Random();
            return RND.Next(Maximum + 1);
        }

        public static int RandomNumber(int Minimum, int Maximum)
        {
            Random RND = new Random();
            return RND.Next(Minimum, Maximum + 1);
        }

        public static int[] RandomNumberArray(int Minimum, int Maximum, int ArrayLength)
        {
            int[] _RandomNumberArray = new int[ArrayLength];

            for (int i = 0; i < ArrayLength - 1; i++)
            {
                _RandomNumberArray[i] = RandomNumber(Minimum, Maximum);
            }

            return _RandomNumberArray;
        }
    }
}