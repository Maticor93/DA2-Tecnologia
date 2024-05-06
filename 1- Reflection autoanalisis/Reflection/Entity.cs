namespace Reflection
{
    public class Entity
    {
        public string PublicStringProperty { get; set; }

        private string _privateStringProperty { get; set; }

        internal string InternalStringProperty { get; set; }

        protected string ProtectedStringProperty { get; set; }

        public Entity() { }

        private Entity(string prop) { }

        public void PublicFunction() { }

        private void PrivateFunction() { }  

        public bool IsValid()
        {
            return true;
        }
    }
}
