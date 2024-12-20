namespace Demo.Predicate.Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Predicate<string> isUpperCase = A.IsUpperCase;
           Console.WriteLine(isUpperCase("hello")); // false

           Predicate<string> auth = A.IsUserAuthenticated;
           Console.WriteLine(auth("aijaz")); // false


            // using lambda expression
            Predicate<string> isUpperCaseLambda = (str) => str.Equals(str.ToUpper());
            Console.WriteLine(isUpperCaseLambda("HELLO")); // true

            // using anonymous method
            Predicate<string> isUpperCaseAnonymous = delegate (string str) { return str.Equals(str.ToUpper()); };
            Console.WriteLine(isUpperCaseAnonymous("hello")); // false


            Func<string, string, bool> login = A.Login;

            if (login("admin", "admin123"))
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }
    }

    // create static class with name A
    public static class A
    {
        public static bool IsUpperCase(string str) => str.Equals(str.ToUpper());

        public static bool IsUserAuthenticated(string username)
        {
            return username.Equals("admin");
        }

        public static bool Login(string username, string password)
        {
            return username.Equals("admin") && password.Equals("admin");
        }
    }
}
