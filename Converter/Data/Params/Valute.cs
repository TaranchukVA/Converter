namespace Converter.Data.Params
{
    public class Valute
    {
        public string ID { get; set; }
        public string CharCode { get; set; }
        public uint Nominal { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public double Previous { get; set; }
    }
}