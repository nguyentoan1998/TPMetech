using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tín_Phát_Metech.EF;
using DevExpress.XtraBars;
using Tín_Phát_Metech.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace Tín_Phát_Metech
{
    public partial class FormShow : DevExpress.XtraEditors.XtraForm
    {
        #region VARIABLE
        private bool _them = false;
        private int rowdelete;
        TinPhatEntities db = new TinPhatEntities();
        tbl_To tbl_To = new tbl_To();
        tbl_NV tbl_Nv = new tbl_NV();
        tbl_Chucvu tbl_Chucvu = new tbl_Chucvu();
        tbl_KH tbl_Kh = new tbl_KH();
        tbl_NCC tbl_Ncc = new tbl_NCC();
        private string _message;
        private bool _edit;
        #endregion
        public FormShow()
        {
            InitializeComponent();
        }
        public FormShow(string Message, bool edit) : this()
        {
            _message = Message;
            _edit = edit;
            this.Text = _message;
        }

        private void FormShow_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }
        #region Function
        void LoadData()
        {
            switch (this.Text)
            {
                case "Cơ cấu Tổ":
                    gridCtrlShow.DataSource = new BindingSource(tbl_To.getList(), null);
                    break;
                case "Chức vụ":
                    gridCtrlShow.DataSource = new BindingSource(tbl_Chucvu.getList(), null);
                    break;
                case "Khách hàng":
                    gridCtrlShow.DataSource = new BindingSource(tbl_Kh.getList(), null);
                    break;
                case "Nhà cung cấp":
                    gridCtrlShow.DataSource = new BindingSource(tbl_Ncc.getList(), null);
                    break;
                case "Nhân viên":
                    gridCtrlShow.DataSource = new BindingSource(tbl_Nv.getList(), null);
                    break;
            }
            if (_edit == false)
            {
                enable();
            }
            else
            {
                disable();

            }
        }
        void enable()
        {
            btnSua.Visibility = BarItemVisibility.Always;
        }
        void disable()
        {
            btnSua.Visibility = BarItemVisibility.Never;
            groupInfo.Visible = false;
        }
        #endregion
        #region Button
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            _them = true;
            gridVShow.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            _them = false;
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridVShow.FocusedRowHandle >= 0)
            {
                if (XtraMessageBox.Show("Bạn thật sự muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    tbl_To.delete(gridVShow.GetRowCellValue(gridVShow.FocusedRowHandle, "Ma_To").ToString());
                gridVShow.DeleteRow(gridVShow.FocusedRowHandle);
            }   
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnGui_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show(gridVShow.GetRowCellValue(gridVShow.RowCount - 1, "Ma_To").ToString());
        }

        private void btnIn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        private void gridVShow_EditFormHidden(object sender, EditFormHiddenEventArgs e)
        {
            gridVShow.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void gridVShow_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int row = gridVShow.RowCount - 1;
            gridVShow.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            if (_them)
            {
                To to = new To();
                try
                {
                    to.Note = gridVShow.GetRowCellValue(row, "Note_To").ToString();
                }
                catch
                {
                    to.Note = "";

                }
                finally
                {
                    to.MaTo = gridVShow.GetRowCellValue(row, "Ma_To").ToString();
                    to.TenTo = gridVShow.GetRowCellValue(row, "Ten_To").ToString();
                    tbl_To.add(to);
                }
            }
            else
            {
                To to = tbl_To.getItem(gridVShow.GetFocusedRowCellValue("Ma_To").ToString());
                to.TenTo = gridVShow.GetRowCellValue(gridVShow.FocusedRowHandle, "Ten_To").ToString();
                to.Note = gridVShow.GetRowCellValue(gridVShow.FocusedRowHandle, "Note_To").ToString();
                tbl_To.update(to);
            }
        }
        private void gridVShow_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            XtraMessageBox.Show("Bạn đã xóa " + gridVShow.GetRowCellValue(e.RowHandle, "Ten_To").ToString() + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void gridVShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W)
            {
                if (XtraMessageBox.Show("Bạn muốn thoát cửa sổ " + this.Text + " khồng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                  DialogResult.Yes)
                    this.Close();
            }
        }
    }
}