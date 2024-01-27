//Link:https://www.codewars.com/kata/reviews/5c3cc5112ce7350001676069/groups/5c8f76680d3b1e0001c3804f#633180ffdefafd96a2ec1a81
using System;

public static class Kata
{
    public static int MaxSequence(int[] arr)
    {
        int sum = 0;
        int max = 0;

        for (int i = arr.Length - 1; i >= 0; i--)
        {

            if (i > 0 && arr[i] + arr[i - 1] >= sum)
            {

                sum = arr[i] + arr[i - 1];
            }
            if (i > 1 && arr[i] + arr[i - 1] + arr[i - 2] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2];
            }
            if (i > 2 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3];
            }
            if (i > 3 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4];
            }
            if (i > 4 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4];
            }
            if (i > 5 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6];
            }
            if (i > 6 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7];

            }
            if (i > 7 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8];

            }
            if (i > 8 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9];

            }
            if (i > 9 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10];

            }
            if (i > 10 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11];

            }
            if (i > 11 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] >= sum)
            {
                
                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12];

            }
            if (i > 12 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13];

            }
            if (i > 13 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i -14] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i -14];

            }
            if (i > 14 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15];

            }
            if (i > 15 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16];

            }
            if (i > 16 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17];

            }
            if (i > 17 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18];

            }
            if (i > 18 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19];

            }
            if (i > 19 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20];

            }
            if (i > 20 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21];

            }
            if (i > 21 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22];

            }
            if (i > 22 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23];

            }
            if (i > 23 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24];

            }
            if (i > 24 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25];

            }
            if (i > 25 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26];

            }
            if (i > 26 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27];

            }
            if (i > 27 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28];

            }
            if (i > 28 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29];

            }
            if (i > 29 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30];

            }
            if (i > 30 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31];

            }
            if (i > 31 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32];

            }
            if (i > 32 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33];

            }
            if (i > 33 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34];

            }
            if (i > 34 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35];

            }
            if (i > 35 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36];

            }
            if (i > 36 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37];

            }
            if (i > 37 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38];

            }
            if (i > 38 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39];

            }
            if (i > 39 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40];

            }
            if (i > 40 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41];

            }
            if (i > 41 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42];

            }
            if (i > 42 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[ i - 43];

            }
            if (i > 43 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44];

            }
            if (i > 44 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45];

            }
            if (i > 45 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46];

            }
            if (i > 46 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47];

            }
            if (i > 47 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48];

            }
            if (i > 48 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] + arr[i - 49] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] + arr[i - 49];

            }
            if (i > 49 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] + arr[i - 49] + arr[i - 50] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] + arr[i - 49] + arr[i - 50];

            }
            if (i > 50 && arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] + arr[i - 49] + arr[i - 50] + arr[i - 51] >= sum)
            {

                sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3] + arr[i - 4] + arr[i - 5] + arr[i - 6] + arr[i - 7] + arr[i - 8] + arr[i - 9] + arr[i - 10] + arr[i - 11] + arr[i - 12] + arr[i - 13] + arr[i - 14] + arr[i - 15] + arr[i - 16] + arr[i - 17] + arr[i - 18] + arr[i - 19] + arr[i - 20] + arr[i - 21] + arr[i - 22] + arr[i - 23] + arr[i - 24] + arr[i - 25] + arr[i - 26] + arr[i - 27] + arr[i - 28] + arr[i - 29] + arr[i - 30] + arr[i - 31] + arr[i - 32] + arr[i - 33] + arr[i - 34] + arr[i - 35] + arr[i - 36] + arr[i - 37] + arr[i - 38] + arr[i - 39] + arr[i - 40] + arr[i - 41] + arr[i - 42] + arr[i - 43] + arr[i - 44] + arr[i - 45] + arr[i - 46] + arr[i - 47] + arr[i - 48] + arr[i - 49] + arr[i - 50] + arr[i - 51];

            }
            if (sum > max)
            {
                max = sum;
            }

        }
        if (max < 0)
        {
            max = 0;
        }

        return max;
    }
}
