using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Text;

namespace BLL.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ProjectModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProjectModel context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Blog DROP CONSTRAINT [FK_dbo.TP_Blog_dbo.TP_FileUpload_FileUploadID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Blog ADD CONSTRAINT [FK_dbo.TP_Blog_dbo.TP_FileUpload_FileUploadID] FOREIGN KEY (FileUploadID) REFERENCES dbo.TP_FileUpload(ID) ON UPDATE NO ACTION ON DELETE SET NULL");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Blog DROP CONSTRAINT [FK_dbo.TP_Blog_dbo.TP_UserSite_UserSiteID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Blog ADD CONSTRAINT [FK_dbo.TP_Blog_dbo.TP_UserSite_UserSiteID] FOREIGN KEY (UserSiteID) REFERENCES dbo.TP_UserSite(ID) ON UPDATE NO ACTION ON DELETE SET NULL");

            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_FileUpload DROP CONSTRAINT [FK_dbo.TP_FileUpload_dbo.TP_FileUploadCategory_FileUploadCategoryID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_FileUpload ADD CONSTRAINT [FK_dbo.TP_FileUpload_dbo.TP_FileUploadCategory_FileUploadCategoryID] FOREIGN KEY (FileUploadCategoryID) REFERENCES dbo.TP_FileUploadCategory(ID) ON UPDATE NO ACTION ON DELETE SET DEFAULT");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_FileUpload DROP CONSTRAINT [DF_TP_FileUpload_FileUploadCategoryID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_FileUpload ADD CONSTRAINT [DF_TP_FileUpload_FileUploadCategoryID] DEFAULT((1)) FOR [FileUploadCategoryID]");

            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Slider DROP CONSTRAINT [FK_dbo.TP_Slider_dbo.TP_FileUpload_FileUploadID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Slider ADD CONSTRAINT [FK_dbo.TP_Slider_dbo.TP_FileUpload_FileUploadID] FOREIGN KEY (FileUploadID) REFERENCES dbo.TP_FileUpload(ID) ON UPDATE NO ACTION ON DELETE SET NULL");

            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Certificate DROP CONSTRAINT [FK_dbo.TP_Certificate_dbo.TP_FileUpload_FileUploadID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Certificate ADD CONSTRAINT [FK_dbo.TP_Certificate_dbo.TP_FileUpload_FileUploadID] FOREIGN KEY (FileUploadID) REFERENCES dbo.TP_FileUpload(ID) ON UPDATE NO ACTION ON DELETE SET NULL");

            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Panel DROP CONSTRAINT [FK_dbo.TP_Panel_dbo.TP_FileUpload_FileUploadID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Panel ADD CONSTRAINT [FK_dbo.TP_Panel_dbo.TP_FileUpload_FileUploadID] FOREIGN KEY (FileUploadID) REFERENCES dbo.TP_FileUpload(ID) ON UPDATE NO ACTION ON DELETE SET NULL");

            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Product DROP CONSTRAINT [FK_dbo.TP_Product_dbo.TP_FileUpload_FileUploadID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Product ADD CONSTRAINT [FK_dbo.TP_Product_dbo.TP_FileUpload_FileUploadID] FOREIGN KEY (FileUploadID) REFERENCES dbo.TP_FileUpload(ID) ON UPDATE NO ACTION ON DELETE SET NULL");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Product DROP CONSTRAINT [FK_dbo.TP_Product_dbo.TP_UserSite_UserSiteID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_Product ADD CONSTRAINT [FK_dbo.TP_Product_dbo.TP_UserSite_UserSiteID] FOREIGN KEY (UserSiteID) REFERENCES dbo.TP_UserSite(ID) ON UPDATE NO ACTION ON DELETE SET NULL");

            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_ProductCategory DROP CONSTRAINT [FK_dbo.TP_ProductCategory_dbo.TP_FileUpload_FileUploadID]");
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.TP_ProductCategory ADD CONSTRAINT [FK_dbo.TP_ProductCategory_dbo.TP_FileUpload_FileUploadID] FOREIGN KEY (FileUploadID) REFERENCES dbo.TP_FileUpload(ID) ON UPDATE NO ACTION ON DELETE SET NULL");

            SaveChanges(context);
            base.Seed(context);
        }

        private static void SaveChanges(ProjectModel context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());

                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
        }
    }
}