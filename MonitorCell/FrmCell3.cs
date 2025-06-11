using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatabaseHelper;
using DatabaseHelper1;
using System.Timers;
using System.Configuration;


namespace PicklistBOM.MonitorCell
{
    public partial class FrmCell3 : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmCell3()
        {
            InitializeComponent();
        }

        private void FrmCell3_Load(object sender, EventArgs e)
        {
            CGlobal.cellpo3 = "";
            CallPO();
            CallLoad();
            CallTargettotal();
            CallLoadToday();
        }

        #region "CallPO"
        private void CallPO()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 3' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.cellpo3 = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

        #region "CallLoad()"
        private void CallLoad()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                // String strbarcod = Mid(txtbarcode.Text.Trim(), 0, 14);
                //Cmd = new System.Data.SqlClient.SqlCommand(" Select DocNo,DeptCode,QtyBom,QtyOut,QtyBal,QtyUse,Barcode,DocPoNo  from dbo.DocMODtl  where  Barcode ='" + CGlobal.CheckTargetBarcode  + "' and DocNo ='" + CGlobal.CheckTargetDoc + "'", conn);
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + CGlobal.cellpo3 + "' and DeptCode='W8' and Barcode <> '' and  BomNo In ('CELL','STD')", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO.Text = CGlobal.cellpo3;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        #region "CallTargettotal();"
        private void CallTargettotal()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 3'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget.Text = rs["TargetOutput"].ToString();


                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

        #region "CallLoadToday();"
        private void CallLoadToday()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 3' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotal.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CGlobal.cellStatus = "4";
            FrmMeessage page = new FrmMeessage();
            page.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CGlobal.cellStatus = "CELL 3";
            FrmTodayTarget page1 = new FrmTodayTarget();
            page1.ShowDialog();
        }


    }
}
