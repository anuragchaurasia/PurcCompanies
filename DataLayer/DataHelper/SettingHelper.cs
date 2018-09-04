using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class SettingHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddTarget(SettingEntity setting)
        {
            bool isTargetAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Setting settingdb = uow.SettingRepository.Get().Where(x => x.SettingID == 1).FirstOrDefault();
                    settingdb.MaxTarget = setting.MaxTarget;
                    settingdb.AdminEmails = setting.AdminEmails;
                    settingdb.ProcessedEmails = setting.ProcessedEmails;
                    settingdb.VoidedEmails = setting.VoidedEmails;
                    settingdb.RefundEmails = setting.RefundEmails;
                    settingdb.Mob_login_text1 = setting.Mob_login_text1;
                    settingdb.Mob_login_text2 = setting.Mob_login_text2;

                    uow.SettingRepository.Update(settingdb);
                    uow.Save();
                    isTargetAdded = true;
                }
                catch
                {
                    isTargetAdded = false;
                }
            }

            return isTargetAdded;
        }

        public SettingEntity GetSettings()
        {
            SettingEntity setting = new SettingEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    setting = uow.SettingRepository.Get().Select(usd => new SettingEntity
                    {
                        SettingID = usd.SettingID,
                        MaxTarget = usd.MaxTarget,
                        AdminEmails = usd.AdminEmails,
                        ProcessedEmails = usd.ProcessedEmails,
                        RefundEmails = usd.RefundEmails,
                        VoidedEmails = usd.VoidedEmails,
                        Mob_login_text1 = usd.Mob_login_text1,
                        Mob_login_text2 = usd.Mob_login_text2
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return setting;
        }
    }
}
