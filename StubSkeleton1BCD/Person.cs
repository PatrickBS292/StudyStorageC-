
namespace Stub_skeleton_1.B_C_D {
    internal class Person {
        public string Name { get; set; }
        public int Age { get; set; }

        internal Person() {
            Name = string.Empty;
            Age = 0;
        }

        internal Person(string name, int age) {
            Name = name;
            Age = age;
        }

        public override string ToString() {
            return $"[Person: name={Name}, age={Age}]";
        }
    }
}
