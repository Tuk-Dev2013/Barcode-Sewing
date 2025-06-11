using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PicklistBOM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    // Application.Run(new txtPOSearch1());   // lot number,Picklist,2bin
          
   //2bin
//  Application.Run(new FrmLogin());  // Login  2bin

  Application.Run(new Sewing.FrmSewingBarcode());  // Login 27/08/2018
    //Application.Run(new Sewing.FrmBarcodeLFS());  //Login 29/08/2018
//Application.Run(new Sewing.FrmShowCutSewing());  

   //Application.Run(new PicklistBOM._2Bin.FrmReport2BinRec());  // Report 2Bin

//Application.Run(new PicklistBOM._2Bin.Frm2BinToAccpac());  // account พี่ดา
   //Application.Run(new PicklistBOM.FG.FG());
   //Application.Run(new PicklistBOM.Main());


  //program sewing barcode 15-03-2016
 // Application.Run(new FrmLogin());  // Login  2bin

  // Application.Run(new PicklistBOM.ScheduleCell.FrmScheduleCell());   // show packing production


// Application.Run(new PicklistBOM.Sewing.FrmSewnAdmin()); 


 //Application.Run(new Barcode());  // ยิง Barcode
   // Application.Run(new PicklistBOM.Stdtime.FrmStdtime());  // std Time 02/07/2015

   // Application.Run(new PicklistBOM.JinnyBOM.FrmJinnyCode());  // Jinny check bom

    //Application.Run(new FrmShowTarget());  // Target
    //Application.Run(new MainReport());  //report                                                                                                            n n                                                                                                                               
   //Application.Run(new Receipt2Bin.FrmRecipt2Bin()); //FrmRecipt2Bin.cs
   //Application.Run(new PicklistBOM._2Bin.Frm2BinDefault());  // defalut 2bin

  //Application.Run(new PicklistBOM.MonitorLine.AdminAllCell()); 
  //Application.Run(new PicklistBOM.MonitorLine.FrmSeting());  // defalut Monitor Line เก่า
//Application.Run(new PicklistBOM.MonitorLine.FrmShowMonitor());  // Show Monitor 
  //Application.Run(new PicklistBOM.MonitorLine.FrmCellMonitor());//show month week day


            //Leather-Moniter
//Application.Run(new PicklistBOM.MonitorLine.FrmLeatherSeting());  // Show Monitor  admin
//Application.Run(new PicklistBOM.MonitorLine.FrmLeatherMoniter()); //Show Monitor

            //sawing Week

 //Application.Run(new PicklistBOM.MonitorLine.FrmSawingWeek());  // Show Monitor  admin
  //Application.Run(new PicklistBOM.MonitorLine.FrmSawingMonitor()); 

            //ยิง barcode FG
           // Application.Run(new PicklistBOM.BarcodeWip.BarcodeW3()); 

            //sentwork
          //  Application.Run(new PicklistBOM.Sentwork.SentWork()); 

            //FG  account
          //  Application.Run(new PicklistBOM.FG//.FG()); 

            //Standard Time 
       // Application.Run(new PicklistBOM.StandardTime.Standardtime());

            //Account Rate
  //Application.Run(new PicklistBOM.RateAccount.FrmRate());

            //report ป้ามนตรี
//Application.Run(new PicklistBOM.ReportModel.FrmModel());

            //show monitor 2Bin
// Application.Run(new PicklistBOM.ShowM2Bin.FrmShow2Bin());


  //show Schedule Cell
 //Application.Run(new PicklistBOM.ScheduleCell.FrmSchedule()); //ป้อนตารางการจอง cell all
  //Application.Run(new PicklistBOM.ScheduleCell.FrmShowSchedule());
  //Application.Run(new PicklistBOM.ScheduleCell.FrmScheduleCell());   // show packing production
  // Application.Run(new PicklistBOM.ScheduleCell.FrmScheduleCellD());  //show poly thin
  // Application.Run(new PicklistBOM.ScheduleCell.FrmShowSchedule());
  //Application.Run(new PicklistBOM.ScheduleCell.FrmShow2Bin());  // show 2 bin
  //Application.Run(new PicklistBOM.ScheduleCell.FrmShowSchedulePoly());//Poly

            //show Schedule Sum  Cell
 //Application.Run(new PicklistBOM.SumCell.frmSum());
//Application.Run(new PicklistBOM.MonitorLine.FrmCellMonitor());//show month week day
// Application.Run(new PicklistBOM.MonitorLine.FrmCellMonitor1024());  //show month week day

            //show Monitor Cell
    //Application.Run(new PicklistBOM.MonitorCell.FrmMain1());
 //Application.Run(new PicklistBOM.MonitorCell.FullCell());
 // Application.Run(new PicklistBOM.MonitorCell.Form1());  // show Monitor Full
//Application.Run(new PicklistBOM.MonitorCell.FrmCellShowMonitor());
             
       //Bom Cost Account
   //Application.Run(new PicklistBOM.BomCostAccount.FrmBom());

       // Line Production
   //Application.Run(new PicklistBOM.Production.LineProduct());

       // Add Picture Model
   //Application.Run(new PicklistBOM.PictureModel.bntpic1());

            // Add edit delete cell เล็ก From 
    //Application.Run(new PicklistBOM.DeletePOCell.FrmMainDelete());

            // Edit BarcodeSysV1_2 
    //Application.Run(new PicklistBOM.BomCostAccount.FrmLoadProduction());

    //Application.Run(new PicklistBOM.AddCellDate.Addcelldate());  // Add celldate


           // Application.Run(new PicklistBOM.JinnyBOM.FrmJinnyCode());

          //  Application.Run(new PicklistBOM.FG.FrmInterfaceFG());  // P'amrin
        }
   
    }
}
