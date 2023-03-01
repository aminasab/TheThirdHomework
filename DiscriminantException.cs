namespace ConsoleApp3
{
    internal class DiscriminantException : Exception
    {
        public DiscriminantException() { }
        public DiscriminantException(string str) : base(str) { }
        public DiscriminantException(string str, Exception inner) : base(str, inner) { }
    }
}
