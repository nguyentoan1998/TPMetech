﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Tín_Phát_Metech.EF
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class TinPhatEntities : DbContext
{
    public TinPhatEntities()
        : base("name=TinPhatEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<BTP> BTP { get; set; }

    public virtual DbSet<Chucvu> Chucvu { get; set; }

    public virtual DbSet<Dongia> Dongia { get; set; }

    public virtual DbSet<KH> KH { get; set; }

    public virtual DbSet<Kho> Kho { get; set; }

    public virtual DbSet<Kyhieucong> Kyhieucong { get; set; }

    public virtual DbSet<MQC> MQC { get; set; }

    public virtual DbSet<NCC> NCC { get; set; }

    public virtual DbSet<Nhanvien> Nhanvien { get; set; }

    public virtual DbSet<NLTP> NLTP { get; set; }

    public virtual DbSet<NVL> NVL { get; set; }

    public virtual DbSet<NVLBTP> NVLBTP { get; set; }

    public virtual DbSet<Quydoi> Quydoi { get; set; }

    public virtual DbSet<THSP> THSP { get; set; }

    public virtual DbSet<To> To { get; set; }

    public virtual DbSet<Tonkho> Tonkho { get; set; }

    public virtual DbSet<TP> TP { get; set; }

    public virtual DbSet<User> User { get; set; }

}

}

