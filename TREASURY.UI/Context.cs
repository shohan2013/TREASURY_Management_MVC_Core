using TREASURY.UI.Models.AuthModel;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Models.Dashboard;

using TREASURY.UI.Models.Menu;

using Microsoft.EntityFrameworkCore;
using TREASURY.UI.Models.Treasury;
using TREASURY.UI.Models.TreasuryReport;
using TREASURY.UI.Models.LoanFacilityModel;
using TREASURY.UI.Models.BankLoan;

namespace TREASURY.UI
{

    public class DBSecurityDbContext : DbContext
    {
        public DBSecurityDbContext(DbContextOptions<DBSecurityDbContext> options) : base(options)
        {
           
        }

        public DbSet<LoginModel> Login { get; set; }
        public DbSet<Menus> Menu { get; set; }
        public DbSet<Account> Account { get; set; }

        public DbSet<InterestCalculationViewModel> InterestCalculationView { get; set; }
        public DbSet<InterestCalculationModel> InterestCalculation { get; set; }
        public DbSet<TreasuryReportModel> TreasuryReportModel { get; set; }

        public DbSet<DropDownBind> DropDownBind { get; set; }
        public DbSet<DocumentStatus> DocumentStatus { get; set; }
        public DbSet<LoanFacilityViewModel> LoanFacilityViewModel { get; set; }
        public DbSet<LoanFacilityModel> LoanFacilityModel { get; set; }
        public DbSet<BankLoanViewModel> BankLoanViewModel { get; set; }
        public DbSet<BankLoanModel> BankLoanModel { get; set; }
        public DbSet<BankLoanSettlementViewModel> BankLoanSettlementViewModel { get; set; }

    }
}
