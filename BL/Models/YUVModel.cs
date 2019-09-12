namespace BL.Models
{
    /// <summary>
    /// Модель YUV.
    /// </summary>
    public struct YUVModel
    {
        private double _y;
        private double _u;
        private double _v;

        /// <summary>
        /// Модель YUV.
        /// </summary>
        public YUVModel(double y, double u, double v)
        {
            this._y = y;
            this._u = u;
            this._v = v;
        }

        public double Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public double U
        {
            get { return this._u; }
            set { this._u = value; }
        }

        public double V
        {
            get { return this._v; }
            set { this._v = value; }
        }

        public bool Equals(YUVModel yuv)
        {
            return (this.Y == yuv.Y) && (this.U == yuv.U) && (this.V == yuv.V);
        }
    }
}
