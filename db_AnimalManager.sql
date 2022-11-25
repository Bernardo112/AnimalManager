create database db_AnimalManager;

use db_AnimalManager;

create table tb_login(
cd_login int auto_increment,
nm_user varchar(50) not null,
nm_password varchar(50) not null,
id_onUse char(1) not null default 'n',
primary key (cd_login)
);

select * from tb_login;