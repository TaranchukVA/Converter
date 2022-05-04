using System;

namespace Converter.Data.Params
{
    public class CurencyData
    {
        private string _oldCurency;
        private double _oldQuantity;
        private string _newCurency;
        private double _newQuantity;

        public string oldCurency
        {
            get => _oldCurency;
            set => _oldCurency = value.ToUpper();
        }
        public double oldQuantity
        {
            get => _oldQuantity;
            set => _oldQuantity = Math.Round(value, 2);
        }
        public string newCurency
        {
            get => _newCurency;
            set => _newCurency = value.ToUpper();
        }
        public double newQuantity
        {
            get => _newQuantity;
            set => _newQuantity = Math.Round(value, 2);
        }
    }
}
