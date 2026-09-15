using System.Text;

namespace TalSystemerOpg6 {

    public class BinaryNumber {
        // indeholder de enkelte binære cifre
        // index = positionen
        // (e.g. digits[0] er længst til højre, 1'ere,
        //       digits[1] er 2'ere
        //    og digits[2] er 4'ere)
        private int[] digits;

        // vi lægger os af implementationsgrunde
        // fast på et bestemt antal bits
        private const int MAX_DIGITS = 32;

        public BinaryNumber() {
            digits = new int[MAX_DIGITS];
            Clear(); // redundant, men konsistent
        }

        public BinaryNumber(string digitStr) : this() {
            FromStr(digitStr);
        }

        public BinaryNumber(int value) : this() {
            FromInt(value);
        }

        // sætter tallet til 0
        public void Clear() {
            // gennemløb array og sæt alle indgange til 0
        }

        public static BinaryNumber operator +(BinaryNumber a, BinaryNumber b) {
            // returnerer en ny instans, der repræsenterer summen af de to parametre.
            // den kan laves nemmest ved at kalde ToInt() på de to parametre, men
            // prøv at lave den ved at gennemløbe de to arrays i 'a' og 'b', og
            // opbyg resultatet med købmandsregning (svært).
        }

        public void FromStr(string digitStr) {
            Clear();
            // gennemløb tegnene i 'digitStr', og indsæt bits i 'digits' array.
        }

        public void FromInt(int value) {
            Clear();
            // brug 'skubber ind i andet talsystem'-metoden, der er beskrevet
            // sidst i afsnit 1, i: DocJava > Forskelligt > Talsystemer.
        }

        public int ToInt() {
            // returnerer som en integer.
            // brug forskydningsmetoden.
        }

        public string ToStr() {
            // returnerer en tekststreng, med '1'er og '0'er
            // (se testanvendelsen)
        }

        public override string ToString() {
            // returner en tekststreng med både værdien som binær, og som decimal
            // (e.g. 13 returneres som: "1101 (13)")
        }
    }
}