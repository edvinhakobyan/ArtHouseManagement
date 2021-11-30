using Core.Interfaces.IBLL;
using GenericRepository.Abstarction;
using System;
using System.Windows.Forms;

namespace NASTRAN.Pad
{
    public partial class MainForm : Form
    {
        private readonly IGridBL _gridBL;
        private readonly IElementBL _elementBL;
        private readonly IUnitOfWork _unitOfWork;

        public MainForm(IUnitOfWork unitOfWork,
                        IGridBL gridBL,
                        IElementBL elementBL)
        {
            _gridBL = gridBL;
            _elementBL = elementBL;
            _unitOfWork = unitOfWork;

            InitializeComponent();
        }


        private void button_SaveAs_Click(object sender, EventArgs e)
        {
           // _services.AddDb(@"C:\Users\Edvin\source\repos\LocalDBTesting\DB\Database\NastranDb5.mdf");
        }

        private void button_OpenBdf_Click(object sender, EventArgs e)
        {

        }
    }
}
