using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PicklistBOM
{
    public class CGlobal
    {
        private static String _FrmcountLine;
        public static String FrmcountLine
        {
            // get { return "U1"; }
            get { return _FrmcountLine; }
            set { _FrmcountLine = value; }
        }
        private static String _Frmcount;
        public static String Frmcount
        {
            // get { return "U1"; }
            get { return _Frmcount; }
            set { _Frmcount = value; }
        }

        private static String _Man_NT_OT;
        public static String Man_NT_OT
        {
            // get { return "U1"; }
            get { return _Man_NT_OT; }
            set { _Man_NT_OT = value; }
        }

        private static String _DocID;
        public static String DocID
        {
            // get { return "U1"; }
            get { return _DocID; }
            set { _DocID = value; }
        }
        private static String _Sew_CellckName;
        public static String Sew_CellckName
        {
            // get { return "U1"; }
            get { return _Sew_CellckName; }
            set { _Sew_CellckName = value; }
        }

        private static String _Sdate_Schedule;
        public static String Sdate_Schedule
        {
            // get { return "U1"; }
            get { return _Sdate_Schedule; }
            set { _Sdate_Schedule = value; }
        }
        private static String _Man_Night_OT;
        public static String Man_Night_OT
        {
            // get { return "U1"; }
            get { return _Man_Night_OT; }
            set { _Man_Night_OT = value; }
        }


        private static String _CELL_NAME;
        public static String CELL_NAME
        {
            // get { return "U1"; }
            get { return _CELL_NAME; }
            set { _CELL_NAME = value; }
        }

        private static String _Date_Sdate;
        public static String Date_Sdate
        {
            // get { return "U1"; }
            get { return _Date_Sdate; }
            set { _Date_Sdate = value; }
        }


        private static String _Sew_deletecell;
        public static String Sew_deletecell
        {
            // get { return "U1"; }
            get { return _Sew_deletecell; }
            set { _Sew_deletecell = value; }
        }
        private static String _Sew_DocNo2;
        public static String Sew_DocNo2
        {
            // get { return "U1"; }
            get { return _Sew_DocNo2; }
            set { _Sew_DocNo2 = value; }
        }
        private static String _CkCutShow;
        public static String CkCutShow
        {
            // get { return "U1"; }
            get { return _CkCutShow; }
            set { _CkCutShow = value; }
        }
        private static String _CkBarcodeStatus;
        public static String CkBarcodeStatus
        {
            // get { return "U1"; }
            get { return _CkBarcodeStatus; }
            set { _CkBarcodeStatus = value; }
        }
        private static String _CkSDatetime;
        public static String CkSDatetime
        {
            // get { return "U1"; }
            get { return _CkSDatetime; }
            set { _CkSDatetime = value; }
        }
        private static String _CkSQtyseat;
        public static String CkSQtyseat
        {
            // get { return "U1"; }
            get { return _CkSQtyseat; }
            set { _CkSQtyseat = value; }
        }
        private static String _Sew_itemModelNewSofa1;
        public static String Sew_itemModelNewSofa1
        {
            // get { return "U1"; }
            get { return _Sew_itemModelNewSofa1; }
            set { _Sew_itemModelNewSofa1 = value; }
        }
        private static String _Sew_itemModelNew1;
        public static String Sew_itemModelNew1
        {
            // get { return "U1"; }
            get { return _Sew_itemModelNew1; }
            set { _Sew_itemModelNew1 = value; }
        }
        private static String _CkSBarcode;
        public static String CkSBarcode
        {
            // get { return "U1"; }
            get { return _CkSBarcode; }
            set { _CkSBarcode = value; }
        }
        private static String _CkSItemmodel;
        public static String CkSItemmodel
        {
            // get { return "U1"; }
            get { return _CkSItemmodel; }
            set { _CkSItemmodel = value; }
        }
        private static String _CkSPOCell;
        public static String CkSPOCell
        {
            // get { return "U1"; }
            get { return _CkSPOCell; }
            set { _CkSPOCell = value; }
        }
        private static String _Sew_itemModelNewSofa;
        public static String Sew_itemModelNewSofa
        {
            // get { return "U1"; }
            get { return _Sew_itemModelNewSofa; }
            set { _Sew_itemModelNewSofa = value; }
        }
        private static String _CheckOn;
        public static String CheckOn
        {
            // get { return "U1"; }
            get { return _CheckOn; }
            set { _CheckOn = value; }
        }
        private static String _qtytotalEOut;
        public static String qtytotalEOut
        {
            // get { return "U1"; }
            get { return _qtytotalEOut; }
            set { _qtytotalEOut = value; }
        }
        private static String _qtytotalEBom;
        public static String qtytotalEBom
        {
            // get { return "U1"; }
            get { return _qtytotalEBom; }
            set { _qtytotalEBom = value; }
        }
        private static String _DayDocPoNo;
        public static String DayDocPoNo
        {
            // get { return "U1"; }
            get { return _DayDocPoNo; }
            set { _DayDocPoNo = value; }
        }
        private static String _DayweekPO;
        public static String DayweekPO
        {
            // get { return "U1"; }
            get { return _DayweekPO; }
            set { _DayweekPO = value; }
        }
        private static String _DayweekOutputD;
        public static String DayweekOutputD
        {
            // get { return "U1"; }
            get { return _DayweekOutputD; }
            set { _DayweekOutputD = value; }
        }
        private static String _DayweekTotalSew;
        public static String DayweekTotalSew
        {
            // get { return "U1"; }
            get { return _DayweekTotalSew; }
            set { _DayweekTotalSew = value; }
        }
        private static String _Sew_Qtymodelout;
        public static String Sew_Qtymodelout
        {
            // get { return "U1"; }
            get { return _Sew_Qtymodelout; }
            set { _Sew_Qtymodelout = value; }
        }
        private static String _Sew_Qtymodel;
        public static String Sew_Qtymodel
        {
            // get { return "U1"; }
            get { return _Sew_Qtymodel; }
            set { _Sew_Qtymodel = value; }
        }
        private static String _Sew_QtyBalbom;
        public static String Sew_QtyBalbom
        {
            // get { return "U1"; }
            get { return _Sew_QtyBalbom; }
            set { _Sew_QtyBalbom = value; }
        }
        private static String _Sew_QtyBal;
        public static String Sew_QtyBal
        {
            // get { return "U1"; }
            get { return _Sew_QtyBal; }
            set { _Sew_QtyBal = value; }
        }
        private static String _Sew_QtyOut;
        public static String Sew_QtyOut
        {
            // get { return "U1"; }
            get { return _Sew_QtyOut; }
            set { _Sew_QtyOut  = value; }
        }
        private static String _Sew_Barcode;
        public static String Sew_Barcode
        {
            // get { return "U1"; }
            get { return _Sew_Barcode; }
            set { _Sew_Barcode = value; }
        }
        private static String _Sew_remark;
        public static String Sew_remark
        {
            // get { return "U1"; }
            get { return _Sew_remark; }
            set { _Sew_remark = value; }
        }
        private static String _Sew_itemModelNew;
        public static String Sew_itemModelNew
        {
            // get { return "U1"; }
            get { return _Sew_itemModelNew; }
            set { _Sew_itemModelNew = value; }
        }
        private static String _Sew_itemModel;
        public static String Sew_itemModel
        {
            // get { return "U1"; }
            get { return _Sew_itemModel; }
            set { _Sew_itemModel = value; }
        }
        private static String _Sew_Qtywip;
        public static String Sew_Qtywip
        {
            // get { return "U1"; }
            get { return _Sew_Qtywip; }
            set { _Sew_Qtywip = value; }
        }
        private static String _Sew_QtyBom;
        public static String Sew_QtyBom
        {
            // get { return "U1"; }
            get { return _Sew_QtyBom; }
            set { _Sew_QtyBom = value; }
        }
        private static String _Sew_DeptCode;
        public static String Sew_DeptCode
        {
            // get { return "U1"; }
            get { return _Sew_DeptCode; }
            set { _Sew_DeptCode = value; }
        }
        private static String _Sew_DocNoRef;
        public static String Sew_DocNoRef
        {
            // get { return "U1"; }
            get { return _Sew_DocNoRef; }
            set { _Sew_DocNoRef = value; }
        }
        private static String _Sew_DocNo;
        public static String Sew_DocNo
        {
            // get { return "U1"; }
            get { return _Sew_DocNo; }
            set { _Sew_DocNo = value; }
        }
        private static String _IssueNumber2;
        public static String IssueNumber2
        {
            // get { return "U1"; }
            get { return _IssueNumber2; }
            set { _IssueNumber2 = value; }
        }
        private static String _Issuemodel;
        public static String Issuemodel
        {
            // get { return "U1"; }
            get { return _Issuemodel; }
            set { _Issuemodel = value; }
        }
        private static String _IssueType;
        public static String IssueType
        {
            // get { return "U1"; }
            get { return _IssueType; }
            set { _IssueType = value; }
        }
        private static String _IssueEdate;
        public static String IssueEdate
        {
            // get { return "U1"; }
            get { return _IssueEdate; }
            set { _IssueEdate = value; }
        }
        private static String _IssueSdate;
        public static String IssueSdate
        {
            // get { return "U1"; }
            get { return _IssueSdate; }
            set { _IssueSdate = value; }
        }
        private static String _IssueNo2;
        public static String IssueNo2
        {
            // get { return "U1"; }
            get { return _IssueNo2; }
            set { _IssueNo2 = value; }
        }
        private static String _Issuecelldate;
        public static String Issuecelldate
        {
            // get { return "U1"; }
            get { return _Issuecelldate; }
            set { _Issuecelldate = value; }
        }
        private static String _Issuecell;
        public static String Issuecell
        {
            // get { return "U1"; }
            get { return _Issuecell; }
            set { _Issuecell = value; }
        }
        private static String _IssueLotnumber2Bin;
        public static String IssueLotnumber2Bin
        {
            // get { return "U1"; }
            get { return _IssueLotnumber2Bin; }
            set { _IssueLotnumber2Bin = value; }
        }
        private static String _EmpPost;
        public static String EmpPost
        {
            // get { return "U1"; }
            get { return _EmpPost; }
            set { _EmpPost = value; }
        }
        private static String _Tmptpe;
        public static String Tmptpe
        {
            // get { return "U1"; }
            get { return _Tmptpe; }
            set { _Tmptpe = value; }
        }
        private static String _TmpDouble;
        public static String TmpDouble
        {
            // get { return "U1"; }
            get { return _TmpDouble; }
            set { _TmpDouble = value; }
        }
        private static String _TmpAutoLine2;
        public static String TmpAutoLine2
        {
            // get { return "U1"; }
            get { return _TmpAutoLine2; }
            set { _TmpAutoLine2 = value; }
        }
        private static String _TmpAutoLine1;
        public static String TmpAutoLine1
        {
            // get { return "U1"; }
            get { return _TmpAutoLine1; }
            set { _TmpAutoLine1 = value; }
        }
        private static String _TmpAutoCell9;
        public static String TmpAutoCell9
        {
            // get { return "U1"; }
            get { return _TmpAutoCell9; }
            set { _TmpAutoCell9 = value; }
        }
        private static String _TmpAutoCell8;
        public static String TmpAutoCell8
        {
            // get { return "U1"; }
            get { return _TmpAutoCell8; }
            set { _TmpAutoCell8 = value; }
        }
        private static String _TmpAutoCell5;
        public static String TmpAutoCell5
        {
            // get { return "U1"; }
            get { return _TmpAutoCell5; }
            set { _TmpAutoCell5 = value; }
        }
        private static String _TmpAutoCell4;
        public static String TmpAutoCell4
        {
            // get { return "U1"; }
            get { return _TmpAutoCell4; }
            set { _TmpAutoCell4 = value; }
        }
        private static String _TmpAutoCell3;
        public static String TmpAutoCell3
        {
            // get { return "U1"; }
            get { return _TmpAutoCell3; }
            set { _TmpAutoCell3 = value; }
        }
        private static String _TmpAutoCell2;
        public static String TmpAutoCell2
        {
            // get { return "U1"; }
            get { return _TmpAutoCell2; }
            set { _TmpAutoCell2 = value; }
        }
        private static String _TmpAutoCell1;
        public static String TmpAutoCell1
        {
            // get { return "U1"; }
            get { return _TmpAutoCell1; }
            set { _TmpAutoCell1 = value; }
        }
        private static String _TmpAutoCell;
        public static String TmpAutoCell
        {
            // get { return "U1"; }
            get { return _TmpAutoCell; }
            set { _TmpAutoCell = value; }
        }
        private static String _QtyBalT1;
        public static String QtyBalT1
        {
            // get { return "U1"; }
            get { return _QtyBalT1; }
            set { _QtyBalT1 = value; }
        }

        private static String _QtyBal1;
        public static String QtyBal1
        {
            // get { return "U1"; }
            get { return _QtyBal1; }
            set { _QtyBal1 = value; }
        }

        private static String _QtyOut1;
        public static String QtyOut1
        {
            // get { return "U1"; }
            get { return _QtyOut1; }
            set { _QtyOut1 = value; }
        }

        private static String _QtyBom1;
        public static String QtyBom1
        {
            // get { return "U1"; }
            get { return _QtyBom1; }
            set { _QtyBom1 = value; }
        }

        private static String _WeekActual;
        public static String WeekActual
        {
            // get { return "U1"; }
            get { return _WeekActual; }
            set { _WeekActual = value; }
        }
        private static String _WeekTarget;
        public static String WeekTarget
        {
            // get { return "U1"; }
            get { return _WeekTarget; }
            set { _WeekTarget = value; }
        }
        private static String _Barcode1;
        public static String Barcode1
        {
            // get { return "U1"; }
            get { return _Barcode1; }
            set { _Barcode1 = value; }
        }
        private static String _BarcodePicItem;
        public static String BarcodePicItem
        {
            // get { return "U1"; }
            get { return _BarcodePicItem; }
            set { _BarcodePicItem = value; }
        }
        private static String _BarcodePic;
        public static String BarcodePic
        {
            // get { return "U1"; }
            get { return _BarcodePic; }
            set { _BarcodePic = value; }
        }
        private static String _DocNoPic;
        public static String DocNoPic
        {
            // get { return "U1"; }
            get { return _DocNoPic; }
            set { _DocNoPic = value; }
        }
        private static String _TotalOutput30;
        public static String TotalOutput30
        {
            // get { return "U1"; }
            get { return _TotalOutput30; }
            set { _TotalOutput30 = value; }
        }
        private static String _TotalOutput29;
        public static String TotalOutput29
        {
            // get { return "U1"; }
            get { return _TotalOutput29; }
            set { _TotalOutput29 = value; }
        }
        private static String _TotalOutput27;
        public static String TotalOutput27
        {
            // get { return "U1"; }
            get { return _TotalOutput27; }
            set { _TotalOutput27 = value; }
        }
        private static String _Sumtotal27;
        public static String Sumtotal27
        {
            // get { return "U1"; }
            get { return _Sumtotal27; }
            set { _Sumtotal27 = value; }
        }
        private static String _SumQty27;
        public static String SumQty27
        {
            // get { return "U1"; }
            get { return _SumQty27; }
            set { _SumQty27 = value; }
        }
        private static String _strG;
        public static String strG
        {
            // get { return "U1"; }
            get { return _strG; }
            set { _strG = value; }
        }
        private static String _TempDeletePO;
        public static String TempDeletePO
        {
            // get { return "U1"; }
            get { return _TempDeletePO; }
            set { _TempDeletePO = value; }
        }
        private static String _qtytotalE;
        public static String qtytotalE
        {
            // get { return "U1"; }
            get { return _qtytotalE; }
            set { _qtytotalE = value; }
        }
        private static String _PODAY;
        public static String PODAY
        {
            // get { return "U1"; }
            get { return _PODAY; }
            set { _PODAY = value; }
        }
        private static String _cellpo3;
        public static String cellpo3
        {
            // get { return "U1"; }
            get { return _cellpo3; }
            set { _cellpo3 = value; }
        }
        private static String _cellStatus;
        public static String cellStatus
        {
            // get { return "U1"; }
            get { return _cellStatus; }
            set { _cellStatus = value; }
        }
        private static String _cellpo00;
        public static String cellpo00
        {
            // get { return "U1"; }
            get { return _cellpo00; }
            set { _cellpo00 = value; }
        }
        private static String _cellpo2;
        public static String cellpo2
        {
            // get { return "U1"; }
            get { return _cellpo2; }
            set { _cellpo2 = value; }
        }
        private static String _cellpo0;
        public static String cellpo0
        {
            // get { return "U1"; }
            get { return _cellpo0; }
            set { _cellpo0 = value; }
        }

        private static String _tmpployCheck;
        public static String tmpployCheck
        {
            // get { return "U1"; }
            get { return _tmpployCheck; }
            set { _tmpployCheck = value; }
        }
        private static String _tmpploy;
        public static String tmpploy
        {
            // get { return "U1"; }
            get { return _tmpploy; }
            set { _tmpploy = value; }
        }
        private static String _tmpcheck10;
        public static String tmpcheck10
        {
            // get { return "U1"; }
            get { return _tmpcheck10; }
            set { _tmpcheck10 = value; }
        }
        private static String _Bintype;
        public static String Bintype
        {
            // get { return "U1"; }
            get { return _Bintype; }
            set { _Bintype = value; }
        }
        private static String _CkBk2One;
        public static String CkBk2One
        {
            // get { return "U1"; }
            get { return _CkBk2One; }
            set { _CkBk2One = value; }
        }

        private static String _BinNo;
        public static String BinNo
        {
            // get { return "U1"; }
            get { return _BinNo; }
            set { _BinNo = value; }
        }
        private static String _BinDate;
        public static String BinDate
        {
            // get { return "U1"; }
            get { return _BinDate; }
            set { _BinDate = value; }
        }
        private static String _BinBOI;
        public static String BinBOI
        {
            // get { return "U1"; }
            get { return _BinBOI; }
            set { _BinBOI = value; }
        }

        private static String _BinPO;
        public static String BinPO
        {
            // get { return "U1"; }
            get { return _BinPO; }
            set { _BinPO  = value; }
        }


        private static string _PO2BIN;
        public static string PO2BIN
        {
            // get { return "U1"; }
            get { return _PO2BIN; }
            set { _PO2BIN = value; }
        }
        private static int _HHb;
        public static int HHb
        {
            // get { return "U1"; }
            get { return _HHb; }
            set { _HHb = value; }
        }

        private static int _MMb;
        public static int MMb
        {
            // get { return "U1"; }
            get { return _MMb; }
            set { _MMb = value; }
        }

        private static int _SSb;
        public static int SSb
        {
            // get { return "U1"; }
            get { return _SSb; }
            set { _SSb = value; }
        }

        private static int _HH;
        public static int HH
        {
            // get { return "U1"; }
            get { return _HH; }
            set { _HH = value; }
        }
        private static int _MM;
        public static int MM
        {
            // get { return "U1"; }
            get { return _MM; }
            set { _MM = value; }
        }

        private static int _SS;
        public static int SS
        {
            // get { return "U1"; }
            get { return _SS; }
            set { _SS = value; }
        }

        private static String _TotalHHb;
        public static String TotalHHb
        {
            // get { return "U1"; }
            get { return _TotalHHb; }
            set { _TotalHHb = value; }
        }

        private static String _Totalb;
        public static String Totalb
        {
            // get { return "U1"; }
            get { return _Totalb; }
            set { _Totalb = value; }
        }
        private static String  _TotalHH;
        public static String  TotalHH
        {
            // get { return "U1"; }
            get { return _TotalHH; }
            set { _TotalHH = value; }
        }
        private static String _SDaytime0;
        public static String SDaytime0
        {
            // get { return "U1"; }
            get { return _SDaytime0; }
            set { _SDaytime0 = value; }
        }
        private static String _SDaytime;
        public static String SDaytime
        {
            // get { return "U1"; }
            get { return _SDaytime; }
            set { _SDaytime = value; }
        }
        private static String _SBarck;
        public static String SBarck
        {
            // get { return "U1"; }
            get { return _SBarck; }
            set { _SBarck = value; }
        }
        private static String _Stime;
        public static String Stime
        {
            // get { return "U1"; }
            get { return _Stime; }
            set { _Stime = value; }
        }
        private static String _LotQtyNet;
        public static String LotQtyNet
        {
            // get { return "U1"; }
            get { return _LotQtyNet; }
            set { _LotQtyNet = value; }
        }
        private static String _LotQtyOut;
        public static String LotQtyOut
        {
            // get { return "U1"; }
            get { return _LotQtyOut; }
            set { _LotQtyOut = value; }
        }
        private static String _LotQtyIn;
        public static String LotQtyIn
        {
            // get { return "U1"; }
            get { return _LotQtyIn; }
            set { _LotQtyIn = value; }
        }
        private static String _Lotno;
        public static String Lotno
        {
            // get { return "U1"; }
            get { return _Lotno; }
            set { _Lotno = value; }
        }
        private static String _BalQtyNet;
        public static String BalQtyNet
        {
            // get { return "U1"; }
            get { return _BalQtyNet; }
            set { _BalQtyNet = value; }
        }
        private static String _BalQtyOut;
        public static String BalQtyOut
        {
            // get { return "U1"; }
            get { return _BalQtyOut; }
            set { _BalQtyOut = value; }
        }
        private static String _BalQtyIn;
        public static String BalQtyIn
        {
            // get { return "U1"; }
            get { return _BalQtyIn; }
            set { _BalQtyIn = value; }
        }
        private static String _DayweekTotaldate;
        public static String DayweekTotaldate
        {
            // get { return "U1"; }
            get { return _DayweekTotaldate; }
            set { _DayweekTotaldate = value; }
        }
        private static String _DayweekTotal;
        public static String DayweekTotal
        {
            // get { return "U1"; }
            get { return _DayweekTotal; }
            set { _DayweekTotal = value; }
        }
        private static String _Dayweek;
        public static String Dayweek
        {
            // get { return "U1"; }
            get { return _Dayweek; }
            set { _Dayweek = value; }
        }
        private static String _Daycode;
        public static String Daycode
        {
            // get { return "U1"; }
            get { return _Daycode; }
            set { _Daycode = value; }
        }
        private static String _IDMonitor;
        public static String IDMonitor
        {
            // get { return "U1"; }
            get { return _IDMonitor; }
            set { _IDMonitor = value; }
        }
        private static String _DocProj;
        public static String DocProj
        {
            // get { return "U1"; }
            get { return _DocProj; }
            set { _DocProj = value; }
        }
        private static String _DocNo;
        public static String DocNo
        {
            // get { return "U1"; }
            get { return _DocNo; }
            set { _DocNo = value; }
        }
        private static String _TempWipR;
        public static String TempWipR
        {
            // get { return "U1"; }
            get { return _TempWipR; }
            set { _TempWipR = value; }
        }
        private static String _DocDept;
        public static String DocDept
        {
            // get { return "U1"; }
            get { return _DocDept; }
            set { _DocDept = value; }
        }
        private static String _targetsumtotay;
        public static String targetsumtotay
        {
            // get { return "U1"; }
            get { return _targetsumtotay; }
            set { _targetsumtotay = value; }
        }
        private static String _targetdate;
        public static String targetdate
        {
            // get { return "U1"; }
            get { return _targetdate; }
            set { _targetdate = value; }
        }
        private static String _TotalOut;
        public static String TotalOut
        {
            // get { return "U1"; }
            get { return _TotalOut; }
            set { _TotalOut = value; }
        }
        private static String _ToalNum;
        public static String ToalNum
        {
            // get { return "U1"; }
            get { return _ToalNum; }
            set { _ToalNum = value; }
        }
        private static String _sumtarget;
        public static String sumtarget
        {
            // get { return "U1"; }
            get { return _sumtarget; }
            set { _sumtarget = value; }
        }
        private static String _CheckTargetBarcode;
        public static String CheckTargetBarcode
        {
            // get { return "U1"; }
            get { return _CheckTargetBarcode; }
            set { _CheckTargetBarcode = value; }
        }
        private static String _CheckTargetDoc;
        public static String CheckTargetDoc
        {
            // get { return "U1"; }
            get { return _CheckTargetDoc; }
            set { _CheckTargetDoc = value; }
        }
        private static String _DocPoNo;
        public static String DocPoNo
        {
            // get { return "U1"; }
            get { return _DocPoNo; }
            set { _DocPoNo = value; }
        }
        private static String _DeptCode;
        public static String DeptCode
        {
            // get { return "U1"; }
            get { return _DeptCode; }
            set { _DeptCode = value; }
        }
        private static String _QtyUse;
        public static String QtyUse
        {
            // get { return "U1"; }
            get { return _QtyUse; }
            set { _QtyUse = value; }
        }
        private static String _QtyBal;
        public static String QtyBal
        {
            // get { return "U1"; }
            get { return _QtyBal; }
            set { _QtyBal = value; }
        }
        private static String _QtyOut;
        public static String QtyOut
        {
            // get { return "U1"; }
            get { return _QtyOut; }
            set { _QtyOut = value; }
        }
        private static String _QtyBom;
        public static String QtyBom
        {
            // get { return "U1"; }
            get { return _QtyBom; }
            set { _QtyBom = value; }
        }
        private static String _CheckBarcode2Bin;
        public static String CheckBarcode2Bin
        {
            // get { return "U1"; }
            get { return _CheckBarcode2Bin; }
            set { _CheckBarcode2Bin = value; }
        }
        private static String _CheckBarcode;
        public static String CheckBarcode
        {
            // get { return "U1"; }
            get { return _CheckBarcode; }
            set { _CheckBarcode = value; }
        }
        private static String _CheckBDoc;
        public static String CheckBDoc
        {
            // get { return "U1"; }
            get { return _CheckBDoc; }
            set { _CheckBDoc = value; }
        }
        private static String _CheckPORef;
        public static String CheckPORef
        {
            // get { return "U1"; }
            get { return _CheckPORef; }
            set { _CheckPORef = value; }
        }
        private static String _Version;
        public static String Version
        {
            // get { return "U1"; }
            get { return _Version; }
            set { _Version = value; }
        }
        private static String _Username;
        public static String Username
        {
            // get { return "U1"; }
            get { return _Username; }
            set { _Username = value; }
        }
        private static String _UserID;
        public static String UserID
        {
            // get { return "U1"; }
            get { return _UserID; }
            set { _UserID = value; }
        }
        private static String _VersionName;
        public static String VersionName
        {
            // get { return "U1"; }
            get { return _VersionName; }
            set { _VersionName = value; }
        }

        private static String _Company;
        public static String Company
        {
            // get { return "U1"; }
            get { return _Company; }
            set { _Company = value; }
        }

        private static String _tempID;
        public static String tempID
        {
            // get { return "U1"; }
            get { return _tempID; }
            set { _tempID = value; }
        }
        private static String _PO;
        public static String PO
        {
            // get { return "U1"; }
            get { return _PO; }
            set { _PO = value; }
        }
        private static String _OrderPoint;
        public static String OrderPoint
        {
            // get { return "U1"; }
            get { return _OrderPoint; }
            set { _OrderPoint = value; }
        }
        private static String _ins_QTYNet;
        public static String ins_QTYNet
        {
            // get { return "U1"; }
            get { return _ins_QTYNet; }
            set { _ins_QTYNet = value; }
        }
        private static String _POnumber;
        public static String POnumber
        {
            // get { return "U1"; }
            get { return _POnumber; }
            set { _POnumber = value; }
        }

        private static String _model;
        public static String model
        {
            // get { return "U1"; }
            get { return _model; }
            set { _model = value; }
        }

        private static String _style;
        public static String style
        {
            // get { return "U1"; }
            get { return _style; }
            set { _style = value; }
        }

        private static String _wip;
        public static String wip
        {
            // get { return "U1"; }
            get { return _wip; }
            set { _wip = value; }
        }

        private static String _HeadDetail;
        public static String HeadDetail
        {
            // get { return "U1"; }
            get { return _HeadDetail; }
            set { _HeadDetail = value; }
        }

        private static String _Commnet;
        public static String Commnet
        {
            // get { return "U1"; }
            get { return _Commnet; }
            set { _Commnet = value; }
        }
        private static String _Status;
        public static String Status
        {
            // get { return "U1"; }
            get { return _Status; }
            set { _Status = value; }
        }
        private static String _OrderType;
        public static String OrderType
        {
            // get { return "U1"; }
            get { return _OrderType; }
            set { _OrderType = value; }
        }


        private static String _DocBrn;
        public static String DocBrn
        {
            // get { return "U1"; }
            get { return _DocBrn; }
            set { _DocBrn = value; }
        }

        private static String _DocUser;
        public static String DocUser
        {
            // get { return "U1"; }
            get { return _DocUser; }
            set { _DocUser = value; }
        }

        private static String _CloseBy;
        public static String CloseBy
        {
            // get { return "U1"; }
            get { return _CloseBy; }
            set { _CloseBy = value; }
        }
        private static String _CloseDate;
        public static String CloseDate
        {
            // get { return "U1"; }
            get { return _CloseDate; }
            set { _CloseDate = value; }
        }
        private static String _CheckPO;
        public static String CheckPO
        {
            // get { return "U1"; }
            get { return _CheckPO; }
            set { _CheckPO = value; }
        }
    }
}
