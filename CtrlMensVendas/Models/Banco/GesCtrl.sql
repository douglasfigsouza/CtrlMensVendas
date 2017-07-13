/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     12/07/2017 10:07:59                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENDA') and o.name = 'FK_VENDA_REFERENCE_VEICULOS')
alter table VENDA
   drop constraint FK_VENDA_REFERENCE_VEICULOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENDA') and o.name = 'FK_VENDA_REFERENCE_MECANICO')
alter table VENDA
   drop constraint FK_VENDA_REFERENCE_MECANICO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENDA') and o.name = 'FK_VENDA_RELATIONS_CLIENTES')
alter table VENDA
   drop constraint FK_VENDA_RELATIONS_CLIENTES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENDA') and o.name = 'FK_VENDA_RELATIONS_PRODUTOS')
alter table VENDA
   drop constraint FK_VENDA_RELATIONS_PRODUTOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTES')
            and   type = 'U')
   drop table CLIENTES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MECANICOS')
            and   type = 'U')
   drop table MECANICOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUTOS')
            and   type = 'U')
   drop table PRODUTOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VEICULOS')
            and   type = 'U')
   drop table VEICULOS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VENDA')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index VENDA.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VENDA')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index VENDA.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VENDA')
            and   type = 'U')
   drop table VENDA
go

/*==============================================================*/
/* Table: CLIENTES                                              */
/*==============================================================*/
create table CLIENTES (
   IDCLI                int                  identity,
   NOMECLI              varchar(200)         not null,
   ENDERECOCLI          varchar(200)         null,
   constraint PK_CLIENTES primary key nonclustered (IDCLI)
)
go

/*==============================================================*/
/* Table: MECANICOS                                             */
/*==============================================================*/
create table MECANICOS (
   IDMEC                int                  identity,
   NOMEMEC              varchar(200)         not null,
   constraint PK_MECANICOS primary key (IDMEC)
)
go

/*==============================================================*/
/* Table: PRODUTOS                                              */
/*==============================================================*/
create table PRODUTOS (
   IDPROD               int                  identity,
   DESCPROD             varchar(200)         not null,
   VALUNPROD            decimal              not null,
   constraint PK_PRODUTOS primary key nonclustered (IDPROD)
)
go

/*==============================================================*/
/* Table: VEICULOS                                              */
/*==============================================================*/
create table VEICULOS (
   IDVEICULO            int                  identity,
   DESCVEICULO          varchar(50)          not null,
   PLACAVEICULO         varchar(8)           null,
   constraint PK_VEICULOS primary key (IDVEICULO)
)
go

/*==============================================================*/
/* Table: VENDA                                                 */
/*==============================================================*/
create table VENDA (
   IDVENDA              int                  identity,
   IDPROD               int                  not null,
   IDCLI                int                  not null,
   IDVEICULO            int                  null,
   IDMEC                int                  null,
   QTD                  decimal              not null,
   VALORTOTAL           decimal              null,
   DATAENTRADA          datetime             null,
   DATASAIDA            datetime             null,
   constraint PK_VENDA primary key nonclustered (IDPROD, IDCLI, IDVENDA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on VENDA (
IDCLI ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on VENDA (
IDPROD ASC
)
go

alter table VENDA
   add constraint FK_VENDA_REFERENCE_VEICULOS foreign key (IDVEICULO)
      references VEICULOS (IDVEICULO)
go

alter table VENDA
   add constraint FK_VENDA_REFERENCE_MECANICO foreign key (IDMEC)
      references MECANICOS (IDMEC)
go

alter table VENDA
   add constraint FK_VENDA_RELATIONS_CLIENTES foreign key (IDCLI)
      references CLIENTES (IDCLI)
go

alter table VENDA
   add constraint FK_VENDA_RELATIONS_PRODUTOS foreign key (IDPROD)
      references PRODUTOS (IDPROD)
go

