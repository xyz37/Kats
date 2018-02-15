use mysql;

create database kats character set utf8;
create user 'kats'@'%' identified by 'kats!@#';
grant all privileges on kats.* to 'kats'@'%' identified by 'kats!@#';
drop database kats;

SET Global log_bin_trust_function_creators='ON';
