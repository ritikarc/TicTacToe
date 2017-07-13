namespace TicTacToeMVVM.Resources
{
    internal class Cell : BindingBase
    {
        private CellValue cellvalue;

        public Cell()
        {
            this.Value = CellValue.Empty;
        }

        public CellValue Value
        {
            get
            {
                return this.cellvalue;
            }

            set
            {
                this.SetProperty<CellValue>(ref this.cellvalue, value);
            }
        }
    }
}
