using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Tín_Phát_Metech
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainView()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }
        #region Theme

        private void btnBasic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Basic";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Basic);
        }

        private void btnDen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "DevExpress Dark Style";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.DevExpressDark);
        }

        private void btnNau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "DevExpress Style";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.DevExpress);
        }

        private void btnTrang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Office 2013";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Office2013);
        }

        private void btnPumpkin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Pumpkin";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Pumpkin);
        }

        private void btnSpringtime_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Springtime";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Springtime);
        }

        private void btnSummer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Summer 2008";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Summer2008);
        }

        private void btnValentine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Valentine";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Valentine);
        }

        private void btnXmas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Theme.LookAndFeel.SkinName = "Xmas 2008 Blue";
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Xmas2008Blue);
        }
        private void btnWinter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Reflection.Assembly asm = typeof(DevExpress.UserSkins.WinterJoy).Assembly;
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
            // Apply the skin.
            UserLookAndFeel.Default.SetSkinStyle("Winter Joy");
        }
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            settings.Save();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var settings = Properties.Settings.Default;
            if (settings.SkinName == "Winter Joy")
            {
                System.Reflection.Assembly asm = typeof(DevExpress.UserSkins.WinterJoy).Assembly;
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
                UserLookAndFeel.Default.SetSkinStyle("Winter Joy");
            }
            else if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette))
                    UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName);
            }
        }
        #endregion
        void KiemtraForm(Form form, string Frmtext)
        {
            bool Tontai = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == Frmtext)
                {
                    frm.Activate();
                    Tontai = true;
                }
            }
            if (Tontai == false)
            {
                form.MdiParent = this;
                form.Show();
            }
        }
        private void MainView_Load(object sender, EventArgs e)
        {

        }
        #region Button click
        private void btnChamcong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnChamcong.Caption, true);
            KiemtraForm(show, btnChamcong.Caption);
        }

        private void btnTinhluong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnTinhluong.Caption, true);
            KiemtraForm(show, btnTinhluong.Caption);
        }
        private void btnTo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnTo.Caption, true);
            KiemtraForm(show, btnTo.Caption);
        }

        private void btnNhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnNhanvien.Caption, true);
            KiemtraForm(show, btnNhanvien.Caption);
        }

        private void btnChucvu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnChucvu.Caption, true);
            KiemtraForm(show, btnChucvu.Caption);
        }

        private void btnKhachhang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnKhachhang.Caption, true);
            KiemtraForm(show, btnKhachhang.Caption);
        }

        private void btnNhaCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnNhaCC.Caption, true);
            KiemtraForm(show, btnNhaCC.Caption);
        }
        private void btnDongia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnDongia.Caption, true);
            KiemtraForm(show, btnDongia.Caption);
        }

        private void btnKyhieuCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnKyhieuCC.Caption, true);
            KiemtraForm(show, btnKyhieuCC.Caption);
        }

        private void btnNguyenVL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnNguyenVL.Caption, true);
            KiemtraForm(show, btnNguyenVL.Caption);
        }

        private void btnBanTP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnBanTP.Caption, true);
            KiemtraForm(show, btnBanTP.Caption);
        }

        private void btnThanhpham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnThanhpham.Caption, true);
            KiemtraForm(show, btnThanhpham.Caption);
        }

        private void btnDongiaTP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnDongiaTP.Caption, true);
            KiemtraForm(show, btnDongiaTP.Caption);
        }

        private void btnDonvitinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnDonvitinh.Caption, true);
            KiemtraForm(show, btnDonvitinh.Caption);
        }
        private void btnTongquan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDoanhthu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormShow show = new FormShow(btnTK.Caption, true);
            KiemtraForm(show, btnTK.Caption);
        }
        #endregion
    }
}
