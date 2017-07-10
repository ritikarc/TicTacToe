using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMVVM.Resources
{
    class Cell : BindingBase
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
                SetProperty<CellValue>(ref cellvalue, value);
            }
        }
    }
}
