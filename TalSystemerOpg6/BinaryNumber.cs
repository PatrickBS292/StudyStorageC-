using System.Text;

namespace Binary {

    public class BinaryNumber {
        private int[] digits;
        private const int MAX_DIGITS = 32;

        public BinaryNumber() {
            digits = new int[MAX_DIGITS];
            Clear();
        }

        public BinaryNumber(string digitStr) : this() {
            FromStr(digitStr);
        }

        public BinaryNumber(int value) : this() {
            FromInt(value);
        }

        public void Clear() {
            for (int i = 0; i < MAX_DIGITS; i++) {
                digits[i] = 0;
            }
        }

        public static BinaryNumber operator +(BinaryNumber a, BinaryNumber b) {
            BinaryNumber result = new BinaryNumber();
            int carry = 0;

            for (int i = 0; i < MAX_DIGITS; i++) {
                int sum = a.digits[i] + b.digits[i] + carry;
                result.digits[i] = sum % 2;
                carry = sum / 2;
            }

            return result;
        }

        public void FromStr(string digitStr) {
            Clear();
            for (int i = 0; i < digitStr.Length && i < MAX_DIGITS; i++) {
                char c = digitStr[digitStr.Length - 1 - i];
                digits[i] = c - '0';
            }
        }

        public void FromInt(int value) {
            Clear();
            int i = 0;
            while (value > 0 && i < MAX_DIGITS) {
                digits[i] = value % 2;
                value = value / 2;
                i++;
            }
        }

        public int ToInt() {
            int result = 0;
            for (int i = MAX_DIGITS - 1; i >= 0; i--) {
                result = (result << 1) | digits[i];
            }
            return result;
        }

        public string ToStr() {
            StringBuilder sb = new StringBuilder();
            int i = MAX_DIGITS - 1;

            while (i > 0 && digits[i] == 0) {
                i--;
            }

            for (; i >= 0; i--) {
                sb.Append(digits[i]);
            }

            return sb.ToString();
        }

        public override string ToString() {
            return ToStr() + " (" + ToInt() + ")";
        }
    }
}
