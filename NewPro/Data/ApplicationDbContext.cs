using NewPro.Models;
using Microsoft.EntityFrameworkCore;

namespace NewPro.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Pendinguser> Pendingusers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("Server=localhost;Database=apps;User=root;", ServerVersion.Parse("10.4.32-mariadb"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("accounts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.AccountActive)
                    .HasColumnType("int(11)")
                    .HasColumnName("account_active");
                entity.Property(e => e.AccountBankName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("account_bank_name");
                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("account_id");
                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("account_number");
                entity.Property(e => e.AccountTitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("account_title");
                entity.Property(e => e.AccountType)
                    .HasColumnType("int(11)")
                    .HasColumnName("account_type");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("chat");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Date)
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp")
                    .HasColumnName("date");
                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("image");
                entity.Property(e => e.ImagePathLocal)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("image_path_local");
                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("message");
                entity.Property(e => e.MsgType)
                    .HasColumnType("int(11)")
                    .HasColumnName("msg_type");
                entity.Property(e => e.SentType)
                    .HasColumnType("int(11)")
                    .HasColumnName("sent_type");
                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("deposit");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Acc)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("acc");
                entity.Property(e => e.AccType)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_type");
                entity.Property(e => e.Amount)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount");
                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("bank_name");
                entity.Property(e => e.BetProUsername)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("bet_pro_username");
                entity.Property(e => e.DateAndTime)
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp")
                    .HasColumnName("date_and_time");
                entity.Property(e => e.DocId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("docID");
                entity.Property(e => e.Proof)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("proof");
                entity.Property(e => e.SenderAccName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_name");
                entity.Property(e => e.SenderAccNum)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_num");
                entity.Property(e => e.SenderAccTrxId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_trx_id");
                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
                entity.Property(e => e.To)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("to");
                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id");
                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("username");
                entity.Property(e => e.Whatsapp)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("whatsapp");
            });

            modelBuilder.Entity<Pendinguser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("pendingusers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Acc)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("acc");
                entity.Property(e => e.AccType)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_type");
                entity.Property(e => e.Amount)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount");
                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("bank_name");
                entity.Property(e => e.BetProUsername)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("bet_pro_username");
                entity.Property(e => e.DateAndTime)
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp")
                    .HasColumnName("date_and_time");
                entity.Property(e => e.DocId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("docID");
                entity.Property(e => e.Proof)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("proof");
                entity.Property(e => e.SenderAccName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_name");
                entity.Property(e => e.SenderAccNum)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_num");
                entity.Property(e => e.SenderAccTrxId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_trx_id");
                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
                entity.Property(e => e.To)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("to");
                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id");
                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("username");
                entity.Property(e => e.Whatsapp)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("whatsapp");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.AdsInitUId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("ads_init_u_id");
                entity.Property(e => e.AdsOnOff)
                    .HasColumnType("int(11)")
                    .HasColumnName("ads_on_off");
                entity.Property(e => e.AdsRewardedUId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("ads_rewarded_u_id");
                entity.Property(e => e.GUserId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("g_user_id");
                entity.Property(e => e.MaintenanceDialog)
                    .HasColumnType("int(11)")
                    .HasColumnName("maintenance_dialog");
                entity.Property(e => e.MaxDeposit)
                    .HasColumnType("int(10)")
                    .HasColumnName("max_deposit");
                entity.Property(e => e.MaxWithdraw)
                    .HasColumnType("int(10)")
                    .HasColumnName("max_withdraw");
                entity.Property(e => e.MessagingKey)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("messaging_key");
                entity.Property(e => e.MessagingKey1)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("messaging_key1");
                entity.Property(e => e.MinDeposit)
                    .HasColumnType("int(10)")
                    .HasColumnName("min_deposit");
                entity.Property(e => e.MinWithdraw)
                    .HasColumnType("int(10)")
                    .HasColumnName("min_withdraw");
                entity.Property(e => e.PackageName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("package_name");
                entity.Property(e => e.StatusMsg)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("status_msg");
                entity.Property(e => e.StatusOn)
                    .HasColumnType("int(11)")
                    .HasColumnName("status_on");
                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("url");
                entity.Property(e => e.Url1)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("url_1");
                entity.Property(e => e.Url2)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("url_2");
                entity.Property(e => e.VersionCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("version_code");
                entity.Property(e => e.WebPageUrlNum)
                    .HasColumnType("int(11)")
                    .HasColumnName("web_page_url_num");
                entity.Property(e => e.YoutubeLink)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("youtube_link");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.MsgToken)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("msg_token");
                entity.Property(e => e.UserActive)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_active");
                entity.Property(e => e.UserAmount)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_amount");
                entity.Property(e => e.UserBetproPassword)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("user_betpro_password");
                entity.Property(e => e.UserBetproUsername)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("user_betpro_username");
                entity.Property(e => e.UserBlocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_blocked");
                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .HasColumnName("user_email");
                entity.Property(e => e.UserFullname)
                    .HasMaxLength(255)
                    .HasColumnName("user_fullname");
                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");
                entity.Property(e => e.UserNumber)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("user_number");
                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("user_password");
                entity.Property(e => e.UserRealPass)
                    .HasMaxLength(255)
                    .HasColumnName("user_real_pass");
                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");
                entity.Property(e => e.UserWhatsapp)
                    .HasMaxLength(255)
                    .HasColumnName("user_whatsapp");
            });

            modelBuilder.Entity<Withdraw>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("withdraw");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Acc)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("acc");
                entity.Property(e => e.AccType)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_type");
                entity.Property(e => e.Amount)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount");
                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("bank_name");
                entity.Property(e => e.BetProUsername)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("bet_pro_username");
                entity.Property(e => e.DateAndTime)
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp")
                    .HasColumnName("date_and_time");
                entity.Property(e => e.DocId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("docID");
                entity.Property(e => e.Proof)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("proof");
                entity.Property(e => e.SenderAccName)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_name");
                entity.Property(e => e.SenderAccNum)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_num");
                entity.Property(e => e.SenderAccTrxId)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("sender_acc_trx_id");
                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");
                entity.Property(e => e.To)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("to");
                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id");
                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("username");
                entity.Property(e => e.Whatsapp)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''")
                    .HasColumnName("whatsapp");
            });
        }
    }
}
