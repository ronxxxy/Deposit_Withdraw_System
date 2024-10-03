﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewPro.Data;

#nullable disable

namespace NewPro.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240923164404_SixthCreate")]
    partial class SixthCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "latin1");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("NewPro.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountActive")
                        .HasColumnType("int(11)")
                        .HasColumnName("account_active");

                    b.Property<string>("AccountBankName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("account_bank_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("account_id");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("account_number")
                        .HasDefaultValueSql("''");

                    b.Property<string>("AccountTitle")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("account_title")
                        .HasDefaultValueSql("''");

                    b.Property<int>("AccountType")
                        .HasColumnType("int(11)")
                        .HasColumnName("account_type");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("NewPro.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("date")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("Image")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image")
                        .HasDefaultValueSql("''");

                    b.Property<string>("ImagePathLocal")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image_path_local")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Message")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("message")
                        .HasDefaultValueSql("''");

                    b.Property<int>("MsgType")
                        .HasColumnType("int(11)")
                        .HasColumnName("msg_type");

                    b.Property<int>("SentType")
                        .HasColumnType("int(11)")
                        .HasColumnName("sent_type");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("chat", (string)null);
                });

            modelBuilder.Entity("NewPro.Models.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Acc")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("acc")
                        .HasDefaultValueSql("''");

                    b.Property<int>("AccType")
                        .HasColumnType("int(11)")
                        .HasColumnName("acc_type");

                    b.Property<int>("Amount")
                        .HasColumnType("int(11)")
                        .HasColumnName("amount");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bank_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("BetProUsername")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bet_pro_username")
                        .HasDefaultValueSql("''");

                    b.Property<DateTime>("DateAndTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("date_and_time")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("DocId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("docID")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Proof")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("proof")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccNum")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_num")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccTrxId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_trx_id")
                        .HasDefaultValueSql("''");

                    b.Property<int>("Status")
                        .HasColumnType("int(11)")
                        .HasColumnName("status");

                    b.Property<string>("To")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("to")
                        .HasDefaultValueSql("''");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("whatsapp")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("deposit", (string)null);
                });

            modelBuilder.Entity("NewPro.Models.Pendinguser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Acc")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("acc")
                        .HasDefaultValueSql("''");

                    b.Property<int>("AccType")
                        .HasColumnType("int(11)")
                        .HasColumnName("acc_type");

                    b.Property<int>("Amount")
                        .HasColumnType("int(11)")
                        .HasColumnName("amount");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bank_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("BetProUsername")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bet_pro_username")
                        .HasDefaultValueSql("''");

                    b.Property<DateTime>("DateAndTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("date_and_time")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("DocId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("docID")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Proof")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("proof")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccNum")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_num")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccTrxId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_trx_id")
                        .HasDefaultValueSql("''");

                    b.Property<int>("Status")
                        .HasColumnType("int(11)")
                        .HasColumnName("status");

                    b.Property<string>("To")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("to")
                        .HasDefaultValueSql("''");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("whatsapp")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("pendingusers", (string)null);
                });

            modelBuilder.Entity("NewPro.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdsInitUId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ads_init_u_id")
                        .HasDefaultValueSql("''");

                    b.Property<int>("AdsOnOff")
                        .HasColumnType("int(11)")
                        .HasColumnName("ads_on_off");

                    b.Property<string>("AdsRewardedUId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ads_rewarded_u_id")
                        .HasDefaultValueSql("''");

                    b.Property<string>("GUserId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("g_user_id")
                        .HasDefaultValueSql("''");

                    b.Property<int>("MaintenanceDialog")
                        .HasColumnType("int(11)")
                        .HasColumnName("maintenance_dialog");

                    b.Property<int>("MaxDeposit")
                        .HasColumnType("int(10)")
                        .HasColumnName("max_deposit");

                    b.Property<int>("MaxWithdraw")
                        .HasColumnType("int(10)")
                        .HasColumnName("max_withdraw");

                    b.Property<string>("MessagingKey")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("messaging_key")
                        .HasDefaultValueSql("''");

                    b.Property<string>("MessagingKey1")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("messaging_key1")
                        .HasDefaultValueSql("''");

                    b.Property<int>("MinDeposit")
                        .HasColumnType("int(10)")
                        .HasColumnName("min_deposit");

                    b.Property<int>("MinWithdraw")
                        .HasColumnType("int(10)")
                        .HasColumnName("min_withdraw");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("package_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("StatusMsg")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status_msg")
                        .HasDefaultValueSql("''");

                    b.Property<int>("StatusOn")
                        .HasColumnType("int(11)")
                        .HasColumnName("status_on");

                    b.Property<string>("Url")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("url")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Url1")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("url_1")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Url2")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("url_2")
                        .HasDefaultValueSql("''");

                    b.Property<int>("VersionCode")
                        .HasColumnType("int(11)")
                        .HasColumnName("version_code");

                    b.Property<int>("WebPageUrlNum")
                        .HasColumnType("int(11)")
                        .HasColumnName("web_page_url_num");

                    b.Property<string>("YoutubeLink")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("youtube_link")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("status", (string)null);
                });

            modelBuilder.Entity("NewPro.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MsgToken")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("msg_token")
                        .HasDefaultValueSql("''");

                    b.Property<int>("UserActive")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_active");

                    b.Property<int>("UserAmount")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_amount");

                    b.Property<string>("UserBetproPassword")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_betpro_password")
                        .HasDefaultValueSql("''");

                    b.Property<string>("UserBetproUsername")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_betpro_username")
                        .HasDefaultValueSql("''");

                    b.Property<int>("UserBlocked")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_blocked");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserFullname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_fullname");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("UserNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_number")
                        .HasDefaultValueSql("''");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_password");

                    b.Property<string>("UserRealPass")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_real_pass");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_type");

                    b.Property<string>("UserWhatsapp")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_whatsapp");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("NewPro.Models.Withdraw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Acc")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("acc")
                        .HasDefaultValueSql("''");

                    b.Property<int>("AccType")
                        .HasColumnType("int(11)")
                        .HasColumnName("acc_type");

                    b.Property<int>("Amount")
                        .HasColumnType("int(11)")
                        .HasColumnName("amount");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bank_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("BetProUsername")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bet_pro_username")
                        .HasDefaultValueSql("''");

                    b.Property<DateTime>("DateAndTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("date_and_time")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("DocId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("docID")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Proof")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("proof")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_name")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccNum")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_num")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccTrxId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("sender_acc_trx_id")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SenderAccType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SenderBankName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int(11)")
                        .HasColumnName("status");

                    b.Property<string>("To")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("to")
                        .HasDefaultValueSql("''");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("whatsapp")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("withdraw", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
