using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        QuantumEntities context = new QuantumEntities();

        QuantumRepository<UserData> userDataRepository;
        QuantumRepository<LeadDoc> leadDocRepository;
        QuantumRepository<Transaction> transactionRepository;
        QuantumRepository<DailySalesRecord> dailySalesRepository;
        QuantumRepository<ComplianceUser> complianceUserRepository;
        QuantumRepository<Sale> saleRepository;
        QuantumRepository<Lead> leadRepository;
        QuantumRepository<CandidateData> candidateRepository;
        QuantumRepository<Setting> settingRepository;
        QuantumRepository<DailyLead> dailyLeadRepository;
        QuantumRepository<LeadNote> leadNoteRepository;
        QuantumRepository<User> userRepository;
        QuantumRepository<AuthenticationToken> authenticationTokenRepository;
        QuantumRepository<DocumentMaster> documentTokenRepository;
        QuantumRepository<UserDocument> userDocumentRepository;
        QuantumRepository<ProfileCard> profileCardRepository;
        QuantumRepository<OrderForm> orderFormRepository;
        QuantumRepository<DriverInterviewProfile> driverInterviewProfileRepository;
        QuantumRepository<DriverService> driverServiceRepository;
        QuantumRepository<DriverVehicle> driverVehicleRepository;
        QuantumRepository<DriverVehicleCargo> driverVehicleCargoRepository;
        QuantumRepository<LoginAnalytic> loginAnalyticRepository;
        QuantumRepository<DocumentAnalytic> documentAnalyticRepository;
        QuantumRepository<MCSale> mCSaleRepository;
        QuantumRepository<MCSaleTemp> mCSaleTempRepository;
        QuantumRepository<MCServiceSale> mCServiceSaleRepository;
        QuantumRepository<MCServiceSaleTemp> mCServiceSaleTempRepository;
        QuantumRepository<DocumentUpload> docUploadRepository;

        public QuantumRepository<DriverVehicleCargo> DriverVehicleCargoRepository
        {
            get
            {
                if (this.driverVehicleCargoRepository == null)
                    this.driverVehicleCargoRepository = new QuantumRepository<DriverVehicleCargo>(context);
                return driverVehicleCargoRepository;
            }
        }

        public QuantumRepository<MCServiceSaleTemp> MCServiceSaleTempRepository
        {
            get
            {
                if (this.mCServiceSaleTempRepository == null)
                    this.mCServiceSaleTempRepository = new QuantumRepository<MCServiceSaleTemp>(context);
                return mCServiceSaleTempRepository;
            }
        }

        public QuantumRepository<MCServiceSale> MCServiceSaleRepository
        {
            get
            {
                if (this.mCServiceSaleRepository == null)
                    this.mCServiceSaleRepository = new QuantumRepository<MCServiceSale>(context);
                return mCServiceSaleRepository;
            }
        }

        public QuantumRepository<MCSaleTemp> MCSaleTempRepository
        {
            get
            {
                if (this.mCSaleTempRepository == null)
                    this.mCSaleTempRepository = new QuantumRepository<MCSaleTemp>(context);
                return mCSaleTempRepository;
            }
        }

        public QuantumRepository<MCSale> MCSaleRepository
        {
            get
            {
                if (this.mCSaleRepository == null)
                    this.mCSaleRepository = new QuantumRepository<MCSale>(context);
                return mCSaleRepository;
            }
        }

        public QuantumRepository<LoginAnalytic> LoginAnalyticRepository
        {
            get
            {
                if (this.loginAnalyticRepository == null)
                    this.loginAnalyticRepository = new QuantumRepository<LoginAnalytic>(context);
                return loginAnalyticRepository;
            }
        }

        public QuantumRepository<DocumentAnalytic> DocumentAnalyticRepository
        {
            get
            {
                if (this.documentAnalyticRepository == null)
                    this.documentAnalyticRepository = new QuantumRepository<DocumentAnalytic>(context);
                return documentAnalyticRepository;
            }
        }

        public QuantumRepository<DriverVehicle> DriverVehicleRepository
        {
            get
            {
                if (this.driverVehicleRepository == null)
                    this.driverVehicleRepository = new QuantumRepository<DriverVehicle>(context);
                return driverVehicleRepository;
            }
        }

        public QuantumRepository<DriverService> DriverServiceRepository
        {
            get
            {
                if (this.driverServiceRepository == null)
                    this.driverServiceRepository = new QuantumRepository<DriverService>(context);
                return driverServiceRepository;
            }
        }

        public QuantumRepository<DriverInterviewProfile> DriverInterviewProfileRepository
        {
            get
            {
                if (this.driverInterviewProfileRepository == null)
                    this.driverInterviewProfileRepository = new QuantumRepository<DriverInterviewProfile>(context);
                return driverInterviewProfileRepository;
            }
        }

        public QuantumRepository<OrderForm> OrderFormRepository
        {
            get
            {
                if (this.orderFormRepository == null)
                    this.orderFormRepository = new QuantumRepository<OrderForm>(context);
                return orderFormRepository;
            }
        }

        public QuantumRepository<ProfileCard> ProfileCardRepository
        {
            get
            {
                if (this.profileCardRepository == null)
                    this.profileCardRepository = new QuantumRepository<ProfileCard>(context);
                return profileCardRepository;
            }
        }

        public QuantumRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new QuantumRepository<User>(context);
                return userRepository;
            }
        }

        public QuantumRepository<AuthenticationToken> AuthenticationTokenRepository
        {
            get
            {
                if (this.authenticationTokenRepository == null)
                    this.authenticationTokenRepository = new QuantumRepository<AuthenticationToken>(context);
                return authenticationTokenRepository;
            }
        }

        public QuantumRepository<DocumentMaster> DocumentMasterRepository
        {
            get
            {
                if (this.documentTokenRepository == null)
                    this.documentTokenRepository = new QuantumRepository<DocumentMaster>(context);
                return documentTokenRepository;
            }
        }

        public QuantumRepository<UserDocument> UserDocumentRepository
        {
            get
            {
                if (this.userDocumentRepository == null)
                    this.userDocumentRepository = new QuantumRepository<UserDocument>(context);
                return userDocumentRepository;
            }
        }

        public QuantumRepository<LeadNote> LeadNoteRepository
        {
            get
            {
                if (this.leadNoteRepository == null)
                    this.leadNoteRepository = new QuantumRepository<LeadNote>(context);
                return leadNoteRepository;
            }
        }

        public QuantumRepository<DailyLead> DailyLeadRepository
        {
            get
            {
                if (this.dailyLeadRepository == null)
                    this.dailyLeadRepository = new QuantumRepository<DailyLead>(context);
                return dailyLeadRepository;
            }
        }
        
        public QuantumRepository<Setting> SettingRepository
        {
            get
            {
                if (this.settingRepository == null)
                    this.settingRepository = new QuantumRepository<Setting>(context);
                return settingRepository;
            }
        }

        public QuantumRepository<LeadDoc> LeadDocRepository
        {
            get
            {
                if (this.leadDocRepository == null)
                    this.leadDocRepository = new QuantumRepository<LeadDoc>(context);
                return leadDocRepository;
            }
        }

        public QuantumRepository<CandidateData> CandidateRepository
        {
            get
            {
                if (this.candidateRepository == null)
                    this.candidateRepository = new QuantumRepository<CandidateData>(context);
                return candidateRepository;
            }
        }

        public QuantumRepository<DailySalesRecord> DailySalesRecordRepository
        {
            get
            {
                if (this.dailySalesRepository == null)
                    this.dailySalesRepository = new QuantumRepository<DailySalesRecord>(context);
                return dailySalesRepository;
            }
        }

        public QuantumRepository<Lead> LeadRepository
        {
            get
            {
                if (this.leadRepository == null)
                    this.leadRepository = new QuantumRepository<Lead>(context);
                return leadRepository;
            }
        }

        public QuantumRepository<Sale> SaleRepository
        {
            get
            {
                if (this.saleRepository == null)
                    this.saleRepository = new QuantumRepository<Sale>(context);
                return saleRepository;
            }
        }

        public QuantumRepository<ComplianceUser> ComplianceUserRepository
        {
            get
            {
                if (this.complianceUserRepository == null)
                    this.complianceUserRepository = new QuantumRepository<ComplianceUser>(context);
                return complianceUserRepository;
            }
        }

        public QuantumRepository<UserData> UserDataRepository
        {
            get
            {
                if (this.userDataRepository == null)
                    this.userDataRepository = new QuantumRepository<UserData>(context);
                return userDataRepository;
            }
        }

       

        public QuantumRepository<Transaction> TransactionRepository
        {
            get
            {
                if (this.transactionRepository == null)
                    this.transactionRepository = new QuantumRepository<Transaction>(context);
                return transactionRepository;
            }
        }

        public QuantumRepository<DocumentUpload> DocumentUploadRepository
        {
            get
            {
                if (this.docUploadRepository == null)
                    this.docUploadRepository = new QuantumRepository<DocumentUpload>(context);
                return docUploadRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            return context.Database.SqlQuery<T>(sql);
        }

        public virtual IEnumerable<T> SQLQueryWithParameters<T>(string sql, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(sql, parameters);
        }

    }
}
