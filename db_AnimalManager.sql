create database db_AnimalManager;

use db_AnimalManager;

create table tb_login(
cd_login int auto_increment,
nm_user varchar(50) not null,
nm_password varchar(50) not null,
id_onUse char(1) not null default 'n',
primary key (cd_login)
);

create table tb_product(
cd_product int auto_increment,
nm_product varchar(50) not null,
nm_brand varchar(50),
ncm char(8) not null,
vl_sale_price decimal(7,2) not null,
vl_cost_price decimal(7,2),
qt_product int not null default 1,
primary key (cd_product));

create table tb_sale(
cd_sale int auto_increment,
vl_total decimal(8,2),
dt_sale date not null,
primary key (cd_sale)
);

create table tb_product_sale(
cd_product_sale int auto_increment,
fk_cd_product int,
fk_cd_sale int,
qt_product int,
foreign key (fk_cd_product) references tb_product (cd_product),
foreign key (fk_cd_sale) references tb_sale (cd_sale),
primary key (cd_product_sale)
);

create table tb_supplier(
cnpj char(14) not null,
nm_supplier varchar(50) not null,
nm_email varchar(40),
nm_address varchar(50),
nr_phone char(11),
primary key (cnpj));

select * from tb_login;