namespace BL.Models
{
    /// <summary>
    /// Модель HSL.
    /// </summary>
    public struct HSLModel
    {
        private double _h;
        private double _s;
        private double _l;

        /// <summary>
        /// Модель HSL.
        /// </summary>
        public HSLModel(double h, double s, double l)
        {
            this._h = h;
            this._s = s;
            this._l = l;
        }

        public double H
        {
            get { return this._h; }
            set { this._h = value; }
        }

        public double S
        {
            get { return this._s; }
            set { this._s = value; }
        }

        public double L
        {
            get { return this._l; }
            set { this._l = value; }
        }

        public bool Equals(HSLModel hsl)
        {
            return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
        }
    }
}
