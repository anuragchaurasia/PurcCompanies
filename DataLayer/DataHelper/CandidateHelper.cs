using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class CandidateHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddHiring(CandidateEntity candidate)
        {
            bool isAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    CandidateData candidatedb = new CandidateData();
                    candidatedb.Address = candidate.Address;
                    candidatedb.Apartment = candidate.Apartment;
                    candidatedb.FirstName = candidate.FirstName;
                    candidatedb.AuthorizedForWork = candidate.AuthorizedForWork;
                    candidatedb.LastName = candidate.LastName;
                    candidatedb.CanContactSV1 = candidate.CanContactSV1;
                    candidatedb.CanContactSV2 = candidate.CanContactSV2;
                    candidatedb.CanContactSV3 = candidate.CanContactSV3;
                    candidatedb.City = candidate.City;
                    candidatedb.College = candidate.College;
                    candidatedb.CompanyAddress1 = candidate.CompanyAddress1;
                    candidatedb.CompanyAddress2 = candidate.CompanyAddress2;
                    candidatedb.CompanyAddress3 = candidate.CompanyAddress3;
                    candidatedb.CompanyFrom1 = candidate.CompanyFrom1;
                    candidatedb.CompanyFrom2 = candidate.CompanyFrom2;
                    candidatedb.CompanyFrom3 = candidate.CompanyFrom3;
                    candidatedb.CompanyName1 = candidate.CompanyName1;
                    candidatedb.CompanyName2 = candidate.CompanyName2;
                    candidatedb.CompanyName3 = candidate.CompanyName3;
                    candidatedb.CompanyPhone1 = candidate.CompanyPhone1;
                    candidatedb.CompanyPhone2 = candidate.CompanyPhone2;
                    candidatedb.CompanyPhone3 = candidate.CompanyPhone3;
                    candidatedb.CompanySupervisor1 = candidate.CompanySupervisor1;
                    candidatedb.CompanySupervisor2 = candidate.CompanySupervisor2;
                    candidatedb.CompanySupervisor3 = candidate.CompanySupervisor3;
                    candidatedb.CompanyTo1 = candidate.CompanyTo1;
                    candidatedb.CompanyTo2 = candidate.CompanyTo2;
                    candidatedb.CompanyTo3 = candidate.CompanyTo3;
                    candidatedb.Convicted = candidate.Convicted;
                    candidatedb.Date = candidate.Date;
                    candidatedb.DateAvailable = candidate.DateAvailable;
                    candidatedb.Deegre1 = candidate.Deegre1;
                    candidatedb.Deegre2 = candidate.Deegre2;
                    candidatedb.DeegreAddress = candidate.DeegreAddress;
                    candidatedb.DesiredIncome = candidate.DesiredIncome;
                    candidatedb.DidYouGraduated1 = candidate.DidYouGraduated1;
                    candidatedb.DidYouGraduated2 = candidate.DidYouGraduated2;
                    candidatedb.DidYouGraduated3 = candidate.DidYouGraduated3;
                    candidatedb.Diploma = candidate.Diploma;
                    candidatedb.Email = candidate.Email;
                    candidatedb.EndingSalary1 = candidate.EndingSalary1;
                    candidatedb.EndingSalary2 = candidate.EndingSalary2;
                    candidatedb.EndingSalary3 = candidate.EndingSalary3;
                    candidatedb.Explanation = candidate.Explanation;
                    candidatedb.FirstName = candidate.FirstName;
                    candidatedb.HighSchool = candidate.HighSchool;
                    candidatedb.IfYesExplain = candidate.IfYesExplain;
                    candidatedb.IfYesWhen = candidate.IfYesWhen;
                    candidatedb.JobTitle1 = candidate.JobTitle1;
                    candidatedb.JobTitle2 = candidate.JobTitle2;
                    candidatedb.JobTitle3 = candidate.JobTitle3;
                    candidatedb.LastName = candidate.LastName;
                    candidatedb.MiddleName = candidate.MiddleName;
                    candidatedb.MilitaryBranch = candidate.MilitaryBranch;
                    candidatedb.MilitaryFrom = candidate.MilitaryFrom;
                    candidatedb.MilitaryTo = candidate.MilitaryTo;
                    candidatedb.Other = candidate.Other;
                    candidatedb.Phone = candidate.Phone;
                    candidatedb.PositionAppliedFor = candidate.PositionAppliedFor;
                    candidatedb.RankAtDischarge = candidate.RankAtDischarge;
                    candidatedb.ReasonForLeaving1 = candidate.ReasonForLeaving1;
                    candidatedb.ReasonForLeaving2 = candidate.ReasonForLeaving2;
                    candidatedb.ReasonForLeaving3 = candidate.ReasonForLeaving3;
                    candidatedb.RefAddress1 = candidate.RefAddress1;
                    candidatedb.RefAddress2 = candidate.RefAddress2;
                    candidatedb.RefAddress3 = candidate.RefAddress3;
                    candidatedb.RefCompany1 = candidate.RefCompany1;
                    candidatedb.RefCompany2 = candidate.RefCompany2;
                    candidatedb.RefCompany3 = candidate.RefCompany3;
                    candidatedb.RefFullName1 = candidate.RefFullName1;
                    candidatedb.RefFullName2 = candidate.RefFullName2;
                    candidatedb.RefFullName3 = candidate.RefFullName3;
                    candidatedb.RefPhone1 = candidate.RefPhone1;
                    candidatedb.RefPhone2 = candidate.RefPhone2;
                    candidatedb.RefPhone3 = candidate.RefPhone3;
                    candidatedb.RefRelationShip1 = candidate.RefRelationShip1;
                    candidatedb.RefRelationShip2 = candidate.RefRelationShip2;
                    candidatedb.RefRelationShip3 = candidate.RefRelationShip3;
                    candidatedb.Responsibilities1 = candidate.Responsibilities1;
                    candidatedb.Responsibilities2 = candidate.Responsibilities2;
                    candidatedb.Responsibilities3 = candidate.Responsibilities3;
                    candidatedb.ResumeDetails = candidate.ResumeDetails;
                    candidatedb.SchoolAddress = candidate.SchoolAddress;
                    candidatedb.SchoolFrom1 = candidate.SchoolFrom1;
                    candidatedb.SchoolFrom2 = candidate.SchoolFrom2;
                    candidatedb.SchoolFrom3 = candidate.SchoolFrom3;
                    candidatedb.SchoolTo1 = candidate.SchoolTo1;
                    candidatedb.SchoolTo2 = candidate.SchoolTo2;
                    candidatedb.SchoolTo3 = candidate.SchoolTo3;
                    candidatedb.SignatureName = candidate.SignatureName;
                    candidatedb.SocialSecurityNo = candidate.SocialSecurityNo;
                    candidatedb.StartingSalary1 = candidate.StartingSalary1;
                    candidatedb.StartingSalary2 = candidate.StartingSalary2;
                    candidatedb.StartingSalary3 = candidate.StartingSalary3;
                    candidatedb.State = candidate.State;
                    candidatedb.StreetAddress = candidate.StreetAddress;
                    candidatedb.TypeOFDischarge = candidate.TypeOFDischarge;
                    candidatedb.UsCitiZen = candidate.UsCitiZen;
                    candidatedb.WorkedHere = candidate.WorkedHere;
                    candidatedb.ZipCode = candidate.ZipCode;
                    uow.CandidateRepository.Insert(candidatedb);
                    uow.Save();
                    isAdded = true;
                }
                catch
                {
                    isAdded = false;
                }
            }

            return isAdded;
        }

        public List<CandidateEntity> GetAllCandidates()
        {
            List<CandidateEntity> lstCandidates = new List<CandidateEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstCandidates = uow.CandidateRepository.Get().Select(candidate => new CandidateEntity
                    {
                        CanadidateID = candidate.CanadidateID,
                        Address = candidate.Address,
                        Apartment = candidate.Apartment,
                        FirstName = candidate.FirstName,
                        AuthorizedForWork = candidate.AuthorizedForWork,
                        LastName = candidate.LastName,
                        CanContactSV1 = candidate.CanContactSV1,
                        CanContactSV2 = candidate.CanContactSV2,
                        CanContactSV3 = candidate.CanContactSV3,
                        City = candidate.City,
                        College = candidate.College,
                        CompanyAddress1 = candidate.CompanyAddress1,
                        CompanyAddress2 = candidate.CompanyAddress2,
                        CompanyAddress3 = candidate.CompanyAddress3,
                        CompanyFrom1 = candidate.CompanyFrom1,
                        CompanyFrom2 = candidate.CompanyFrom2,
                        CompanyFrom3 = candidate.CompanyFrom3,
                        CompanyName1 = candidate.CompanyName1,
                        CompanyName2 = candidate.CompanyName2,
                        CompanyName3 = candidate.CompanyName3,
                        CompanyPhone1 = candidate.CompanyPhone1,
                        CompanyPhone2 = candidate.CompanyPhone2,
                        CompanyPhone3 = candidate.CompanyPhone3,
                        CompanySupervisor1 = candidate.CompanySupervisor1,
                        CompanySupervisor2 = candidate.CompanySupervisor2,
                        CompanySupervisor3 = candidate.CompanySupervisor3,
                        CompanyTo1 = candidate.CompanyTo1,
                        CompanyTo2 = candidate.CompanyTo2,
                        CompanyTo3 = candidate.CompanyTo3,
                        Convicted = candidate.Convicted,
                        Date = candidate.Date,
                        DateAvailable = candidate.DateAvailable,
                        Deegre1 = candidate.Deegre1,
                        Deegre2 = candidate.Deegre2,
                        DeegreAddress = candidate.DeegreAddress,
                        DesiredIncome = candidate.DesiredIncome,
                        DidYouGraduated1 = candidate.DidYouGraduated1,
                        DidYouGraduated2 = candidate.DidYouGraduated2,
                        DidYouGraduated3 = candidate.DidYouGraduated3,
                        Diploma = candidate.Diploma,
                        Email = candidate.Email,
                        EndingSalary1 = candidate.EndingSalary1,
                        EndingSalary2 = candidate.EndingSalary2,
                        EndingSalary3 = candidate.EndingSalary3,
                        Explanation = candidate.Explanation,
                        HighSchool = candidate.HighSchool,
                        IfYesExplain = candidate.IfYesExplain,
                        IfYesWhen = candidate.IfYesWhen,
                        JobTitle1 = candidate.JobTitle1,
                        JobTitle2 = candidate.JobTitle2,
                        JobTitle3 = candidate.JobTitle3,
                        MiddleName = candidate.MiddleName,
                        MilitaryBranch = candidate.MilitaryBranch,
                        MilitaryFrom = candidate.MilitaryFrom,
                        MilitaryTo = candidate.MilitaryTo,
                        Other = candidate.Other,
                        Phone = candidate.Phone,
                        PositionAppliedFor = candidate.PositionAppliedFor,
                        RankAtDischarge = candidate.RankAtDischarge,
                        ReasonForLeaving1 = candidate.ReasonForLeaving1,
                        ReasonForLeaving2 = candidate.ReasonForLeaving2,
                        ReasonForLeaving3 = candidate.ReasonForLeaving3,
                        RefAddress1 = candidate.RefAddress1,
                        RefAddress2 = candidate.RefAddress2,
                        RefAddress3 = candidate.RefAddress3,
                        RefCompany1 = candidate.RefCompany1,
                        RefCompany2 = candidate.RefCompany2,
                        RefCompany3 = candidate.RefCompany3,
                        RefFullName1 = candidate.RefFullName1,
                        RefFullName2 = candidate.RefFullName2,
                        RefFullName3 = candidate.RefFullName3,
                        RefPhone1 = candidate.RefPhone1,
                        RefPhone2 = candidate.RefPhone2,
                        RefPhone3 = candidate.RefPhone3,
                        RefRelationShip1 = candidate.RefRelationShip1,
                        RefRelationShip2 = candidate.RefRelationShip2,
                        RefRelationShip3 = candidate.RefRelationShip3,
                        Responsibilities1 = candidate.Responsibilities1,
                        Responsibilities2 = candidate.Responsibilities2,
                        Responsibilities3 = candidate.Responsibilities3,
                        ResumeDetails = candidate.ResumeDetails,
                        SchoolAddress = candidate.SchoolAddress,
                        SchoolFrom1 = candidate.SchoolFrom1,
                        SchoolFrom2 = candidate.SchoolFrom2,
                        SchoolFrom3 = candidate.SchoolFrom3,
                        SchoolTo1 = candidate.SchoolTo1,
                        SchoolTo2 = candidate.SchoolTo2,
                        SchoolTo3 = candidate.SchoolTo3,
                        SignatureName = candidate.SignatureName,
                        SocialSecurityNo = candidate.SocialSecurityNo,
                        StartingSalary1 = candidate.StartingSalary1,
                        StartingSalary2 = candidate.StartingSalary2,
                        StartingSalary3 = candidate.StartingSalary3,
                        State = candidate.State,
                        StreetAddress = candidate.StreetAddress,
                        TypeOFDischarge = candidate.TypeOFDischarge,
                        UsCitiZen = candidate.UsCitiZen,
                        WorkedHere = candidate.WorkedHere,
                        ZipCode = candidate.ZipCode,
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstCandidates;
        }

        public CandidateEntity GetCandidateByID(int candidateID)
        {
            CandidateEntity lstCandidates = new CandidateEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstCandidates = uow.CandidateRepository.Get().Where(x => x.CanadidateID == candidateID).Select(candidate => new CandidateEntity
                    {
                        CanadidateID = candidate.CanadidateID,
                        Address = candidate.Address,
                        Apartment = candidate.Apartment,
                        FirstName = candidate.FirstName,
                        AuthorizedForWork = candidate.AuthorizedForWork,
                        LastName = candidate.LastName,
                        CanContactSV1 = candidate.CanContactSV1,
                        CanContactSV2 = candidate.CanContactSV2,
                        CanContactSV3 = candidate.CanContactSV3,
                        City = candidate.City,
                        College = candidate.College,
                        CompanyAddress1 = candidate.CompanyAddress1,
                        CompanyAddress2 = candidate.CompanyAddress2,
                        CompanyAddress3 = candidate.CompanyAddress3,
                        CompanyFrom1 = candidate.CompanyFrom1,
                        CompanyFrom2 = candidate.CompanyFrom2,
                        CompanyFrom3 = candidate.CompanyFrom3,
                        CompanyName1 = candidate.CompanyName1,
                        CompanyName2 = candidate.CompanyName2,
                        CompanyName3 = candidate.CompanyName3,
                        CompanyPhone1 = candidate.CompanyPhone1,
                        CompanyPhone2 = candidate.CompanyPhone2,
                        CompanyPhone3 = candidate.CompanyPhone3,
                        CompanySupervisor1 = candidate.CompanySupervisor1,
                        CompanySupervisor2 = candidate.CompanySupervisor2,
                        CompanySupervisor3 = candidate.CompanySupervisor3,
                        CompanyTo1 = candidate.CompanyTo1,
                        CompanyTo2 = candidate.CompanyTo2,
                        CompanyTo3 = candidate.CompanyTo3,
                        Convicted = candidate.Convicted,
                        Date = candidate.Date,
                        DateAvailable = candidate.DateAvailable,
                        Deegre1 = candidate.Deegre1,
                        Deegre2 = candidate.Deegre2,
                        DeegreAddress = candidate.DeegreAddress,
                        DesiredIncome = candidate.DesiredIncome,
                        DidYouGraduated1 = candidate.DidYouGraduated1,
                        DidYouGraduated2 = candidate.DidYouGraduated2,
                        DidYouGraduated3 = candidate.DidYouGraduated3,
                        Diploma = candidate.Diploma,
                        Email = candidate.Email,
                        EndingSalary1 = candidate.EndingSalary1,
                        EndingSalary2 = candidate.EndingSalary2,
                        EndingSalary3 = candidate.EndingSalary3,
                        Explanation = candidate.Explanation,
                        HighSchool = candidate.HighSchool,
                        IfYesExplain = candidate.IfYesExplain,
                        IfYesWhen = candidate.IfYesWhen,
                        JobTitle1 = candidate.JobTitle1,
                        JobTitle2 = candidate.JobTitle2,
                        JobTitle3 = candidate.JobTitle3,
                        MiddleName = candidate.MiddleName,
                        MilitaryBranch = candidate.MilitaryBranch,
                        MilitaryFrom = candidate.MilitaryFrom,
                        MilitaryTo = candidate.MilitaryTo,
                        Other = candidate.Other,
                        Phone = candidate.Phone,
                        PositionAppliedFor = candidate.PositionAppliedFor,
                        RankAtDischarge = candidate.RankAtDischarge,
                        ReasonForLeaving1 = candidate.ReasonForLeaving1,
                        ReasonForLeaving2 = candidate.ReasonForLeaving2,
                        ReasonForLeaving3 = candidate.ReasonForLeaving3,
                        RefAddress1 = candidate.RefAddress1,
                        RefAddress2 = candidate.RefAddress2,
                        RefAddress3 = candidate.RefAddress3,
                        RefCompany1 = candidate.RefCompany1,
                        RefCompany2 = candidate.RefCompany2,
                        RefCompany3 = candidate.RefCompany3,
                        RefFullName1 = candidate.RefFullName1,
                        RefFullName2 = candidate.RefFullName2,
                        RefFullName3 = candidate.RefFullName3,
                        RefPhone1 = candidate.RefPhone1,
                        RefPhone2 = candidate.RefPhone2,
                        RefPhone3 = candidate.RefPhone3,
                        RefRelationShip1 = candidate.RefRelationShip1,
                        RefRelationShip2 = candidate.RefRelationShip2,
                        RefRelationShip3 = candidate.RefRelationShip3,
                        Responsibilities1 = candidate.Responsibilities1,
                        Responsibilities2 = candidate.Responsibilities2,
                        Responsibilities3 = candidate.Responsibilities3,
                        ResumeDetails = candidate.ResumeDetails,
                        SchoolAddress = candidate.SchoolAddress,
                        SchoolFrom1 = candidate.SchoolFrom1,
                        SchoolFrom2 = candidate.SchoolFrom2,
                        SchoolFrom3 = candidate.SchoolFrom3,
                        SchoolTo1 = candidate.SchoolTo1,
                        SchoolTo2 = candidate.SchoolTo2,
                        SchoolTo3 = candidate.SchoolTo3,
                        SignatureName = candidate.SignatureName,
                        SocialSecurityNo = candidate.SocialSecurityNo,
                        StartingSalary1 = candidate.StartingSalary1,
                        StartingSalary2 = candidate.StartingSalary2,
                        StartingSalary3 = candidate.StartingSalary3,
                        State = candidate.State,
                        StreetAddress = candidate.StreetAddress,
                        TypeOFDischarge = candidate.TypeOFDischarge,
                        UsCitiZen = candidate.UsCitiZen,
                        WorkedHere = candidate.WorkedHere,
                        ZipCode = candidate.ZipCode,
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return lstCandidates;
        }

    }
}
