using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;

namespace DataLayer.DataHelper
{
    public class DailySalesHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddSales(DailySalesData dailySales)
        {
            bool isSalesAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    DailySalesRecord dailySalesdb = new DailySalesRecord();
                    dailySalesdb.DateTime = DateTime.Now.ToString();
                    dailySalesdb.DaySales = dailySales.DaySales;
                    dailySalesdb.MonthlySales = dailySales.MonthlySales;
                    dailySalesdb.NetSales = dailySales.NetSales;
                    dailySalesdb.Refunds = dailySales.Refunds;
                    dailySalesdb.Tier1 = dailySales.Tier1;
                    dailySalesdb.Tier2 = dailySales.Tier2;
                    dailySalesdb.Tier3 = dailySales.Tier3;
                    dailySalesdb.Tier4 = dailySales.Tier4;
                    dailySalesdb.UserID = dailySales.UserID;
                    dailySalesdb.MonthlyDrawsTaken = dailySales.MonthlyDrawsTaken;
                    dailySalesdb.QBTotalPay = dailySales.QBTotalPay;
                    dailySalesdb.Bonus = dailySales.Bonus;
                    dailySalesdb.ActualPayoutTotal = dailySales.ActualPayoutTotal;
                    dailySalesdb.CashBonus = dailySales.CashBonus;
                    dailySalesdb.MonthlyOfficeRent = dailySales.MonthlyOfficeRent;
                    uow.DailySalesRecordRepository.Insert(dailySalesdb);
                    uow.Save();
                    isSalesAdded = true;
                }
                catch
                {
                    isSalesAdded = false;
                }
            }

            return isSalesAdded;
        }

        public List<DailySalesData> GetSalesRecords()
        {
            List<DailySalesData> lstSales = new List<DailySalesData>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.DailySalesRecordRepository.Get().Select(usd => new DailySalesData
                    {
                        DailySalesRecordID = usd.DailySalesRecordID,
                        DateTime = usd.DateTime,
                        DaySales = usd.DaySales,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        UserID = usd.UserID,
                        Refunds = usd.Refunds,
                        Tier1 = usd.Tier1,
                        Tier2 = usd.Tier2,
                        Tier3 = usd.Tier3,
                        Tier4 = usd.Tier4,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyDrawsTaken = usd.MonthlyDrawsTaken,
                        CashBonus = usd.CashBonus,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        ActualPayoutTotal = usd.ActualPayoutTotal,
                        Bonus = usd.Bonus
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstSales;
        }

        public bool AddSaleRecord(SalesData dailySales)
        {
            bool isSalesAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Sale dailySalesdb = new Sale();
                    dailySalesdb.EntryDate = dailySales.EntryDate;
                    dailySalesdb.DailySaleAmount = dailySales.DailySaleAmount;
                    dailySalesdb.MonthlySales = dailySales.MonthlySales;
                    dailySalesdb.NetSales = dailySales.NetSales;
                    dailySalesdb.Refunds = dailySales.Refunds;
                    dailySalesdb.SalesPersonID = dailySales.SalesPersonID;
                    dailySalesdb.QBTotalPay = dailySales.QBTotalPay;
                    dailySalesdb.CashBonus = dailySales.CashBonus;
                    dailySalesdb.MonthlyOfficeRent = dailySales.MonthlyOfficeRent;
                    dailySalesdb.DrawTakenInMonth = dailySales.DrawTakenInMonth;
                    dailySalesdb.DailyBonus = dailySales.DailyBonus;
                    dailySalesdb.CommisionInUSD = dailySales.CommisionInUSD;
                    dailySalesdb.CommisionPercentage = dailySales.CommisionPercentage;
                    uow.SaleRepository.Insert(dailySalesdb);
                    uow.Save();
                    isSalesAdded = true;
                }
                catch
                {
                    isSalesAdded = false;
                }
            }

            return isSalesAdded;
        }

        public bool EditSaleRecord(SalesData dailySales)
        {
            bool isSalesAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Sale dailySalesdb = uow.SaleRepository.GetById(dailySales.SaleID);
                    dailySalesdb.EntryDate = dailySales.EntryDate;
                    dailySalesdb.DailySaleAmount = dailySales.DailySaleAmount;
                    dailySalesdb.MonthlySales = dailySales.MonthlySales;
                    dailySalesdb.NetSales = dailySales.NetSales;
                    dailySalesdb.Refunds = dailySales.Refunds;
                    dailySalesdb.SalesPersonID = dailySales.SalesPersonID;
                    dailySalesdb.QBTotalPay = dailySales.QBTotalPay;
                    dailySalesdb.CashBonus = dailySales.CashBonus;
                    dailySalesdb.MonthlyOfficeRent = dailySales.MonthlyOfficeRent;
                    dailySalesdb.DrawTakenInMonth = dailySales.DrawTakenInMonth;
                    dailySalesdb.DailyBonus = dailySales.DailyBonus;
                    uow.SaleRepository.Update(dailySalesdb);
                    uow.Save();
                    isSalesAdded = true;
                }
                catch
                {
                    isSalesAdded = false;
                }
            }

            return isSalesAdded;
        }

        public List<SalesData> GetSalesBySalesPersonID(int salesPersonID)
        {
            List<SalesData> lstSales = new List<SalesData>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.SaleRepository.Get().Where(x => x.SalesPersonID == salesPersonID).Select(usd => new SalesData
                    {
                        SaleID = usd.SaleID,
                        EntryDate = usd.EntryDate,
                        DailySaleAmount = usd.DailySaleAmount,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        SalesPersonID = usd.SalesPersonID,
                        Refunds = usd.Refunds,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        CashBonus = usd.CashBonus,
                        DrawTakenInMonth = usd.DrawTakenInMonth,
                        DailyBonus = usd.DailyBonus
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstSales;
        }

        public List<SalesData> GetAllSalesData()
        {
            List<SalesData> lstSales = new List<SalesData>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.SaleRepository.Get().Select(usd => new SalesData
                    {
                        SaleID = usd.SaleID,
                        EntryDate = usd.EntryDate,
                        DailySaleAmount = usd.DailySaleAmount,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        SalesPersonID = usd.SalesPersonID,
                        Refunds = usd.Refunds,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        CashBonus = usd.CashBonus,
                        DrawTakenInMonth = usd.DrawTakenInMonth,
                        DailyBonus = usd.DailyBonus,
                        CommisionInUSD = usd.CommisionInUSD,
                        CommisionPercentage = usd.CommisionPercentage
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstSales;
        }

        public List<SalesData> GetUserSalesDataByMonthYear(int month, int year, int userid)
        {
            List<SalesData> lstSales = new List<SalesData>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.SaleRepository.Get().Where(x => Convert.ToDateTime(x.EntryDate).Month == month && Convert.ToDateTime(x.EntryDate).Year == year && x.SalesPersonID == userid).Select(usd => new SalesData
                    {
                        SaleID = usd.SaleID,
                        EntryDate = usd.EntryDate,
                        DailySaleAmount = usd.DailySaleAmount,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        SalesPersonID = usd.SalesPersonID,
                        Refunds = usd.Refunds,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        CashBonus = usd.CashBonus,
                        DrawTakenInMonth = usd.DrawTakenInMonth,
                        DailyBonus = usd.DailyBonus,
                        CommisionInUSD = usd.CommisionInUSD,
                        CommisionPercentage = usd.CommisionPercentage
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstSales;
        }

        public List<SalesData> GetAllSalesDataByMonthYear(int month, int year)
        {
            List<SalesData> lstSales = new List<SalesData>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.SaleRepository.Get().Where(x => Convert.ToDateTime(x.EntryDate).Month == month && Convert.ToDateTime(x.EntryDate).Year == year).Select(usd => new SalesData
                    {
                        SaleID = usd.SaleID,
                        EntryDate = usd.EntryDate,
                        DailySaleAmount = usd.DailySaleAmount,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        SalesPersonID = usd.SalesPersonID,
                        Refunds = usd.Refunds,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        CashBonus = usd.CashBonus,
                        DrawTakenInMonth = usd.DrawTakenInMonth,
                        DailyBonus = usd.DailyBonus,
                        CommisionInUSD = usd.CommisionInUSD,
                        CommisionPercentage = usd.CommisionPercentage
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstSales;
        }

        public bool CheckSaleDate(string saleDate, int userID)
        {
            bool isDateExist = false;
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    isDateExist = uow.SaleRepository.Get().Any(x => x.EntryDate.Equals(saleDate) && x.SalesPersonID == userID);
                    //isDateExist = true;
                }
                catch
                {

                }
            }
            return isDateExist;
        }

        public SalesData GetSalesBySaleID(int saleID)
        {
            SalesData lstSales = new SalesData();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.SaleRepository.Get().Where(x => x.SaleID == saleID).Select(usd => new SalesData
                    {
                        SaleID = usd.SaleID,
                        EntryDate = usd.EntryDate,
                        DailySaleAmount = usd.DailySaleAmount,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        SalesPersonID = usd.SalesPersonID,
                        Refunds = usd.Refunds,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        CashBonus = usd.CashBonus,
                        DrawTakenInMonth = usd.DrawTakenInMonth,
                        DailyBonus = usd.DailyBonus,
                        CommisionInUSD = usd.CommisionInUSD,
                        CommisionPercentage = usd.CommisionPercentage
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return lstSales;
        }

        public SalesData GetMonthYearSaleBySaleID(int month, int year, int saleID)
        {
            SalesData lstSales = new SalesData();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstSales = uow.SaleRepository.Get().Where(x => Convert.ToDateTime(x.EntryDate).Month == month && Convert.ToDateTime(x.EntryDate).Year == year && x.SaleID == saleID).Select(usd => new SalesData
                    {
                        SaleID = usd.SaleID,
                        EntryDate = usd.EntryDate,
                        DailySaleAmount = usd.DailySaleAmount,
                        MonthlySales = usd.MonthlySales,
                        NetSales = usd.NetSales,
                        SalesPersonID = usd.SalesPersonID,
                        Refunds = usd.Refunds,
                        QBTotalPay = usd.QBTotalPay,
                        MonthlyOfficeRent = usd.MonthlyOfficeRent,
                        CashBonus = usd.CashBonus,
                        DrawTakenInMonth = usd.DrawTakenInMonth,
                        DailyBonus = usd.DailyBonus,
                        CommisionInUSD = usd.CommisionInUSD,
                        CommisionPercentage = usd.CommisionPercentage
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return lstSales;
        }


    }
}
