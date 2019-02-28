using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psych1 {
    class RandomValues {
        public static char RandomAlphanumeric() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var nums = "0123456789";
            // TODO pForNumeral should weight nums or chars
            var random = new Random();
            int numOrChar = random.Next(0, 99);
            if (numOrChar < 50) {
                return chars[numOrChar % chars.Length];
            } else {
                return nums[numOrChar % nums.Length];
            }

        }

        public static char RandomOQ() {
            var chars = "OQ";
            var random = new Random();
            int numOrChar = random.Next(0, 99);
            return chars[numOrChar % chars.Length];
           

        }

        public static char RandomPR() {
            var chars = "PR";
            var random = new Random();
            int numOrChar = random.Next(0, 99);
            return chars[numOrChar % chars.Length];


        }

    }
}