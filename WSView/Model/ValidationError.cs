namespace WSView.Model
{
    public class ValidationError
    {

        public string ValidationMessage { get; set; }

        public Replacement[] Replacements { get; set; }

    }

    public class Replacement
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
